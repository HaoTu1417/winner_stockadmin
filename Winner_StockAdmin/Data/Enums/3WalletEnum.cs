// Decompiled with JetBrains decompiler
// Type: WalletWithdrawConvertEnum
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
public static class WalletWithdrawConvertEnum
{
  public static string ConvertVerifyStatus(int status, string lang)
  {
    if (lang.ToUpper() == "VN")
    {
      string str;
      switch (status)
      {
        case 0:
          str = "Chưa giải quyết";
          break;
        case 1:
          str = "thành công";
          break;
        case 2:
          str = "thất bại";
          break;
        case 3:
          str = "từ chối";
          break;
        default:
          // ISSUE: reference to a compiler-generated method
          \u003CPrivateImplementationDetails\u003E.ThrowSwitchExpressionException((object) status);
          break;
      }
      return str;
    }
    string str1;
    switch (status)
    {
      case 0:
        str1 = "待处理";
        break;
      case 1:
        str1 = "成功";
        break;
      case 2:
        str1 = "失败";
        break;
      case 3:
        str1 = "拒絕";
        break;
      default:
        // ISSUE: reference to a compiler-generated method
        \u003CPrivateImplementationDetails\u003E.ThrowSwitchExpressionException((object) status);
        break;
    }
    return str1;
  }
}
