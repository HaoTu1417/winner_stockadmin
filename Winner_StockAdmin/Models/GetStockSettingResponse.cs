// Decompiled with JetBrains decompiler
// Type: stockadmin.Models.GetStockSettingResponse
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System;

#nullable disable
namespace stockadmin.Models
{
    public class GetStockSettingResponse
    {
        public Decimal us_min_stock_price { get; set; }

        public int us_min_stock_month_volume { get; set; }

        public Decimal vn_min_stock_price { get; set; }

        public int vn_min_stock_month_volume { get; set; }
    }
}