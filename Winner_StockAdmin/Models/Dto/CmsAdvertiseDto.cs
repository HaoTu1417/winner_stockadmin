// Decompiled with JetBrains decompiler
// Type: Models.Dto.CmsAdvertiseDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

#nullable enable
namespace Models.Dto
{
  public class CmsAdvertiseDto
  {
    public int cms_files_fk { get; set; }

    public bool enable { get; set; }

    public int sort { get; set; }

    public string url { get; set; }

    public int size { get; set; }

    public List<SelectListItem> sizes { get; set; }

    public string lang { get; set; }

    public string hyperlink { get; set; }

    public IFormFile image { get; set; }

    public string watermark { get; set; } = "";

    public int watermark_size { get; set; }

    public int watermark_color { get; set; }

    public List<SelectListItem> watermark_colors { get; set; }

    public List<SelectListItem> watermark_sizes { get; set; }
  }
}
