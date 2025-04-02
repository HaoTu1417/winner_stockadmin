// Decompiled with JetBrains decompiler
// Type: BorrowRequestConvertEnum
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
public static class BorrowRequestConvertEnum
{
  public static string ConvertVerifyStatus(int status)
  {
    string str;
    switch (status)
    {
      case 0:
        str = "审核中";
        break;
      case 1:
        str = "成功";
        break;
      case 2:
        str = "失败";
        break;
      default:
        // ISSUE: reference to a compiler-generated method
        \u003CPrivateImplementationDetails\u003E.ThrowSwitchExpressionException((object) status);
        break;
    }
    return str;
  }

  public static string ConvertBorrowType(int status)
  {
    string str;
    switch (status)
    {
      case 1:
        str = "新合约";
        break;
      case 2:
        str = "续期";
        break;
      case 3:
        str = "擴大融資";
        break;
      default:
        // ISSUE: reference to a compiler-generated method
        \u003CPrivateImplementationDetails\u003E.ThrowSwitchExpressionException((object) status);
        break;
    }
    return str;
  }
}
