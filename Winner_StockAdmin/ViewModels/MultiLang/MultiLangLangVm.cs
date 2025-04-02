// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.MultiLang.MultiLangLangVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;

#nullable enable
namespace stockadmin.ViewModels.MultiLang
{
  public class MultiLangLangVm
  {
    public string[] enableOption = new string[2]
    {
      "禁用",
      "启用"
    };

    public string lang { get; set; }

    public string title { get; set; }

    [BindProperty]
    public int enable { get; set; }

    public string enableTxt
    {
      get
      {
        int enable = this.enable;
        string enableTxt;
        switch (enable)
        {
          case 0:
            enableTxt = "禁用";
            break;
          case 1:
            enableTxt = "启用";
            break;
          default:
            \u003CPrivateImplementationDetails\u003E.ThrowSwitchExpressionException((object) enable);
            break;
        }
        return enableTxt;
      }
    }

    public bool admin_default { get; set; }

    public bool app_default { get; set; }

    public bool isSucceed { get; set; }
  }
}
