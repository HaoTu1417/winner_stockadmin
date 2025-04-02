// Decompiled with JetBrains decompiler
// Type: ConvertEnum
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
public static class ConvertEnum
{
  public static string ConvertAccountStatus(int status, string lang)
  {
    string str1;
    switch (lang.ToUpper())
    {
      case "VN":
        string str2;
        switch (status)
        {
          case 0:
            str2 = "giao dịch";
            break;
          case 1:
            str2 = "đông cứng";
            break;
          case 2:
            str2 = "Trong thanh lý";
            break;
          case 3:
            str2 = "qua";
            break;
          default:
            throw new ArgumentException("Invalid status value");
        }
        str1 = str2;
        break;
      case "CN":
        string str3;
        switch (status)
        {
          case 0:
            str3 = "可交易";
            break;
          case 1:
            str3 = "冻结";
            break;
          case 2:
            str3 = "清算中";
            break;
          case 3:
            str3 = "已结束";
            break;
          default:
            throw new ArgumentException("Invalid status value");
        }
        str1 = str3;
        break;
      default:
        string str4;
        switch (status)
        {
          case 0:
            str4 = "Tradeable";
            break;
          case 1:
            str4 = "Frozen";
            break;
          case 2:
            str4 = "Settlement";
            break;
          case 3:
            str4 = "Closed";
            break;
          default:
            throw new ArgumentException("Invalid status value");
        }
        str1 = str4;
        break;
    }
    return str1;
  }

  public static string ConvertCloseType(int status, string lang)
  {
    string str1;
    switch (lang.ToUpper())
    {
      case "VN":
        string str2;
        switch (status)
        {
          case 0:
            str2 = "";
            break;
          case 1:
            str2 = "Khách hàng đã đóng cửa";
            break;
          case 2:
            str2 = "Phí quản lý sẽ bị khấu trừ nếu số dư không đủ";
            break;
          case 3:
            str2 = "Dưới đường đóng cửa";
            break;
          case 4:
            str2 = "Miễn phí không lãi suất và không thể tái tạo";
            break;
          default:
            throw new ArgumentException("Invalid status value");
        }
        str1 = str2;
        break;
      case "CN":
        string str3;
        switch (status)
        {
          case 0:
            str3 = "";
            break;
          case 1:
            str3 = "客户关闭";
            break;
          case 2:
            str3 = "余额不足扣管理费";
            break;
          case 3:
            str3 = "低于平仓线";
            break;
          case 4:
            str3 = "免費免息不可續期";
            break;
          default:
            throw new ArgumentException("Invalid status value");
        }
        str1 = str3;
        break;
      default:
        string str4;
        switch (status)
        {
          case 0:
            str4 = "";
            break;
          case 1:
            str4 = "Customer Close";
            break;
          case 2:
            str4 = "Expired or Renewal failed";
            break;
          case 3:
            str4 = "Liquidation";
            break;
          case 4:
            str4 = "Not renewable";
            break;
          default:
            throw new ArgumentException("Invalid status value");
        }
        str1 = str4;
        break;
    }
    return str1;
  }
}
