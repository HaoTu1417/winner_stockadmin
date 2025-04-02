// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.PromotionBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using HtmlAgilityPack;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Tool;
using stockadmin.ViewModels.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class PromotionBiz
  {
    public static List<PromotionList> GetPromotionList(PromotionFilter? filter)
    {
      List<PromotionList> promotionList = CmsPromotionService.FindPromotionList(SqlTool.Build<PromotionFilter>(filter));
      return promotionList == null ? (List<PromotionList>) null : promotionList.Select<PromotionList, PromotionList>((Func<PromotionList, PromotionList>) (messageRecord => PublicTool.convertUtcToLocalTime<PromotionList>(messageRecord))).ToList<PromotionList>();
    }

    public static CmsPromotionDto Get(int pk) => CmsPromotionService.Find(pk);

    public static async void PostCreate(CmsPromotionDto req, AdminSession adminUser)
    {
      if (req.img_file != null)
        req.img_url = await UploadImageLib.UploadImage(FileManagementLib.Folder.article, req.img_file, req.watermark, req.watermark_size, req.watermark_color);
      if (CmsPromotionService.FindPkAfterInsert(PublicTool.convertLocalToUtcTime<CmsPromotionDto>(req)) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.title
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 147,
        list = objArray
      });
    }

    public static async void PostEdit(CmsPromotionDto req, AdminSession adminUser)
    {
      if (req.img_file != null)
        req.img_url = await UploadImageLib.UploadImage(FileManagementLib.Folder.article, req.img_file);
      if (CmsPromotionService.UpdateFull(PublicTool.convertLocalToUtcTime<CmsPromotionDto>(req)) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.title
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 146,
        list = objArray
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      string title = CmsPromotionService.Find(pk).title;
      CmsPromotionService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) title
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 148,
        list = objArray
      });
    }

    public static string AppendTopicContentStyle(string topic_content)
    {
      HtmlDocument htmlDocument = new HtmlDocument();
      htmlDocument.LoadHtml(topic_content);
      HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//img");
      if (htmlNodeCollection != null)
      {
        foreach (HtmlNode htmlNode in (IEnumerable<HtmlNode>) htmlNodeCollection)
        {
          string str = "display: block; " + htmlNode.GetAttributeValue("style", string.Empty);
          htmlNode.SetAttributeValue("style", str);
        }
      }
      return htmlDocument.DocumentNode.OuterHtml;
    }
  }
}
