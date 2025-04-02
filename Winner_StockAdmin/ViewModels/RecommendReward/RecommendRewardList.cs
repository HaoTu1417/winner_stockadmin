// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RecommendReward.RecommendRewardList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Data.Enums;
using System;

#nullable enable
namespace stockadmin.ViewModels.RecommendReward
{
  public class RecommendRewardList
  {
    public int pk { get; set; }

    public string account { get; set; }

    public string nickname { get; set; }

    public string year { get; set; }

    public string month { get; set; }

    public string currency { get; set; }

    public Decimal total_reward { get; set; }

    public int state { get; set; }

    public string stateText => RecommendRewardConvertEnum.ConvertStatus(this.state);

    public DateTime? withdraw { get; set; }

    public DateTime? paydate { get; set; }

    public DateTime create_time { get; set; }
  }
}
