// Decompiled with JetBrains decompiler
// Type: Models.Dto.AdminAttachmentDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/www/service/stockadmin/stockadmin.dll

#nullable enable
namespace Models.Dto
{
    public class AdminAttachmentDto
    {
        public int member_fk { get; set; }

        public int pk { get; set; }

        public string name { get; set; }

        public string module { get; set; }

        public string path { get; set; }

        public string thumb { get; set; }

        public string url { get; set; }

        public string mime { get; set; }

        public string ext { get; set; }

        public int size { get; set; }

        public string md5 { get; set; }

        public string sha1 { get; set; }

        public string driver { get; set; }

        public int download { get; set; }

        public int sort { get; set; }

        public int status { get; set; }
    }
}