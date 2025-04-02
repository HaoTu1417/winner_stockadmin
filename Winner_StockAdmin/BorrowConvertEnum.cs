// Decompiled with JetBrains decompiler
// Type: BorrowConvertEnum
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

#nullable enable
public static class BorrowConvertEnum
{
    public static string ConvertBorrowStatus(int status)
    {
        string str;
        switch (status)
        {
            case -1:
                str = "待审核";
                break;
            case 0:
                str = "未通过";
                break;
            case 1:
                str = "使用中";
                break;
            case 2:
                str = "已结束";
                break;
            case 3:
                str = "已逾期";
                break;
            default:
                // ISSUE: reference to a compiler-generated method
                // \u003CPrivateImplementationDetails\u003E.ThrowSwitchExpressionException((object) status);
                str = "unknown";
                break;
        }
        return str;
    }
}