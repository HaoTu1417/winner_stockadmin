// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.AppFileBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Tool;
using stockadmin.ViewModels.AppFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace stockadmin.Business
{
  public class AppFileBiz
  {
    public static List<AppFileList> GetAppFileList(AppFileFilter? filter)
    {
      List<AppFileList> appFileList = AppFilesService.FindAppFileList(SqlTool.Build<AppFileFilter>(filter));
      return appFileList == null ? (List<AppFileList>) null : appFileList.Select<AppFileList, AppFileList>((Func<AppFileList, AppFileList>) (appfile => PublicTool.convertUtcToLocalTime<AppFileList>(appfile))).ToList<AppFileList>();
    }

    public static AppFileDto Get(int pk) => AppFilesService.Find(pk);

    public static async Task PostCreate(AppFileDto req, AdminSession adminUser)
    {
      try
      {
        APIResponse<UploadFileResponse> apiResponse = await UploadFileLib.UploadFile(FileManagementLib.Folder.app_file, req.file);
        if (apiResponse == null)
          return;
        if (req.code == "")
          req.code = apiResponse.data.code;
        AppFilesService.FindPkAfterInsert(new AppFileDto()
        {
          path = apiResponse.data.path,
          code = req.code,
          version = req.version,
          device = req.device
        });
      }
      catch (AppException ex)
      {
        throw new AppException(ex.GetStatus(), ex.Message);
      }
    }

    public static async void PostEdit(AppFileDto req, AdminSession adminUser)
    {
      try
      {
        if (req.file != null)
        {
          APIResponse<UploadFileResponse> apiResponse = await UploadFileLib.UploadFile(FileManagementLib.Folder.app_file, req.file);
          if (apiResponse == null)
            throw new AppException(3010, "record_update_false");
          req.code = AppFileBiz.GenerateRandomString(6);
          req.path = apiResponse.data.path.Substring(1);
          req.upload_date = DateTime.UtcNow;
        }
        AppFilesService.Update(req);
        object[] objArray = new object[3]
        {
          (object) adminUser.account,
          (object) adminUser.nickName,
          (object) req.code
        };
        AdminLogLib.Save(new AdminLogRequest()
        {
          admin_user_pk = adminUser.pk,
          admin_menu_fk = 436,
          list = objArray
        });
      }
      catch (AppException ex)
      {
        throw new AppException(ex.GetStatus(), ex.Message);
      }
    }

    public static async Task Delete(int pk, AdminSession adminUser)
    {
      AppFileDto file = AppFilesService.Find(pk);
      Task.Run((Func<Task>) (() => UploadFileLib.DeleteFile(file.path)));
      AppFilesService.Remove(pk);
    }

    private static string GenerateRandomString(int length)
    {
      Random random = new Random();
      return new string(Enumerable.Repeat<string>("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length).Select<string, char>((Func<string, char>) (s => s[random.Next(s.Length)])).ToArray<char>());
    }
  }
}
