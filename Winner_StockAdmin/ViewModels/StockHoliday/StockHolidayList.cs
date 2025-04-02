// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.StockHoliday.StockHolidayList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using System.ComponentModel.DataAnnotations;

#nullable enable
namespace stockadmin.ViewModels.StockHoliday
{
  public class StockHolidayList
  {
    public int pk { get; set; }

    public string market { get; set; }

    public string name { get; set; }

    public int year { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime date { get; set; }

    public bool is_allday { get; set; }

    [DisplayFormat(DataFormatString = "{0:hh:mm:ss}")]
    public DateTime? open { get; set; }

    [DisplayFormat(DataFormatString = "{0:hh:mm:ss}")]
    public DateTime? close { get; set; }
  }
}
