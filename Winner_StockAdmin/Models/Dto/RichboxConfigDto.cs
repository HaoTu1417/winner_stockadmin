// Decompiled with JetBrains decompiler
// Type: Models.Dto.RichboxConfigDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class RichboxConfigDto
  {
    public uint id { get; set; }

    public bool enable { get; set; }

    public DateTime active_date { get; set; }

    public DateTime diactive_date { get; set; }

    public string currency { get; set; } = "";

    public Decimal min_investment { get; set; }

    public Decimal max_investment { get; set; }

    public Decimal interest_rate { get; set; }

    public Decimal begin_profit { get; set; }

    public TimeSpan closing_time { get; set; }

    public TimeSpan give_interest_time { get; set; }

    public string feature { get; set; } = "";

    public string description { get; set; } = "";

    public string trade_info { get; set; } = "";
  }
}
