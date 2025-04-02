// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RewardDetail.RewardDetailFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.RewardDetail
{
  public class RewardDetailFilter
  {
    [Where("=", "m1.account")]
    public string? account { get; set; }

    [Where("=", "m1.real_name")]
    public string? real_name { get; set; }

    [Where("=", "m2.account")]
    public string? parent_account { get; set; }

    [Where("=", "CONCAT('20', SUBSTRING(recommend_reward_detail.yymm, 1, 2), '-', SUBSTRING(recommend_reward_detail.yymm, 3, 2))")]
    public string? profit_date { get; set; }
  }
}
