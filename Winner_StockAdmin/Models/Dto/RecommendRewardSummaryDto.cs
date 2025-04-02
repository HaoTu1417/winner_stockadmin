// Decompiled with JetBrains decompiler
// Type: Models.Dto.RecommendRewardSummaryDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class RecommendRewardSummaryDto
  {
    public int member_fk { get; set; }

    public int recommend_reward_fk { get; set; }

    public int pk { get; set; }

    public int layer { get; set; }

    public string year { get; set; }

    public string month { get; set; }

    public int monthly_members { get; set; }

    public Decimal monthly_borrow_fee { get; set; }

    public Decimal monthly_reward { get; set; }
  }
}
