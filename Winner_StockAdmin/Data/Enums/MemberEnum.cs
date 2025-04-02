// Decompiled with JetBrains decompiler
// Type: IdAuthStatus
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System.ComponentModel.DataAnnotations;

#nullable disable
public enum IdAuthStatus
{
  [Display(Name = "未知狀態")] UnKnown = -1, // 0xFFFFFFFF
  [Display(Name = "新注册未实名")] NoRecord = 0,
  [Display(Name = "通过")] Pass = 1,
  [Display(Name = "错误")] Error = 2,
  [Display(Name = "已实名待审核")] UnderReview = 3,
}
