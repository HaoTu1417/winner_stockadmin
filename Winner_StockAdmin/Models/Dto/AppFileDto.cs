// Decompiled with JetBrains decompiler
// Type: Models.Dto.AppFileDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using Microsoft.AspNetCore.Http;
using System;

#nullable enable
namespace Models.Dto
{
    public class AppFileDto
    {
        public int pk { get; set; }

        public string path { get; set; }

        public string code { get; set; } = "";

        public string version { get; set; }

        public int device { get; set; }

        public IFormFile? file { get; set; }

        public bool active { get; set; }

        public DateTime upload_date { get; set; }
    }
}