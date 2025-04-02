// Decompiled with JetBrains decompiler
// Type: Models.Dto.TradeMoneyRecordDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class TradeMoneyRecordDto
  {
    public int member_fk { get; set; }

    public string sub_account { get; set; }

    public int? trade_deal_fk { get; set; }

    public int pk { get; set; }

    public string sn { get; set; }

    public int temp_id { get; set; }

    public int op { get; set; }

    public string currency { get; set; }

    public Decimal balance { get; set; }

    public Decimal affect { get; set; }

    public Decimal exchange { get; set; }

    public Decimal wallet_amount { get; set; }

    public string info { get; set; }

    public string reviewer { get; set; }

    public DateTime create_datetime { get; set; }

    public string market { get; set; }

    public int? order_type { get; set; }

    public string? stock_code { get; set; }

    public string? stock_name { get; set; }

    public string? param { get; set; }
  }
}
