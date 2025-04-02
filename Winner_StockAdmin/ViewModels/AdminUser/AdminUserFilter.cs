// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.AdminUser.AdminUserFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.AdminUser
{
  public class AdminUserFilter
  {
    [Where("=", "account")]
    public string? account { get; set; }

    [Where("=", "role")]
    public int? role { get; set; }

    [Where("LIKE", "nickname")]
    public string? nickname { get; set; }
  }
}
