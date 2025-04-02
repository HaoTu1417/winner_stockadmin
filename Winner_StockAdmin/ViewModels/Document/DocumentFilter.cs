// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Document.DocumentFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.Document
{
  public class DocumentFilter
  {
    [Where("=", "cms_document.pk")]
    public int? pk { get; set; }

    [Where("LIKE", "cms_document.cid")]
    public string? cid { get; set; }

    [Where("=", "cms_document.lang")]
    public string? lang { get; set; }

    [Where("LIKE", "cms_document.title")]
    public string? title { get; set; }
  }
}
