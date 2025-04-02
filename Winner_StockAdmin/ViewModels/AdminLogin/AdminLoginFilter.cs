// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.AdminLogin.AdminLoginFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.AdminLogin
{
  public class AdminLoginFilter
  {
    [Where(">=", "admin_login.create_time")]
    public DateTime? begin_time { get; set; }

    [Where("<", "admin_login.create_time")]
    public DateTime? end_time { get; set; }

    [Where("=", "admin_login.login_account")]
    public string? login_account { get; set; }

    [Where("=", "admin_login.ip")]
    public string? ip { get; set; }

    [Where("=", "admin_login.ip_country")]
    public string? ip_country { get; set; }
  }
}
