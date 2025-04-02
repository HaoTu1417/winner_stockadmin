// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.AdminBank.AdminBankList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
namespace stockadmin.ViewModels.AdminBank
{
  public class AdminBankList
  {
    public int pk { get; set; }

    public int type { get; set; }

    public string type_string { get; set; }

    public string currency { get; set; }

    public string card { get; set; }

    public string bank_name { get; set; }

    public string open_bank { get; set; }

    public string payee { get; set; }

    public string notes { get; set; }

    public bool status { get; set; }

    public string viplists { get; set; }
  }
}
