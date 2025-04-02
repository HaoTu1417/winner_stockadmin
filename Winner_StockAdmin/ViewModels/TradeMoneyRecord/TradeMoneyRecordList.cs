// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradeMoneyRecord.TradeMoneyRecordList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.TradeMoneyRecord
{
  public class TradeMoneyRecordList
  {
    public int pk { get; set; }

    public DateTime create_datetime { get; set; }

    public string sub_account { get; set; }

    public string sn { get; set; }

    public int temp_id { get; set; }

    public string temp_name { get; set; }

    public string info { get; set; }

    public Decimal affect { get; set; }

    public Decimal exchange { get; set; }

    public Decimal wallet_amount { get; set; }

    public Decimal balance { get; set; }

    public string template { get; set; }

    public string param { get; set; }
  }
}
