// Decompiled with JetBrains decompiler
// Type: Models.Dto.SysCountryDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Http;

#nullable enable
namespace Models.Dto
{
  public class SysCountryDto
  {
    public string pk { get; set; }

    public string label { get; set; }

    public bool enable { get; set; }

    public string lang { get; set; }

    public string currency { get; set; }

    public string flag { get; set; }

    public IFormFile flag_file { get; set; }

    public string code { get; set; }
  }
}
