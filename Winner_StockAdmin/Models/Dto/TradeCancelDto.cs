// Decompiled with JetBrains decompiler
// Type: Models.Dto.TradeCancelDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class TradeCancelDto
  {
    public string trade_order_sn { get; set; }

    public string sub_account { get; set; }

    public int pk { get; set; }

    public string sn { get; set; }

    public string market { get; set; }

    public string stock_code { get; set; }

    public string stock_name { get; set; }

    public int request_volume { get; set; }

    public int cancel_volume { get; set; }

    public string order_ip { get; set; }

    public string order_client { get; set; }

    public int cancel_type { get; set; }

    public DateTime cancel_datetime { get; set; }

    public string cancel_by { get; set; }
  }
}
