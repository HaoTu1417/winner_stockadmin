// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Demo.DemoMemberVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.Demo
{
  public class DemoMemberVm
  {
    public int id { get; set; }

    public string account { get; set; }

    public string realName { get; set; }

    public string email { get; set; }

    public DateTime birthday { get; set; }

    public bool isSucceed { get; set; }
  }
}
