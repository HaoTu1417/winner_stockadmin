// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.MessageRecord.MessageRecordEditVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.MessageRecord
{
  public class MessageRecordEditVm
  {
    public int receiver_fk { get; set; }

    public string account { get; set; }

    public string nickname { get; set; }

    public string title { get; set; }

    public string info { get; set; }

    public DateTime? read_time { get; set; }
  }
}
