// Decompiled with JetBrains decompiler
// Type: Models.Dto.BorrowFeeDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
    public class BorrowFeeDto
    {
        public int member_fk { get; set; }

        public string sub_account { get; set; }

        public int borrow_fk { get; set; }

        public int pk { get; set; }

        public int type { get; set; }

        public Decimal borrow_fee { get; set; }

        public Decimal use_coupon { get; set; }

        public Decimal fee_received { get; set; }

        public int borrow_duration { get; set; }

        public DateTime create_time { get; set; }
    }
}