// Decompiled with JetBrains decompiler
// Type: MessageTransTypeEnum
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System.ComponentModel.DataAnnotations;

#nullable disable
public enum MessageTransTypeEnum
{
  [Display(Name = "Internal")] Internal = 1,
  [Display(Name = "email")] Email = 2,
  [Display(Name = "SMS")] Sms = 3,
}
