// Decompiled with JetBrains decompiler
// Type: tradeapi.Models.RichBox.RichHistoryResponse
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace tradeapi.Models.RichBox
{
  public class RichHistoryResponse
  {
    public int src { get; set; }

    public string src_string { get; set; }

    public DateTime date { get; set; }

    public int type { get; set; }

    public string type_string { get; set; }

    public Decimal amount { get; set; }

    public Decimal blance { get; set; }
  }
}
