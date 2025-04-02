// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.AppLogoBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Microsoft.AspNetCore.Http;
using Models.Dto;
using SixLabors.ImageSharp;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Tool;
using stockadmin.ViewModels.AppLogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace stockadmin.Business
{
  public class AppLogoBiz
  {
    public static List<AppLogoList> GetAppLogoList(string lang)
    {
      List<AppLogoList> appLogoList = AppLogoService.FindAppLogoList(lang: lang);
      return appLogoList == null ? (List<AppLogoList>) null : appLogoList.Select<AppLogoList, AppLogoList>((Func<AppLogoList, AppLogoList>) (advertise => PublicTool.convertUtcToLocalTime<AppLogoList>(advertise))).ToList<AppLogoList>();
    }

    public static string GetAppLogoUrl(int type)
    {
      try
      {
        List<AppLogoList> appLogoList1 = AppLogoBiz.GetAppLogoList("");
        if (appLogoList1 != null)
        {
          AppLogoList appLogoList2 = appLogoList1.Find((Predicate<AppLogoList>) (logo => logo.type == type));
          if (appLogoList2 != null)
            return appLogoList2.url;
        }
        return "";
      }
      catch
      {
        return "";
      }
    }

    public static AppLogoDto Get(int cms_files_fk) => AppLogoService.Find(cms_files_fk);

    private static bool checkSizeWithNoise(int actual_size, int size, int noise)
    {
      return actual_size >= size - noise && actual_size <= size + noise;
    }

    private static bool checkSize(IFormFile req_image, int req_type)
    {
      ImageInfo imageInfo = Image.Identify(req_image.OpenReadStream());
      int height = imageInfo.Height;
      int width = imageInfo.Width;
      int noise = 0;
      switch (req_type)
      {
        case 1:
          return AppLogoBiz.checkSizeWithNoise(width, 131, noise) && AppLogoBiz.checkSizeWithNoise(height, 180, noise);
        case 2:
          return AppLogoBiz.checkSizeWithNoise(width, 245, noise) && AppLogoBiz.checkSizeWithNoise(height, 104, noise);
        case 3:
          return AppLogoBiz.checkSizeWithNoise(width, 750, noise) && AppLogoBiz.checkSizeWithNoise(height, 1000, noise);
        case 4:
          return AppLogoBiz.checkSizeWithNoise(width, 187, noise) && AppLogoBiz.checkSizeWithNoise(height, 38, noise);
        case 5:
          return AppLogoBiz.checkSizeWithNoise(width, 750, noise) && AppLogoBiz.checkSizeWithNoise(height, 978, noise);
        case 6:
          return AppLogoBiz.checkSizeWithNoise(width, 600, noise) && AppLogoBiz.checkSizeWithNoise(height, 800, noise);
        case 7:
          return AppLogoBiz.checkSizeWithNoise(width, 600, noise) && AppLogoBiz.checkSizeWithNoise(height, 800, noise);
        default:
          return false;
      }
    }

    public static async Task PostCreate(AppLogoDto req, AdminSession adminUser)
    {
      try
      {
        if (!AppLogoBiz.checkSize(req.image, req.type))
          throw new AppException("照片尺寸不符");
        List<int> intList = await UploadImageLib.UploadImage(FileManagementLib.Folder.app_logo, "app_logo", 0, false, req.image);
        req.cms_files_fk = intList[0];
        req.url = CmsFilesService.Find(intList[0]).url;
        int pkAfterInsert = AppLogoService.FindPkAfterInsert(req);
        CmsFilesService.UpdateKey(intList[0], pkAfterInsert);
      }
      catch (Exception ex)
      {
        throw new AppException(ex.Message);
      }
    }

    public static async Task PostEdit(AppLogoDto req, AdminSession adminUser)
    {
      try
      {
        if (req.image != null)
        {
          if (!AppLogoBiz.checkSize(req.image, req.type))
            throw new AppException("照片尺寸不符");
          await UploadImageLib.UpdateUploadImage(FileManagementLib.Folder.app_logo, "app_logo", req.cms_files_fk, false, req.image);
          req.url = CmsFilesService.Find(req.cms_files_fk).url;
        }
        if (AppLogoService.UpdateFull(req) == 0)
          throw new AppException(3010, "record_update_false");
      }
      catch (Exception ex)
      {
        throw new AppException(ex.Message);
      }
    }

    public static async Task Delete(int cms_files_fk, AdminSession adminUser)
    {
      CmsFilesDto file = CmsFilesService.Find(cms_files_fk);
      Task.Run((Func<Task>) (() => UploadFileLib.DeleteFile(file.url)));
      AppLogoService.Remove(cms_files_fk);
    }
  }
}
