// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Login.ChangePasswdVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
namespace stockadmin.ViewModels.Login
{
  public class ChangePasswdVm
  {
    public string LoginProvider { get; set; }

    public string ProviderKey { get; set; }

    public string NewPassword { get; set; }

    public string confirmPassword { get; set; }
  }
}
