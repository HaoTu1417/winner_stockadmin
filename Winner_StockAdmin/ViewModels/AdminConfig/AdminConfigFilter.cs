// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.AdminConfig.AdminConfigFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.AdminConfig
{
  public class AdminConfigFilter
  {
    [Where("LIKE", "admin_config.name")]
    public string? name { get; set; }

    [Where("LIKE", "admin_config.title")]
    public string? title { get; set; }
  }
}
