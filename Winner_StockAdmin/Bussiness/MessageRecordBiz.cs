// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.MessageRecordBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Cache;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.Home;
using stockadmin.ViewModels.MessageRecord;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class MessageRecordBiz
  {
    public static DataCountBase<MessageRecordList> GetMessageRecordList(
      MessageRecordFilter? filter,
      int page,
      int pageSize)
    {
      string str = SqlTool.Build<MessageRecordFilter>(filter).Must("classify = 2").Must("receiver_table = 2");
      if (filter.filter_out_test_account)
        str = str.Must("member.is_test_account = 0");
      DataCountBase<MessageRecordList> messageRecordList = MessageRecordService.FindMessageRecordList(page, pageSize, str);
      return new DataCountBase<MessageRecordList>(messageRecordList.count, messageRecordList.data.Select<MessageRecordList, MessageRecordList>((Func<MessageRecordList, MessageRecordList>) (messageRecord => PublicTool.convertUtcToLocalTime<MessageRecordList>(messageRecord))));
    }

    public static MessageRecordDto Get(int pk) => MessageRecordService.Find(pk);

    public static void PostCreate(MessageRecordDto req, AdminSession adminUser)
    {
      try
      {
        SendMessageLib.Send(req.receiver_fk, req.title, req.info, 2);
        object[] objArray = new object[3]
        {
          (object) adminUser.account,
          (object) adminUser.nickName,
          (object) req.title
        };
        AdminLogLib.Save(new AdminLogRequest()
        {
          admin_user_pk = adminUser.pk,
          admin_menu_fk = 85,
          list = objArray,
          member_account = MemberService.Find(req.receiver_fk).account
        });
      }
      catch (Exception ex)
      {
        throw new AppException("傳送站內信失敗");
      }
    }

    public static void PostEdit(MessageRecordDto req, AdminSession adminUser)
    {
      if (MessageRecordService.UpdateFull(req) == 0)
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
        admin_menu_fk = 87,
        list = objArray
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      MessageRecordService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) pk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 86,
        list = objArray
      });
    }

    public static MessageRecordEditVm GetEditVm(int pk)
    {
      MessageRecordEditVm messageRecordEditVm = MessageRecordService.FindMessageRecordEditVm(pk);
      MessageRecordBiz.UpdateMessageRecordUnread();
      return messageRecordEditVm;
    }

    public static MessageRecordEditVm GetAppendVm(int member)
    {
      MemberDto memberDto = MemberService.Find(member);
      return new MessageRecordEditVm()
      {
        receiver_fk = memberDto.pk,
        account = memberDto.account
      };
    }

    public static void UpdateMessageRecordUnread()
    {
      long unreadMessages = MessageRecordService.GetUnreadMessages();
      CacheQuery.SelectDB(CacheEnum.admin);
      HomeVm redisValue = CacheQuery.StringGet<HomeVm>("HomeVm");
      if (redisValue == null)
        return;
      redisValue.MessageRecordUnread = unreadMessages.ToString();
      CacheQuery.StringSet<HomeVm>("HomeVm", redisValue);
    }
  }
}
