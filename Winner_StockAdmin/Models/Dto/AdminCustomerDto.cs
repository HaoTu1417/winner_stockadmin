// Decompiled with JetBrains decompiler
// Type: Models.Dto.AdminCustomerDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
    public class AdminCustomerDto
    {
        public int pk { get; set; }

        public string customer_name { get; set; }

        public bool enable { get; set; }

        public string appkey { get; set; }

        public string business_code { get; set; }

        public string lang { get; set; }

        public string app_url { get; set; }

        public DateTime contract_start_time { get; set; }

        public DateTime contract_end_time { get; set; }

        public Decimal exange { get; set; }
    }
}