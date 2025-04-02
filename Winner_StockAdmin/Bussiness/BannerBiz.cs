// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.BannerBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Tool;
using stockadmin.ViewModels.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace stockadmin.Business
{
  public class BannerBiz
  {
    public static List<BannerList> GetBannerList(BannerFilter? filter, string lang)
    {
      List<BannerList> bannerList = CmsBannerService.FindBannerList(SqlTool.Build<BannerFilter>(filter), lang);
      return bannerList == null ? (List<BannerList>) null : bannerList.Select<BannerList, BannerList>((Func<BannerList, BannerList>) (banner => PublicTool.convertUtcToLocalTime<BannerList>(banner))).ToList<BannerList>();
    }

    public static CmsBannerDto Get(int cms_files_fk) => CmsBannerService.Find(cms_files_fk);

    public static async Task PostCreate(CmsBannerDto req, AdminSession adminUser)
    {
      try
      {
        List<int> intList = await UploadImageLib.UploadImage(FileManagementLib.Folder.banner, "cms_banner", 0, false, req.image, req.watermark, req.watermark_size, req.watermark_color);
        req.cms_files_fk = intList[0];
        req.url = CmsFilesService.Find(intList[0]).url;
        int pkAfterInsert = CmsBannerService.FindPkAfterInsert(req);
        CmsFilesService.UpdateKey(intList[0], pkAfterInsert);
        object[] objArray = new object[3]
        {
          (object) adminUser.account,
          (object) adminUser.nickName,
          (object) req.url
        };
        AdminLogLib.Save(new AdminLogRequest()
        {
          admin_user_pk = adminUser.pk,
          admin_menu_fk = 221,
          list = objArray
        });
      }
      catch (Exception ex)
      {
        throw new AppException("資料建立失敗");
      }
    }

    public static async void PostEdit(CmsBannerDto req, AdminSession adminUser)
    {
      if (req.image != null)
      {
        await UploadImageLib.UpdateUploadImage(FileManagementLib.Folder.banner, "cms_banner", req.cms_files_fk, false, req.image);
        req.url = CmsFilesService.Find(req.cms_files_fk).url;
      }
      if (CmsBannerService.UpdateFull(req) == 0)
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
      CmsBannerService.Remove(cms_files_fk);
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
