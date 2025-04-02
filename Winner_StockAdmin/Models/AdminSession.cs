// Decompiled with JetBrains decompiler
// Type: stockadmin.Models.AdminSession
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

#nullable enable
namespace stockadmin.Models
{
    public class AdminSession
    {
        public int pk { get; set; }

        public int role { get; set; }

        public bool is_super { get; set; }

        public string account { get; set; }

        public string nickName { get; set; }

        public int avatar { get; set; }

        public string lang { get; set; }

        public bool change_password { get; set; }

        public bool enable_mfa { get; set; }

        public int invitation_code { get; set; }
    }
}