// Decompiled with JetBrains decompiler
// Type: Models.Dto.TradeMoneyCheckDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class TradeMoneyCheckDto
  {
    public string sub_account { get; set; }

    public int pk { get; set; }

    public string sn { get; set; }

    public int type { get; set; }

    public int state { get; set; }

    public Decimal frozen { get; set; }

    public Decimal exchange { get; set; }

    public string currency { get; set; }

    public Decimal amount { get; set; }

    public DateTime request_time { get; set; }

    public string acccept_by { get; set; }

    public DateTime accept_time { get; set; }
  }
}
