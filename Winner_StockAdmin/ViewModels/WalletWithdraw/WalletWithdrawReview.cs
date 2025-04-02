// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.WalletWithdraw.WalletWithdrawReview
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.WalletWithdraw
{
  public class WalletWithdrawReview
  {
    public DateTime create_time { get; set; }

    public string order_no { get; set; }

    public Decimal wallet_amount { get; set; }

    public Decimal exchange { get; set; }

    public string currency { get; set; }

    public Decimal money { get; set; }

    public string member_bank_fk { get; set; }

    public int pk { get; set; }

    public string bank_currency { get; set; }

    public bool is_confirm { get; set; }

    public string bank { get; set; }

    public string branch { get; set; }

    public string card { get; set; }

    public string bank_account { get; set; }

    public string account { get; set; }

    public string nickname { get; set; }

    public bool id_auth { get; set; }

    public int admin_user_fk { get; set; }

    public int member_fk { get; set; }

    public int status { get; set; }

    public string reject_result { get; set; }

    public string id_selfie { get; set; }
  }
}
