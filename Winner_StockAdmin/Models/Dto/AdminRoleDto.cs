// Decompiled with JetBrains decompiler
// Type: Models.Dto.AdminRoleDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

#nullable enable
namespace Models.Dto
{
    public class AdminRoleDto
    {
        public int admin_module_fk { get; set; }

        public int pk { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int model { get; set; }

        public string admin_menu { get; set; }

        public int sort { get; set; }

        public bool status { get; set; }

        public bool lock_delete { get; set; }

        public bool is_super { get; set; }
    }
}