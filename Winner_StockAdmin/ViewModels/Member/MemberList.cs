// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Member.MemberList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using System.ComponentModel;

#nullable enable
namespace stockadmin.ViewModels.Member
{
  public class MemberList
  {
    [DisplayName("邮箱")]
    public string email { get; set; }

    [DisplayName("电话号码")]
    public string mobile_number { get; set; }

    public int admin_user_fk { get; set; }

    [DisplayName("会员帐号")]
    public string account { get; set; }

    [DisplayName("昵称")]
    public string nickname { get; set; }

    [DisplayName("会员姓名")]
    public string real_name { get; set; }

    [DisplayName("推荐人邀请码")]
    public string recommend_code { get; set; }

    [DisplayName("推荐人帐号")]
    public string recommend_id { get; set; }

    [DisplayName("注册时间")]
    public DateTime create_time { get; set; }

    [DisplayName("最后登录时间")]
    public DateTime last_login_time { get; set; }

    [DisplayName("最后登录ip")]
    public string last_login_ip { get; set; }

    [DisplayName("备注内容")]
    public string remark { get; set; }

    [DisplayName("服务人員")]
    public string admin_user_name { get; set; }

    public int pk { get; set; }

    public string lang { get; set; }

    public int status { get; set; }

    public string invitation_code { get; set; }

    public string level_id { get; set; }

    public string level_id_string
    {
      get
      {
        string levelIdString;
        switch (this.admin_lang.ToUpper())
        {
          case "VN":
            string str1;
            switch (this.level_id)
            {
              case "1":
                str1 = "vàng";
                break;
              case "2":
                str1 = "bạch kim";
                break;
              case "3":
                str1 = "kim cương";
                break;
              default:
                str1 = "nói chung là";
                break;
            }
            levelIdString = str1;
            break;
          case "CN":
            string str2;
            switch (this.level_id)
            {
              case "1":
                str2 = "黄金";
                break;
              case "2":
                str2 = "白金";
                break;
              case "3":
                str2 = "钻石";
                break;
              default:
                str2 = "一般";
                break;
            }
            levelIdString = str2;
            break;
          default:
            string str3;
            switch (this.level_id)
            {
              case "1":
                str3 = "Gold";
                break;
              case "2":
                str3 = "Platium";
                break;
              case "3":
                str3 = "Diamond";
                break;
              default:
                str3 = "Normal";
                break;
            }
            levelIdString = str3;
            break;
        }
        return levelIdString;
      }
    }

    public bool is_del { get; set; }

    public bool is_test_account { get; set; }

    public Decimal richbox_balance { get; set; }

    public Decimal richbox_interest { get; set; }

    public string admin_lang { get; set; }
  }
}
