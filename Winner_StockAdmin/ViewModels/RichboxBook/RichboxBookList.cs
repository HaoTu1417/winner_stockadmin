// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RichboxBook.RichboxBookList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.RichboxBook
{
  public class RichboxBookList
  {
    public string account { get; set; }

    public string real_name { get; set; }

    public Decimal total_assets { get; set; }

    public Decimal profit { get; set; }

    public Decimal total_earing { get; set; }

    public Decimal max_assets { get; set; }

    public bool is_test_account { get; set; }
  }
}
