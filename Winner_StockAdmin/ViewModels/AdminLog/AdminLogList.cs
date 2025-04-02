// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.AdminLog.AdminLogList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.AdminLog
{
  public class AdminLogList
  {
    public int pk { get; set; }

    public DateTime create_time { get; set; }

    public string account { get; set; }

    public string nickname { get; set; }

    public string remark { get; set; }

    public string action_ip { get; set; }

    public string member_account { get; set; }
  }
}
