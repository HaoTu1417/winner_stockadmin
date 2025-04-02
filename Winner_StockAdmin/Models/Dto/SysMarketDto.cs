// Decompiled with JetBrains decompiler
// Type: Models.Dto.SysMarketDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using System.ComponentModel.DataAnnotations;

#nullable enable
namespace Models.Dto
{
  public class SysMarketDto
  {
    public string code { get; set; }

    public string exchange { get; set; }

    public string currency { get; set; }

    public bool enable { get; set; }

    public bool rank_enable { get; set; }

    public string name { get; set; }

    public int sort { get; set; }

    [DisplayFormat(DataFormatString = "{0}", ApplyFormatInEditMode = true)]
    public Decimal buy_fee { get; set; }

    [DisplayFormat(DataFormatString = "{0}", ApplyFormatInEditMode = true)]
    public Decimal sell_fee { get; set; }

    public Decimal min_buy_fee { get; set; }

    public Decimal min_sell_fee { get; set; }

    public string default_stock_code { get; set; }

    public int min_stock_month_volume { get; set; }

    public Decimal min_stock_price { get; set; }

    public bool capital_filter_enable { get; set; }

    public int capital_filter_number { get; set; }
  }
}
