// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Demo.DemoSearchFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.Demo
{
  public class DemoSearchFilter
  {
    [Where("=", "pk")]
    public int? pk { get; set; }

    [Where("=", "sn")]
    public string? sn { get; set; }

    [Where("like", "sub_account")]
    public string? sub_account { get; set; }

    [Where(">=", "request_time")]
    public DateTime? beginTime { get; set; }

    [Where("<", "request_time")]
    public DateTime? endTime { get; set; }
  }
}
