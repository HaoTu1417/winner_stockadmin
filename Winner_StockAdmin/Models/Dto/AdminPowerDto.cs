// Decompiled with JetBrains decompiler
// Type: Models.Dto.AdminPowerDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

#nullable enable
namespace Models.Dto
{
    public class AdminPowerDto
    {
        public int admin_module_fk { get; set; }

        public int pk { get; set; }

        public int parent { get; set; }

        public string title { get; set; }

        public string url_value { get; set; }

        public string icon { get; set; }

        public int sort { get; set; }

        public bool system_menu { get; set; }

        public bool online_hide { get; set; }

        public string url_type { get; set; }

        public string url_target { get; set; }

        public int admin { get; set; }

        public string parameter { get; set; }
    }
}