// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradeAccount.TradeAccountSearchList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.ViewModels.TradeAccount
{
  public class TradeAccountSearchList
  {
    public string? sub_account { get; set; }

    public byte status { get; set; }

    public byte? type { get; set; }

    public string? member_name { get; set; }

    public string? member_username { get; set; }

    public string? member_name_username => this.member_name + "<br>" + this.member_username;

    public string? member_mobile { get; set; }

    public string? loan_type { get; set; }

    public string? market { get; set; }

    public string? currency { get; set; }

    public string? market_currency => this.market + "<br>" + this.currency;

    public DateTime? begin_time { get; set; }

    public DateTime? end_time { get; set; }

    public string? begin_end_time
    {
      get
      {
        if (!this.end_time.HasValue || !(this.end_time.Value.AddDays(1.0) > DateTime.Now))
        {
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
          interpolatedStringHandler.AppendFormatted<DateTime?>(this.begin_time);
          interpolatedStringHandler.AppendLiteral("<br>");
          interpolatedStringHandler.AppendFormatted<DateTime?>(this.end_time);
          return interpolatedStringHandler.ToStringAndClear();
        }
        DefaultInterpolatedStringHandler interpolatedStringHandler1 = new DefaultInterpolatedStringHandler(29, 2);
        interpolatedStringHandler1.AppendFormatted<DateTime?>(this.begin_time);
        interpolatedStringHandler1.AppendLiteral("<br><font color='red'>");
        interpolatedStringHandler1.AppendFormatted<DateTime?>(this.end_time);
        interpolatedStringHandler1.AppendLiteral("</font>");
        return interpolatedStringHandler1.ToStringAndClear();
      }
    }

    public Decimal loan_money { get; set; }

    public Decimal margin { get; set; }

    public string? loan_money_margin
    {
      get
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
        interpolatedStringHandler.AppendFormatted<Decimal>(this.loan_money);
        interpolatedStringHandler.AppendLiteral("<br>");
        interpolatedStringHandler.AppendFormatted<Decimal>(this.margin);
        return interpolatedStringHandler.ToStringAndClear();
      }
    }

    public Decimal? total { get; set; }

    public Decimal mem_money { get; set; }

    public Decimal frozen_money { get; set; }

    public string? mem_money_frozen_money
    {
      get
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
        interpolatedStringHandler.AppendFormatted<Decimal>(this.mem_money);
        interpolatedStringHandler.AppendLiteral("<br>");
        interpolatedStringHandler.AppendFormatted<Decimal>(this.frozen_money);
        return interpolatedStringHandler.ToStringAndClear();
      }
    }

    public Decimal? assets
    {
      get
      {
        Decimal? total = this.total;
        Decimal memMoney = this.mem_money;
        return !total.HasValue ? new Decimal?() : new Decimal?(total.GetValueOrDefault() + memMoney);
      }
    }

    public Decimal? warningline { get; set; }

    public Decimal? warningline_distance
    {
      get
      {
        Decimal? assets = this.assets;
        Decimal? warningline = this.warningline;
        return !(assets.HasValue & warningline.HasValue) ? new Decimal?() : new Decimal?(assets.GetValueOrDefault() - warningline.GetValueOrDefault());
      }
    }

    public string? warningline_warningline_distance
    {
      get
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
        interpolatedStringHandler.AppendFormatted<Decimal?>(this.warningline);
        interpolatedStringHandler.AppendLiteral("<br>");
        interpolatedStringHandler.AppendFormatted<Decimal?>(this.warningline_distance);
        return interpolatedStringHandler.ToStringAndClear();
      }
    }

    public Decimal? breakline { get; set; }

    public Decimal? breakline_distance
    {
      get
      {
        Decimal? assets = this.assets;
        Decimal? breakline = this.breakline;
        return !(assets.HasValue & breakline.HasValue) ? new Decimal?() : new Decimal?(assets.GetValueOrDefault() - breakline.GetValueOrDefault());
      }
    }

    public string? breakline_breakline_distance
    {
      get
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
        interpolatedStringHandler.AppendFormatted<Decimal?>(this.breakline);
        interpolatedStringHandler.AppendLiteral("<br>");
        interpolatedStringHandler.AppendFormatted<Decimal?>(this.breakline_distance);
        return interpolatedStringHandler.ToStringAndClear();
      }
    }
  }
}
