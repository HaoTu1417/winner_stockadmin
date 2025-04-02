// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.DocumentBiz
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
using stockadmin.ViewModels.Document;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Business
{
  public class DocumentBiz
  {
    public static List<DocumentList> GetDocumentList(DocumentFilter? filter)
    {
      return CmsDocumentService.FindDocumentList(SqlTool.Build<DocumentFilter>(filter));
    }

    public static CmsDocumentDto Get(int pk) => CmsDocumentService.Find(pk);

    public static void PostCreate(CmsDocumentDto req, AdminSession adminUser)
    {
      if (CmsDocumentService.FindPkAfterInsert(req) == 0)
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
        admin_menu_fk = 160,
        list = objArray
      });
    }

    public static void PostEdit(CmsDocumentDto req, AdminSession adminUser)
    {
      if (CmsDocumentService.UpdateFull(req) == 0)
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
        admin_menu_fk = 158,
        list = objArray
      });
    }

    public static void PostCopy(CmsDocumentDto req, AdminSession adminUser)
    {
      if (CmsDocumentService.FindByCIDLANG(req.cid, req.lang) != null)
        throw new AppException(3011, "record_copy_false_already_existed");
      if (CmsDocumentService.FindPkAfterInsert(req) == 0)
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
        admin_menu_fk = 159,
        list = objArray
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      string title = CmsDocumentService.Find(pk).title;
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) title
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 161,
        list = objArray
      });
    }
  }
}
