// Decompiled with JetBrains decompiler
// Type: Models.Dto.BorrowDetailDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System;

#nullable disable
namespace Models.Dto
{
    public class BorrowDetailDto
    {
        public int borrow_fk { get; set; }

        public int member_fk { get; set; }

        public int pk { get; set; }

        public int status { get; set; }

        public Decimal interest { get; set; }

        public Decimal receive_interest { get; set; }

        public int sort_order { get; set; }

        public int total { get; set; }

        public int deadline { get; set; }

        public DateTime repayment_time { get; set; }
    }
}