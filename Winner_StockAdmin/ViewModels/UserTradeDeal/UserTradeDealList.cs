// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.UserTradeDeal.UserTradeDealList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.UserTradeDeal
{
  public class UserTradeDealList
  {
    public int pk { get; set; }

    public string sub_account { get; set; }

    public string deal_id { get; set; }

    public string trade_order_sn { get; set; }

    public string stock_code { get; set; }

    public string stock_name { get; set; }

    public Decimal profit { get; set; }

    public int order_type { get; set; }

    public string order_type_str => TradeConvertEnum.ConvertOrderTypeStatus(this.order_type);

    public int dir { get; set; }

    public string dir_str => TradeConvertEnum.ConvertDirStatus(this.dir);

    public Decimal final_price { get; set; }

    public int final_volume { get; set; }

    public DateTime create_datetime { get; set; }

    public Decimal total_pay { get; set; }

    public Decimal total_cost { get; set; }

    public Decimal coupon { get; set; }
  }
}
