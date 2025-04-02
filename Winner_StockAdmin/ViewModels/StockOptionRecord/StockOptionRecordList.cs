// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.StockOptionRecord.StockOptionRecordList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.StockOptionRecord
{
  public class StockOptionRecordList
  {
    public int pk { get; set; }

    public int member_fk { get; set; }

    public string real_name { get; set; }

    public string market { get; set; } = "";

    public string stock_code { get; set; }

    public string stock_name { get; set; }

    public string account { get; set; }

    public int type { get; set; }

    public string type_str
    {
      get
      {
        if (this.type == 1)
          return "買入";
        return this.type != 2 ? "" : "賣出";
      }
    }

    public Decimal price { get; set; }

    public int quantity { get; set; }

    public Decimal total { get; set; }

    public int status { get; set; }

    public string status_str
    {
      get
      {
        if (this.status == 1)
          return "To be confirmed";
        if (this.status == 2)
          return "Success";
        return this.status == 3 ? "Failed" : "";
      }
    }

    public DateTime create_time { get; set; }

    public DateTime review_time { get; set; }

    public string admin_user { get; set; }

    public string reject_result { get; set; }

    public bool is_test_account { get; set; }
  }
}
