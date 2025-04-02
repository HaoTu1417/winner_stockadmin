// Decompiled with JetBrains decompiler
// Type: Models.Dto.WalletPaymentDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class WalletPaymentDto
  {
    public int pk { get; set; }

    public string pay_name { get; set; }

    public string pay_code { get; set; }

    public int min_recharge { get; set; }

    public string pay_type { get; set; }

    public string pay_url { get; set; }

    public string pay_account { get; set; }

    public string pay_tokenkey { get; set; }

    public string pay_Notice_url { get; set; }

    public string pay_Return_url { get; set; }

    public int pay_sort { get; set; }

    public bool status { get; set; }

    public DateTime create_time { get; set; }

    public string notes { get; set; }

    public string viplists { get; set; }

    public string currency { get; set; }

    public string fastbtn { get; set; } = "";
  }
}
