// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.AdvertiseBiz
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
using stockadmin.Models.Admin;
using stockadmin.Tool;
using stockadmin.ViewModels.Advertise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace stockadmin.Business
{
  public class AdvertiseBiz
  {
    public static List<AdvertiseList> GetAdvertiseList(AdvertiseFilter? filter)
    {
      List<AdvertiseList> advertiseList = CmsAdvertiseService.FindAdvertiseList(SqlTool.Build<AdvertiseFilter>(filter));
      return advertiseList == null ? (List<AdvertiseList>) null : advertiseList.Select<AdvertiseList, AdvertiseList>((Func<AdvertiseList, AdvertiseList>) (advertise => PublicTool.convertUtcToLocalTime<AdvertiseList>(advertise))).ToList<AdvertiseList>();
    }

    public static CmsAdvertiseDto Get(int cms_files_fk) => CmsAdvertiseService.Find(cms_files_fk);

    private static bool checkSizeWithNoise(int actual_size, int size, int noise)
    {
      return actual_size >= size - noise && actual_size <= size + noise;
    }

    private static bool checkSize(IFormFile req_image)
    {
      ImageInfo imageInfo = Image.Identify(req_image.OpenReadStream());
      int height = imageInfo.Height;
      int width = imageInfo.Width;
      int noise = 0;
      return AdvertiseBiz.checkSizeWithNoise(width, 650, noise) && AdvertiseBiz.checkSizeWithNoise(height, 150, noise);
    }

    public static async Task PostCreate(CmsAdvertiseDto req, AdminSession adminUser)
    {
      try
      {
        if (!AdvertiseBiz.checkSize(req.image))
          throw new AppException("照片尺寸不符, 需為650x150");
        List<int> intList = await UploadImageLib.UploadImage(FileManagementLib.Folder.advertise, "cms_advertise", 0, false, req.image, req.watermark, req.watermark_size, req.watermark_color);
        req.cms_files_fk = intList[0];
        req.url = CmsFilesService.Find(intList[0]).url;
        int pkAfterInsert = CmsAdvertiseService.FindPkAfterInsert(req);
        CmsFilesService.UpdateKey(intList[0], pkAfterInsert);
      }
      catch (Exception ex)
      {
        throw new AppException("照片尺寸不符, 需為650x150");
      }
    }

    public static async void PostEdit(CmsAdvertiseDto req, AdminSession adminUser)
    {
      if (req.image != null)
      {
        await UploadImageLib.UpdateUploadImage(FileManagementLib.Folder.advertise, "cms_advertise", req.cms_files_fk, false, req.image);
        req.url = CmsFilesService.Find(req.cms_files_fk).url;
      }
      if (CmsAdvertiseService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.url
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 220,
        list = objArray
      });
    }

    public static async Task Delete(int cms_files_fk, AdminSession adminUser)
    {
      CmsFilesDto file = CmsFilesService.Find(cms_files_fk);
      Task.Run((Func<Task>) (() => UploadFileLib.DeleteFile(file.url)));
      CmsAdvertiseService.Remove(cms_files_fk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) file.url
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 222,
        list = objArray
      });
    }
  }
}
