// Decompiled with JetBrains decompiler
// Type: Models.Dto.CmsSupportDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
namespace Models.Dto
{
  public class CmsSupportDto
  {
    public int pk { get; set; }

    public string lang { get; set; }

    public string svc_phone { get; set; }

    public string svc_workday { get; set; }

    public string svc_nonworkday { get; set; }

    public string svc_email { get; set; }

    public string svc_link { get; set; }
  }
}
