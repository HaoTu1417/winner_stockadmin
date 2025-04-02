// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.AppFile.AppFileFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.AppFile
{
  public class AppFileFilter
  {
    [Where("=", "path")]
    public string? path { get; set; }

    [Where("=", "code")]
    public string? code { get; set; }

    [Where("=", "version")]
    public string? version { get; set; }

    [Where("=", "device")]
    public int? device { get; set; }
  }
}
