// Decompiled with JetBrains decompiler
// Type: IdAuthStatusConvertEnum
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
public static class IdAuthStatusConvertEnum
{
  public static string ConvertIdAuthStatus(int status, string lang = "VN")
  {
    string str1;
    switch (lang.ToUpper())
    {
      case "VN":
        string str2;
        switch (status)
        {
          case 0:
            str2 = "Đăng ký mới không có tên thật";
            break;
          case 1:
            str2 = "vượt qua";
            break;
          case 2:
            str2 = "sai lầm";
            break;
          case 3:
            str2 = "Tên thật đang chờ xác minh";
            break;
          default:
            str2 = "trạng thái không xác định";
            break;
        }
        str1 = str2;
        break;
      case "CN":
        string str3;
        switch (status)
        {
          case 0:
            str3 = "新注册未实名";
            break;
          case 1:
            str3 = "通过";
            break;
          case 2:
            str3 = "错误";
            break;
          case 3:
            str3 = "已实名待审核";
            break;
          default:
            str3 = "未知狀態";
            break;
        }
        str1 = str3;
        break;
      default:
        string str4;
        switch (status)
        {
          case 0:
            str4 = "New registration without real name";
            break;
          case 1:
            str4 = "Passed";
            break;
          case 2:
            str4 = "Error";
            break;
          case 3:
            str4 = "Awaiting review";
            break;
          default:
            str4 = "Unknown";
            break;
        }
        str1 = str4;
        break;
    }
    return str1;
  }

  public static int ConvertIdAuthString(string auth_string)
  {
    int num;
    switch (auth_string)
    {
      case "新注册未实名":
        num = 0;
        break;
      case "通过":
        num = 1;
        break;
      case "错误":
        num = 2;
        break;
      case "已实名待审核":
        num = 3;
        break;
      default:
        num = -1;
        break;
    }
    return num;
  }
}
