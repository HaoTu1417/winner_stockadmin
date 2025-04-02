// Decompiled with JetBrains decompiler
// Type: Models.Dto.StockCnDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class StockCnDto
  {
    public string stock_code { get; set; }

    public string stock_name { get; set; }

    public string market { get; set; }

    public bool enable { get; set; }

    public bool disable_alwayse { get; set; }

    public int close_reason { get; set; }

    public string opentrade { get; set; }

    public DateTime update_datetime { get; set; }

    public Decimal yclose { get; set; }

    public Decimal limitbuy { get; set; }

    public Decimal limitsell { get; set; }

    public Decimal final_price { get; set; }

    public int volume { get; set; }

    public string full_info { get; set; }
  }
}
