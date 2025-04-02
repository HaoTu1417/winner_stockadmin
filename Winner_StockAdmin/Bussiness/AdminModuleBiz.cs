// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.AdminModuleBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Business
{
  public class AdminModuleBiz
  {
    public static AdminModuleDto Get(int pk) => AdminModuleService.Find(pk);

    public static List<AdminModuleDto> GetEnabledList() => AdminModuleService.FindAll(1);
  }
}
