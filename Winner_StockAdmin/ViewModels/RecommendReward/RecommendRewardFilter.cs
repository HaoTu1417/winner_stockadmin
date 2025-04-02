// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RecommendReward.RecommendRewardFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.RecommendReward
{
  public class RecommendRewardFilter
  {
    [Where("=", "member.account")]
    public string? account { get; set; }

    [Where("LIKE", "member.nickname")]
    public string? nickname { get; set; }

    public string? year { get; set; }

    public string? month { get; set; }
  }
}
