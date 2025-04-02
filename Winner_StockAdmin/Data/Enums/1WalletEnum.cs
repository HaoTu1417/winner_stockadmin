// Decompiled with JetBrains decompiler
// Type: WalletRechargeVerifyStatus
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System.ComponentModel.DataAnnotations;

#nullable disable
public enum WalletRechargeVerifyStatus
{
  [Display(Name = "待处理")] Processing,
  [Display(Name = "成功")] Success,
  [Display(Name = "失败")] Fail,
}
