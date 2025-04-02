// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Banner.BannerFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.Banner
{
  public class BannerFilter
  {
    [Where("=", "cms_banner.size")]
    public int? size { get; set; }

    [Where("=", "cms_banner.lang")]
    public string? lang { get; set; }
  }
}
