// Decompiled with JetBrains decompiler
// Type: AppTypeEnum
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

#nullable enable
public static class AppTypeEnum
{
    public static string ConvertAppType(int status)
    {
        string str;
        switch (status)
        {
            case 0:
                str = "iOS";
                break;
            case 1:
                str = "android";
                break;
            default:
                // ISSUE: reference to a compiler-generated method
                //PrivateImplementationDetails.ThrowSwitchExpressionException((object) status);
                str = "unknown";
                break;
        }
        return str;
    }
}