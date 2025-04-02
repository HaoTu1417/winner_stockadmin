// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.StatBalanceBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.StatBalance;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class StatBalanceBiz
  {
    public static (CountAndTotalAmount, DataCountBase<StatBalanceList>) GetStatBalanceList(
      StatBalanceFilter? filter,
      int page,
      int pageSize)
    {
      string whereSql = SqlTool.Build<StatBalanceFilter>(filter);
      (CountAndTotalAmount countAndTotalAmount, DataCountBase<StatBalanceList> dataCountBase) = WalletRecordService.FindStatBalanceList(page, pageSize, whereSql);
      return (countAndTotalAmount, new DataCountBase<StatBalanceList>(dataCountBase.count, dataCountBase.data.Select<StatBalanceList, StatBalanceList>((Func<StatBalanceList, StatBalanceList>) (statBalance => PublicTool.convertUtcToLocalTime<StatBalanceList>(statBalance)))));
    }
  }
}
