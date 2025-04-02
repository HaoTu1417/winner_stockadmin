// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.MessageRecord.MessageRecordList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.MessageRecord
{
  public class MessageRecordList
  {
    public int pk { get; set; }

    public string nickname { get; set; }

    public string title { get; set; }

    public string account { get; set; }

    public string mobile_country { get; set; }

    public string mobile { get; set; }

    public DateTime sent_time { get; set; }

    public DateTime? read_time { get; set; }

    public string read_time_string
    {
      get
      {
        if (this.read_time.HasValue)
        {
          DateTime? readTime = this.read_time;
          DateTime minValue = DateTime.MinValue;
          if ((readTime.HasValue ? (readTime.GetValueOrDefault() == minValue ? 1 : 0) : 0) == 0)
          {
            readTime = this.read_time;
            ref DateTime? local = ref readTime;
            return !local.HasValue ? (string) null : local.GetValueOrDefault().ToString();
          }
        }
        return "未读";
      }
    }

    public bool is_test_account { get; set; }
  }
}
