// Decompiled with JetBrains decompiler
// Type: Models.Dto.MemberLogDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class MemberLogDto
  {
    public int member_fk { get; set; }

    public int pk { get; set; }

    public DateTime addtime { get; set; }

    public string ip { get; set; }

    public string urlpath { get; set; }

    public string info { get; set; }

    public int urltype { get; set; }

    public string udevice { get; set; }

    public string ipinfo { get; set; }
  }
}
