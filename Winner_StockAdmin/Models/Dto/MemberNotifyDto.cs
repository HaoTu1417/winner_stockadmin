// Decompiled with JetBrains decompiler
// Type: Models.Dto.MemberNotifyDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable disable
namespace Models.Dto
{
  public class MemberNotifyDto
  {
    public int member_fk { get; set; }

    public int EmailNotify { get; set; }

    public int SiteMessageNotify { get; set; }

    public int AccountAlertNotify { get; set; }

    public int AccountMarginCallNotify { get; set; }

    public int StockTransactionNotify { get; set; }

    public int AccountExpiryNotify { get; set; }

    public int PromotionsNotify { get; set; }

    public int DepositApprovedNotify { get; set; }

    public int WithdrawalApprovedNotify { get; set; }

    public int TradingAccountApprovedNotify { get; set; }
  }
}
