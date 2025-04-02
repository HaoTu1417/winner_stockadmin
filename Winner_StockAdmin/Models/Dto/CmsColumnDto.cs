// Decompiled with JetBrains decompiler
// Type: Models.Dto.CmsColumnDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
namespace Models.Dto
{
  public class CmsColumnDto
  {
    public int pk { get; set; }

    public int pid { get; set; }

    public string name { get; set; }

    public int model { get; set; }

    public string url { get; set; }

    public string target { get; set; }

    public string content { get; set; }

    public string icon { get; set; }

    public string index_template { get; set; }

    public string list_template { get; set; }

    public string detail_template { get; set; }

    public int post_auth { get; set; }

    public int sort { get; set; }

    public int status { get; set; }

    public int hide { get; set; }

    public int rank_auth { get; set; }

    public int type { get; set; }
  }
}
