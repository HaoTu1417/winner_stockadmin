// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.ExchangeLib
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using stockadmin.Services;
using System;

#nullable enable
namespace stockadmin.Libs
{
    public class ExchangeLib
    {
        public static Decimal GetRate(string currency_symbol, string base_symbol)
        {
            if (currency_symbol == "USDT")
                currency_symbol = "USD";
            if (base_symbol == "USDT")
                base_symbol = "USD";
            Decimal num = 1M;
            if (currency_symbol == "KVND")
            {
                currency_symbol = "VND";
                num *= 1000M;
            }
            if (base_symbol == "KVND")
            {
                base_symbol = "VND";
                num /= 1000M;
            }
            return !currency_symbol.Equals(base_symbol) ? ViewExchangeRateService.GetViewExchangeRate(currency_symbol, base_symbol).inward_rate * num : 1M;
        }

        public static Decimal Convert(Decimal amount, string currency_symbol, string base_symbol)
        {
            Decimal rate = ExchangeLib.GetRate(currency_symbol, base_symbol);
            return amount * rate;
        }
    }
}