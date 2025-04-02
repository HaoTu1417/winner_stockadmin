// Decompiled with JetBrains decompiler
// Type: stockadmin.Models.Dto.VwExchangeRateDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System;

#nullable enable
namespace stockadmin.Models.Dto
{
    public class VwExchangeRateDto
    {
        public int pk { get; set; }

        public string date { get; set; }

        public string currency_symbol { get; set; }

        public string base_symbol { get; set; }

        public Decimal inward_rate { get; set; }

        public Decimal outward_rate { get; set; }

        public DateTime create_time { get; set; }
    }
}