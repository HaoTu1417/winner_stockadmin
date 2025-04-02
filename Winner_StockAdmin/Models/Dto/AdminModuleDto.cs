// Decompiled with JetBrains decompiler
// Type: Models.Dto.AdminModuleDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

#nullable enable
namespace Models.Dto
{
    public class AdminModuleDto
    {
        public int pk { get; set; }

        public string name { get; set; }

        public string title { get; set; }

        public string icon { get; set; }

        public string description { get; set; }

        public string identifier { get; set; }

        public int system_module { get; set; }

        public int sort { get; set; }

        public int status { get; set; }
    }
}