// Decompiled with JetBrains decompiler
// Type: TradeConvertEnum
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
public static class TradeConvertEnum
{
  public static string ConvertOrderTypeStatus(int status)
  {
    string str;
    switch (status)
    {
      case 1:
        str = "NewOrder";
        break;
      case 2:
        str = "Settlement";
        break;
      default:
        // ISSUE: reference to a compiler-generated method
        \u003CPrivateImplementationDetails\u003E.ThrowSwitchExpressionException((object) status);
        break;
    }
    return str;
  }

  public static string ConvertDirStatus(int status)
  {
    string str;
    switch (status)
    {
      case 1:
        str = "Buy";
        break;
      case 2:
        str = "Sell";
        break;
      default:
        // ISSUE: reference to a compiler-generated method
        \u003CPrivateImplementationDetails\u003E.ThrowSwitchExpressionException((object) status);
        break;
    }
    return str;
  }
}
