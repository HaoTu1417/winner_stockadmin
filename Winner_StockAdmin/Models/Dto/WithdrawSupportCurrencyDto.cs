// Decompiled with JetBrains decompiler
// Type: Models.Dto.WithdrawSupportCurrencyDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
namespace Models.Dto
{
  public class WithdrawSupportCurrencyDto
  {
    public string pk { get; set; }

    public string code { get; set; }

    public string currency { get; set; }

    public int type { get; set; }

    public bool enable { get; set; }

    public string type_str => this.type == 1 ? "銀行" : "加密貨幣";
  }
}
