// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Promotion.PromotionList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.Promotion
{
  public class PromotionList
  {
    public int pk { get; set; }

    public string lang { get; set; }

    public string title { get; set; }

    public int view { get; set; }

    public int sort { get; set; }

    public bool on_active { get; set; }

    public bool trash { get; set; }

    public bool show_activity_time { get; set; }

    public DateTime starttime { get; set; }

    public DateTime endtime { get; set; }
  }
}
