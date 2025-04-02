// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.CmsPopinfo.CmsPopinfoList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Data.Enums;

#nullable enable
namespace stockadmin.ViewModels.CmsPopinfo
{
  public class CmsPopinfoList
  {
    public int pk { get; set; }

    public string lang { get; set; }

    public string info { get; set; }

    public int size { get; set; }

    public string size_str => CmsPopInfoConvertEnum.ConvertSize(this.size);

    public bool enable { get; set; }
  }
}
