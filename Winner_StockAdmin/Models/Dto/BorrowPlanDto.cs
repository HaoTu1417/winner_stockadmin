// Decompiled with JetBrains decompiler
// Type: Models.Dto.BorrowPlanDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

#nullable enable
namespace Models.Dto
{
    public class BorrowPlanDto
    {
        public int pk { get; set; }

        public bool enable { get; set; }

        public string borrow_type { get; set; }

        public string market { get; set; }

        public string name { get; set; }

        public string lang { get; set; }

        public string rate { get; set; }

        public double warning_line { get; set; }

        public double break_line { get; set; }

        public string max_proporting { get; set; }

        public bool renewal { get; set; }

        public string use_time { get; set; }

        public double money_range_min { get; set; }

        public double money_range_max { get; set; }

        public double money_range_increase { get; set; }

        public string fastbtn { get; set; }

        public string slogan { get; set; }

        public string note { get; set; }

        public string unique_set { get; set; }

        public int sort { get; set; }
    }
}