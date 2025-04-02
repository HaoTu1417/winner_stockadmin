// Decompiled with JetBrains decompiler
// Type: Models.Dto.MemberDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class MemberDto
  {
    public int? admin_user_fk { get; set; }

    public int pk { get; set; }

    public int id { get; set; }

    public string account { get; set; }

    public string nickname { get; set; }

    public string real_name { get; set; }

    public string email { get; set; }

    public string mobile_country { get; set; }

    public string mobile { get; set; }

    public string passwd { get; set; }

    public string token { get; set; }

    public string sub_account { get; set; }

    public string paywd { get; set; }

    public string id_card { get; set; }

    public int id_card_type { get; set; }

    public int id_auth { get; set; }

    public bool status { get; set; }

    public bool is_del { get; set; }

    public DateTime create_time { get; set; }

    public string create_ip { get; set; }

    public DateTime? last_login_time { get; set; }

    public string last_login_ip { get; set; }

    public string urgent_name { get; set; }

    public int urgent_mobile { get; set; }

    public DateTime? auth_time { get; set; }

    public string auth_result { get; set; }

    public string head_img { get; set; }

    public string card_pic_front { get; set; }

    public string card_pic_back { get; set; }

    public string card_pic_hand { get; set; }

    public string invitation_code { get; set; }

    public string recommend { get; set; }

    public int recommend_id { get; set; }

    public string recommend_name { get; set; }

    public int card_pic { get; set; }

    public string level_id { get; set; }

    public string remark { get; set; }

    public string country { get; set; }

    public string time_zone { get; set; }

    public string lang { get; set; }

    public bool sms_status { get; set; }

    public bool email_status { get; set; }

    public bool is_test_account { get; set; }

    public string trial_rate { get; set; }

    public string free_rate { get; set; }

    public string day_rate { get; set; }

    public string week_rate { get; set; }

    public string month_rate { get; set; }

    public string vip_rate { get; set; }

    public string richbox_rate { get; set; }

    public string need_withdraw_selfie { get; set; }
  }
}
