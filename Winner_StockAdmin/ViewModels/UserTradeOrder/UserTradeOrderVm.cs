// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.UserTradeOrder.UserTradeOrderVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System.Collections.Generic;

#nullable enable
namespace stockadmin.ViewModels.UserTradeOrder
{
  public class UserTradeOrderVm
  {
    public UserTradeOrderFilter filter { get; set; }

    public List<UserTradeOrderList> list { get; set; }
  }
}
