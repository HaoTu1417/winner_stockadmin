// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.AdminUser.AdminUserList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.AdminUser
{
  public class AdminUserList
  {
    public int pk { get; set; }

    public string account { get; set; }

    public string nickname { get; set; }

    public string name { get; set; }

    public bool status { get; set; }

    public bool is_admin { get; set; }

    public int sort { get; set; }

    public string lang { get; set; }

    public bool is_super { get; set; }

    public bool is_delete { get; set; }

    public DateTime last_login_time { get; set; }
  }
}
