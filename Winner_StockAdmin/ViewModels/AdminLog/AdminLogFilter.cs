// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.AdminLog.AdminLogFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.AdminLog
{
  public class AdminLogFilter
  {
    [Where(">=", "admin_log.create_time")]
    public DateTime? start_time { get; set; }

    [Where("<", "admin_log.create_time")]
    public DateTime? end_time { get; set; }

    [Where("=", "admin_log.pk")]
    public int? pk { get; set; }

    [Where("=", "admin_user.account")]
    public string? account { get; set; }

    [Where("LIKE", "admin_log.remark")]
    public string? remark { get; set; }

    [Where("=", "admin_log.action_ip")]
    public string? action_ip { get; set; }

    [Where("=", "admin_log.member_account")]
    public string? member_account { get; set; }
  }
}
