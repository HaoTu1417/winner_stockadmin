// Decompiled with JetBrains decompiler
// Type: Models.Dto.CmsDocumentDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
namespace Models.Dto
{
  public class CmsDocumentDto
  {
    public int pk { get; set; }

    public string cid { get; set; }

    public string lang { get; set; }

    public string title { get; set; }

    public string content { get; set; }

    public string flag { get; set; }

    public int view { get; set; }

    public int comment { get; set; }

    public int good { get; set; }

    public int bad { get; set; }

    public int mark { get; set; }

    public int sort { get; set; }

    public bool status { get; set; }

    public bool trash { get; set; }
  }
}
