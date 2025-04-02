// Decompiled with JetBrains decompiler
// Type: AccountTypeEnum
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System.ComponentModel.DataAnnotations;

#nullable disable
public enum AccountTypeEnum
{
    [Display(Name = "无")] Unset,
    [Display(Name = "会员")] Member,
    [Display(Name = "管理员")] AdminUser,
    [Display(Name = "运营商")] Agent,
}