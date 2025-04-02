// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.AdminBank.AdminBankFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.AdminBank
{
  public class AdminBankFilter
  {
    [Where("=", "type")]
    public int? type { get; set; }

    [Where("=", "currency")]
    public string? currency { get; set; }

    [Where("LIKE", "card")]
    public string? card { get; set; }
  }
}
