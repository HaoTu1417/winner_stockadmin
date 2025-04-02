// Decompiled with JetBrains decompiler
// Type: Models.Dto.AppLogoDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

#nullable enable
namespace Models.Dto
{
    public class AppLogoDto
    {
        public int cms_files_fk { get; set; }

        public bool enable { get; set; }

        public int sort { get; set; }

        public int type { get; set; }

        public List<SelectListItem> types { get; set; }

        public string url { get; set; }

        public string lang { get; set; }

        public string image_url { get; set; }

        public IFormFile image { get; set; }
    }
}