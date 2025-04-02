// Decompiled with JetBrains decompiler
// Type: Models.Dto.MessageRecordDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class MessageRecordDto
  {
    public int pk { get; set; }

    public bool isbatch { get; set; }

    public AccountTypeEnum receiver_table { get; set; }

    public int receiver_fk { get; set; }

    public AccountTypeEnum sender_table { get; set; }

    public int sender_fk { get; set; }

    public string title { get; set; }

    public string info { get; set; }

    public MessageReadStatusEnum read_status { get; set; }

    public int type { get; set; }

    public MessageSendStatus send_status { get; set; }

    public MessageTransTypeEnum send_type { get; set; }

    public DateTime create_time { get; set; }

    public DateTime? read_time { get; set; }

    public DateTime sent_time { get; set; }

    public int classify { get; set; }
  }
}
