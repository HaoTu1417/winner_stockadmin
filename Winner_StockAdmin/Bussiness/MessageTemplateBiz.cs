// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.MessageTemplateBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.MessageTemplate;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class MessageTemplateBiz
  {
    public static DataCountBase<MessageTemplateList> GetMessageTemplateList(
      MessageTemplateFilter? filter,
      int page,
      int pageSize)
    {
      string whereSql = SqlTool.Build<MessageTemplateFilter>(filter);
      DataCountBase<MessageTemplateList> messageTemplateList = MessageTemplateService.FindMessageTemplateList(page, pageSize, whereSql);
      return new DataCountBase<MessageTemplateList>(messageTemplateList.count, messageTemplateList.data.Select<MessageTemplateList, MessageTemplateList>((Func<MessageTemplateList, MessageTemplateList>) (messageTemplate => PublicTool.convertUtcToLocalTime<MessageTemplateList>(messageTemplate))));
    }

    public static MessageTemplateDto Get(int pk) => MessageTemplateService.Find(pk);

    public static void PostCreate(MessageTemplateDto req, AdminSession adminUser)
    {
      if (MessageTemplateService.FindPkAfterInsert(req) == 0)
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
        admin_menu_fk = 33,
        list = objArray
      });
    }

    public static void PostEdit(MessageTemplateDto req, AdminSession adminUser)
    {
      if (MessageTemplateService.UpdateFull(req) == 0)
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
        admin_menu_fk = 31,
        list = objArray
      });
    }

    public static void Delete(int pk) => MessageTemplateService.Remove(pk);
  }
}
