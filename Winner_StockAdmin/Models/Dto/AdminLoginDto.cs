// Decompiled with JetBrains decompiler
// Type: Models.Dto.AdminLoginDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/www/service/stockadmin/stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
    public class AdminLoginDto
    {
        public int pk { get; set; }

        public string login_account { get; set; }

        public string ip { get; set; }

        public string ip_country { get; set; }

        public string device { get; set; }

        public DateTime create_time { get; set; }

        public bool status { get; set; }

        public string remark { get; set; }
    }
}