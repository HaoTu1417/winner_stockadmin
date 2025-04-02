// Decompiled with JetBrains decompiler
// Type: stockadmin.Data.Enums.RecommendRewardEnum
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System.ComponentModel.DataAnnotations;

#nullable disable
namespace stockadmin.Data.Enums
{
  public enum RecommendRewardEnum
  {
    [Display(Name = "计算中")] Calculating = -1, // 0xFFFFFFFF
    [Display(Name = "未提现")] UnWithdraw = 0,
    [Display(Name = "申请提现中")] Processing = 1,
    [Display(Name = "已提现")] Done = 2,
    [Display(Name = "异常")] Fatal = 3,
  }
}
