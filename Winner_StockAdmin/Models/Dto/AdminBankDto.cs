// Decompiled with JetBrains decompiler
// Type: Models.Dto.AdminBankDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using Microsoft.AspNetCore.Http;
using System;

#nullable enable
namespace Models.Dto
{
    public class AdminBankDto
    {
        public int pk { get; set; }

        public int type { get; set; }

        public string country { get; set; }

        public string currency { get; set; }

        public string card { get; set; }

        public string SWIFT { get; set; }

        public string bank_name { get; set; }

        public string open_bank { get; set; }

        public string payee { get; set; }

        public Decimal min_recharge { get; set; }

        public string notes { get; set; }

        public bool status { get; set; }

        public string image { get; set; }

        public IFormFile image_file { get; set; }

        public string viplists { get; set; }

        public int bankimgid { get; set; }

        public string fastbtn { get; set; } = "";
    }
}