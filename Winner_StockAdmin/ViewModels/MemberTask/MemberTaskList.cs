// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.MemberTask.MemberTaskList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.MemberTask
{
  public class MemberTaskList
  {
    public int pk { get; set; }

    public int sub_type { get; set; }

    public string currency { get; set; }

    public Decimal coin { get; set; }

    public string lang { get; set; }

    public string title { get; set; }

    public string content { get; set; }
  }
}
