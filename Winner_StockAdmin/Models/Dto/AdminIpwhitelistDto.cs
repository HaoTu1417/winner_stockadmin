// Decompiled with JetBrains decompiler
// Type: Models.Dto.AdminIpwhitelistDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
    public class AdminIpwhitelistDto
    {
        public string ip { get; set; }

        public string remarks { get; set; }

        public string account { get; set; }

        public int status { get; set; }

        public DateTime create_time { get; set; } = DateTime.UtcNow;

        public DateTime update_time { get; set; } = DateTime.UtcNow;
    }
}