// Decompiled with JetBrains decompiler
// Type: stockadmin.Data.Enums.CmsPopInfoConvertEnum
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
namespace stockadmin.Data.Enums
{
  public static class CmsPopInfoConvertEnum
  {
    public static string ConvertSize(int size)
    {
      string str;
      switch (size)
      {
        case 1:
          str = "手机端";
          break;
        case 2:
          str = "PC";
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
