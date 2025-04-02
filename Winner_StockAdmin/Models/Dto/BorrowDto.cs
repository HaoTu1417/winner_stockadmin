// Decompiled with JetBrains decompiler
// Type: Models.Dto.BorrowDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
    public class BorrowDto
    {
        public string sub_account { get; set; }

        public int borrow_plan_fk { get; set; }

        public int member_fk { get; set; }

        public int agent_fk { get; set; }

        public int pk { get; set; }

        public string order_id { get; set; }

        public int status { get; set; }

        public string market { get; set; }

        public string borrow_type { get; set; }

        public string currency { get; set; }

        public Decimal deposit_money { get; set; }

        public Decimal init_money { get; set; }

        public int multiple { get; set; }

        public bool auto_renewal { get; set; }

        public Decimal borrow_money { get; set; }

        public Decimal borrow_interest { get; set; }

        public int repayment_type { get; set; }

        public int borrow_duration { get; set; }

        public int position { get; set; }

        public Decimal rate { get; set; }

        public int total { get; set; }

        public bool trading_time { get; set; }

        public int loss_warn_sms_send { get; set; }

        public Decimal stock_money { get; set; }

        public Decimal total_coupon { get; set; }

        public Decimal total_fee { get; set; }

        public Decimal total_interest { get; set; }

        public DateTime create_time { get; set; }

        public DateTime begin_time { get; set; }

        public DateTime end_time { get; set; }

        public DateTime verify_time { get; set; }
    }
}