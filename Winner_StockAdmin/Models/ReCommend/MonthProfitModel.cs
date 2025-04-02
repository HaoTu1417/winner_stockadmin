// Decompiled with JetBrains decompiler
// Type: stockadmin.Models.ReCommend.MonthProfitModel
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System;

#nullable disable
namespace stockadmin.Models.ReCommend
{
    public class MonthProfitModel
    {
        public int generation { get; set; }

        public int monthly_members { get; set; }

        public Decimal monthly_borrow_fee { get; set; }

        public Decimal monthly_reward { get; set; }
    }
}