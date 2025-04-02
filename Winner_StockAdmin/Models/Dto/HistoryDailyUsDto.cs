// Decompiled with JetBrains decompiler
// Type: Models.Dto.HistoryDailyUsDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
namespace Models.Dto
{
  public class HistoryDailyUsDto
  {
    public int pk { get; set; }

    public string date { get; set; }

    public string stock_code { get; set; }

    public double open { get; set; }

    public double high { get; set; }

    public double low { get; set; }

    public double close { get; set; }

    public int volume { get; set; }
  }
}
