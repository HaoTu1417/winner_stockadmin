// Decompiled with JetBrains decompiler
// Type: Models.Dto.TradeFrozenDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class TradeFrozenDto
  {
    public string sub_account { get; set; }

    public int trade_order_fk { get; set; }

    public int pk { get; set; }

    public string info { get; set; }

    public int type { get; set; }

    public int frozen_volume { get; set; }

    public Decimal frozen_money { get; set; }

    public DateTime frozen_datetime { get; set; }
  }
}
