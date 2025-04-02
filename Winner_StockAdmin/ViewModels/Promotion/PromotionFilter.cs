// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Promotion.PromotionFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.Promotion
{
  public class PromotionFilter
  {
    [Where("=", "cms_promotion.lang")]
    public string? lang { get; set; }

    [Where("LIKE", "cms_promotion.title")]
    public string? title { get; set; }

    [Where(">=", "date(cms_promotion.starttime)")]
    public DateTime? starttime { get; set; }

    [Where("<", "date(cms_promotion.endtime)")]
    public DateTime? endtime { get; set; }
  }
}
