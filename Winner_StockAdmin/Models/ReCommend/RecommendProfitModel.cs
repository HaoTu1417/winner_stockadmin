// Decompiled with JetBrains decompiler
// Type: stockadmin.Models.ReCommend.RecommendProfitModel
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System;

#nullable enable
namespace stockadmin.Models.ReCommend
{
    public class RecommendProfitModel
    {
        public int org { get; set; }

        public DateTime dt { get; set; }

        public string yymm { get; set; }

        public double money { get; set; }

        public int borrow_fee_fk { get; set; }

        public string currency { get; set; }
    }
}