// Decompiled with JetBrains decompiler
// Type: Models.Dto.CmsQuestionCategoryDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Http;

#nullable enable
namespace Models.Dto
{
  public class CmsQuestionCategoryDto
  {
    public int pk { get; set; }

    public bool enable { get; set; }

    public string label { get; set; }

    public string icon { get; set; }

    public int sort { get; set; }

    public string lang { get; set; }

    public IFormFile image { get; set; }
  }
}
