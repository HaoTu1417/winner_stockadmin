// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.AdminRole.AdminRoleList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

#nullable enable
namespace stockadmin.ViewModels.AdminRole
{
    public class AdminRoleList
    {
        public int pk { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int status { get; set; }

        public bool is_super { get; set; }
    }
}