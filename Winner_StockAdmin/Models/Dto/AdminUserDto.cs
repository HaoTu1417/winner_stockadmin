// Decompiled with JetBrains decompiler
// Type: Models.Dto.AdminUserDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
    public class AdminUserDto
    {
        public int pk { get; set; }

        public string account { get; set; }

        public int role { get; set; }

        public string password { get; set; }

        public bool status { get; set; }

        public string nickname { get; set; }

        public bool is_admin { get; set; }

        public string mobile { get; set; }

        public string email { get; set; }

        public int avatar { get; set; }

        public int sort { get; set; }

        public string lang { get; set; }

        public DateTime? last_login_time { get; set; }

        public string? last_login_ip { get; set; }

        public bool change_password { get; set; }

        public string mfa_secret { get; set; }

        public int invitation_code { get; set; }
    }
}