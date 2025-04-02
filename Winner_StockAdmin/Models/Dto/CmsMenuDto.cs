// Decompiled with JetBrains decompiler
// Type: Models.Dto.CmsMenuDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
namespace Models.Dto
{
  public class CmsMenuDto
  {
    public int pk { get; set; }

    public int nid { get; set; }

    public int pid { get; set; }

    public int column { get; set; }

    public int page { get; set; }

    public int type { get; set; }

    public string title { get; set; }

    public string url { get; set; }

    public string css { get; set; }

    public string rel { get; set; }

    public string target { get; set; }

    public int sort { get; set; }

    public int status { get; set; }
  }
}
