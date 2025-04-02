// Decompiled with JetBrains decompiler
// Type: Models.Dto.CmsBulletinDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Http;
using System;

#nullable enable
namespace Models.Dto
{
  public class CmsBulletinDto
  {
    public int pk { get; set; }

    public string lang { get; set; }

    public string title { get; set; }

    public int sort { get; set; }

    public bool on_active { get; set; }

    public int view { get; set; }

    public bool trash { get; set; }

    public DateTime starttime { get; set; } = DateTime.UtcNow;

    public DateTime endtime { get; set; } = DateTime.UtcNow;

    public string topic_content { get; set; }

    public string? img_url { get; set; }

    public IFormFile? img_file { get; set; }

    public string summary { get; set; }

    public bool outsite { get; set; }

    public string url { get; set; }
  }
}
