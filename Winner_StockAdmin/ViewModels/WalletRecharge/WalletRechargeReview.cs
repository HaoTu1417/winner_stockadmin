// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.WalletRecharge.WalletRechargeReview
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.WalletRecharge
{
  public class WalletRechargeReview
  {
    public DateTime create_time { get; set; }

    public string card { get; set; }

    public string bank_name { get; set; }

    public string payee { get; set; }

    public string order_no { get; set; }

    public string line_bank { get; set; }

    public int pk { get; set; }

    public string type { get; set; }

    public string currency { get; set; }

    public Decimal money { get; set; }

    public Decimal exchange { get; set; }

    public Decimal wallet_amount { get; set; }

    public int member_fk { get; set; }

    public string account { get; set; }

    public string nickname { get; set; }

    public string create_ip { get; set; }

    public string form_name { get; set; }

    public string reject_result { get; set; }

    public int admin_user_fk { get; set; }

    public int id_auth { get; set; }

    public int level_id { get; set; }
  }
}
