// Decompiled with JetBrains decompiler
// Type: BorrowStatus
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System.ComponentModel.DataAnnotations;

#nullable disable
public enum BorrowStatus
{
  [Display(Name = "待审核")] Default = -1, // 0xFFFFFFFF
  [Display(Name = "未通过")] Forbid = 0,
  [Display(Name = "使用中")] Using = 1,
  [Display(Name = "已结束")] End = 2,
  [Display(Name = "已逾期")] Expired = 3,
}
