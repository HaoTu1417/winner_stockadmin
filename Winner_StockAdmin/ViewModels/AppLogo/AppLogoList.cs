// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.AppLogo.AppLogoList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
namespace stockadmin.ViewModels.AppLogo
{
  public class AppLogoList
  {
    public int cms_files_fk { get; set; }

    public int type { get; set; }

    public string type_string
    {
      get
      {
        if (this.admin_lang.ToUpper() == "EN")
        {
          switch (this.type)
          {
            case 1:
              return "Logo in login page(131x180)";
            case 2:
              return "Logo in Download page(245x104)";
            case 3:
              return "Background in Download page(750x1000)";
            case 4:
              return "General logo must be white background(187x38)";
            case 5:
              return "Background in recommend page(750x978)";
            case 6:
              return "IOS download instructions(600x800)";
            case 7:
              return "Android download instructions(600x800)";
            default:
              return "";
          }
        }
        else
        {
          switch (this.type)
          {
            case 1:
              return "登入頁面logo(131x180)";
            case 2:
              return "下載頁面logo(245x104)";
            case 3:
              return "下載頁面背景圖(750x1000)";
            case 4:
              return "通用logo 須為白底(187x38)";
            case 5:
              return "推廣底圖(750x978)";
            case 6:
              return "IOS下載指示圖(600x800)";
            case 7:
              return "Android下載指示圖(600x800)";
            default:
              return "";
          }
        }
      }
    }

    public string enable { get; set; }

    public string lang { get; set; }

    public int sort { get; set; }

    public string url { get; set; }

    public string admin_lang { get; set; }
  }
}
