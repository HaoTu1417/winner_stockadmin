// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RecommendRegister.RecommendRegisterList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.RecommendRegister
{
  public class RecommendRegisterList
  {
    public string inviter_account { get; set; }

    public string invitee_account { get; set; }

    public string invitee_realname { get; set; }

    public Decimal total_recharge { get; set; }

    public Decimal total_withdraw { get; set; }

    public Decimal total_management_fee { get; set; }

    public DateTime? first_borrow_date { get; set; }

    public DateTime create_date { get; set; }

    public bool is_test_account { get; set; }
  }
}
