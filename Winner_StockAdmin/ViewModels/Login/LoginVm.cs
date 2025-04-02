// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Login.LoginVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
namespace stockadmin.ViewModels.Login
{
  public class LoginVm
  {
    public string LoginProvider { get; set; } = string.Empty;

    public string ProviderKey { get; set; } = string.Empty;

    public string? code { get; set; }
  }
}
