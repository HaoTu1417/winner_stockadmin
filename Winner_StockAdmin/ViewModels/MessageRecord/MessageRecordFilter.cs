// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.MessageRecord.MessageRecordFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.MessageRecord
{
  public class MessageRecordFilter
  {
    [Where("=", "message_record.pk")]
    public int? pk { get; set; }

    [Where("LIKE", "nickname")]
    public string? nickname { get; set; }

    [Where("LIKE", "title")]
    public string? title { get; set; }

    [Where("=", "account")]
    public string? account { get; set; }

    public bool filter_out_test_account { get; set; }
  }
}
