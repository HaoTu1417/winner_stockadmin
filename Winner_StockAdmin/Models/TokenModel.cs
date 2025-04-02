// Decompiled with JetBrains decompiler
// Type: stockadmin.Models.TokenModel
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

#nullable enable
namespace stockadmin.Models
{
    public class TokenModel
    {
        public string sub_account { get; set; }

        public int status { get; set; }

        public int member_fk { get; set; }

        public string ip { get; set; }

        public string device { get; set; }

        public string lang { get; set; }

        public string time_zone { get; set; }

        public string market { get; set; }
    }
}