// Decompiled with JetBrains decompiler
// Type: Models.Dto.RichboxTaskLogDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class RichboxTaskLogDto
  {
    public int member_fk { get; set; }

    public int pk { get; set; }

    public string code { get; set; }

    public string info { get; set; }

    public DateTime create_time { get; set; }

    public bool result { get; set; }
  }
}
