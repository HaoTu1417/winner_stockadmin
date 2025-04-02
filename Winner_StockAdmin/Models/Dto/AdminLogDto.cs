// Decompiled with JetBrains decompiler
// Type: Models.Dto.AdminLogDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
    public class AdminLogDto
    {
        public int pk { get; set; }

        public int admin_action { get; set; }

        public int admin_user { get; set; }

        public string table_name { get; set; }

        public string table_index { get; set; }

        public string action_ip { get; set; }

        public string param { get; set; }

        public string remark { get; set; }

        public DateTime create_time { get; set; }

        public string member_account { get; set; }
    }
}