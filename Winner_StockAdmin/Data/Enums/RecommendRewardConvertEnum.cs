// Decompiled with JetBrains decompiler
// Type: stockadmin.Data.Enums.RecommendRewardConvertEnum
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
namespace stockadmin.Data.Enums
{
  public static class RecommendRewardConvertEnum
  {
    public static string ConvertStatus(int size)
    {
      string str;
      switch (size)
      {
        case -1:
          str = "计算中";
          break;
        case 0:
          str = "未提现";
          break;
        case 1:
          str = "申请提现中";
          break;
        case 2:
          str = "已提现";
          break;
        case 3:
          str = "异常";
          break;
        default:
          // ISSUE: reference to a compiler-generated method
          \u003CPrivateImplementationDetails\u003E.ThrowSwitchExpressionException((object) size);
          break;
      }
      return str;
    }
  }
}
