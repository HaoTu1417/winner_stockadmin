// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RichboxBook.RichboxBookFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.RichboxBook
{
  public class RichboxBookFilter
  {
    [Where("=", "member.account")]
    public string? account { get; set; }

    [Where("LIKE", "member.real_name")]
    public string? real_name { get; set; }

    public bool filter_out_test_account { get; set; }
  }
}
