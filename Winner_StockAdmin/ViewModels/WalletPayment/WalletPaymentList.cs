// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.WalletPayment.WalletPaymentList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.WalletPayment
{
  public class WalletPaymentList
  {
    public int pk { get; set; }

    public bool status { get; set; }

    public string pay_name { get; set; }

    public string pay_code { get; set; }

    public Decimal total_amount { get; set; }

    public string viplists { get; set; }
  }
}
