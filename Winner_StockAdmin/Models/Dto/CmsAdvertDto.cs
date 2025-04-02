// Decompiled with JetBrains decompiler
// Type: Models.Dto.CmsAdvertDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
    public class CmsAdvertDto
    {
        public int pk { get; set; }

        public int typeid { get; set; }

        public string tagname { get; set; }

        public int ad_type { get; set; }

        public int timeset { get; set; }

        public DateTime start_time { get; set; }

        public DateTime end_time { get; set; }

        public string name { get; set; }

        public string content { get; set; }

        public string expcontent { get; set; }

        public int status { get; set; }

        public int bnr_id { get; set; }

        public int marq_id { get; set; }

        public string pop_msg { get; set; }

        public bool show_pop { get; set; }

        public string lang { get; set; }
    }
}