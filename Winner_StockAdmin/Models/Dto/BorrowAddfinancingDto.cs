// Decompiled with JetBrains decompiler
// Type: Models.Dto.BorrowAddfinancingDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
    public class BorrowAddfinancingDto
    {
        public string sub_account { get; set; }

        public int borrow_fk { get; set; }

        public int member_fk { get; set; }

        public int pk { get; set; }

        public string currency { get; set; }

        public Decimal money { get; set; }

        public Decimal exchange { get; set; }

        public Decimal freeze { get; set; }

        public Decimal multiple { get; set; }

        public Decimal borrow_interest { get; set; }

        public Decimal last_deposit_money { get; set; }

        public Decimal last_borrow_money { get; set; }

        public int status { get; set; }

        public DateTime add_time { get; set; }

        public DateTime verify_time { get; set; }

        public int target_uid { get; set; }

        public string target_name { get; set; }

        public Decimal coupon { get; set; }
    }
}