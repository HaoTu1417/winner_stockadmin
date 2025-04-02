// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradeMoneyRecord.TradeMoneyRecordFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.TradeMoneyRecord
{
  public class TradeMoneyRecordFilter
  {
    [Where("LIKE", "trade_money_record.sub_account")]
    public string? sub_account { get; set; }

    [Where(">=", ".begin_time")]
    public DateTime? begin_time { get; set; }

    [Where("<", ".end_time")]
    public DateTime? end_time { get; set; }

    [Where("LIKE", "trade_money_record.sn")]
    public string? sn { get; set; }

    [Where("=", "trade_money_record.temp_id")]
    public int? temp_id { get; set; }
  }
}
