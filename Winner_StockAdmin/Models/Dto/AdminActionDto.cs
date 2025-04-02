// Decompiled with JetBrains decompiler
// Type: Models.Dto.AdminActionDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
namespace Models.Dto
{
  public class AdminActionDto
  {
    public int admin_menu_fk { get; set; }

    public int pk { get; set; }

    public string lang { get; set; }

    public string title { get; set; }

    public string module { get; set; }

    public string method { get; set; }

    public string remark { get; set; }

    public string param { get; set; }

    public string log { get; set; }

    public int status { get; set; }
  }
}
