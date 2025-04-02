// Decompiled with JetBrains decompiler
// Type: Models.Dto.StockOptionRecordDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class StockOptionRecordDto
  {
    public int pk { get; set; }

    public int member_fk { get; set; }

    public string market { get; set; } = "";

    public int stock_option_fk { get; set; }

    public string stock_code { get; set; }

    public int type { get; set; }

    public Decimal price { get; set; }

    public int quantity { get; set; }

    public Decimal total { get; set; }

    public int status { get; set; }

    public int admin_user_fk { get; set; }

    public DateTime create_time { get; set; }

    public DateTime review_time { get; set; }

    public string reject_result { get; set; }
  }
}
