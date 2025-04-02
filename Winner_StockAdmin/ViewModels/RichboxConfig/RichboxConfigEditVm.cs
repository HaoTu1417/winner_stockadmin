// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RichboxConfig.RichboxConfigEditVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using System.ComponentModel.DataAnnotations;

#nullable disable
namespace stockadmin.ViewModels.RichboxConfig
{
  public class RichboxConfigEditVm
  {
    public int id { get; set; }

    public bool enable { get; set; }

    public Decimal min_investment { get; set; }

    public Decimal max_investment { get; set; }

    [DisplayFormat(DataFormatString = "{0}", ApplyFormatInEditMode = true)]
    public Decimal interest_rate { get; set; }

    public Decimal begin_profit { get; set; }
  }
}
