// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.StockOptionRecordBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using stockadmin.Tool;
using stockadmin.ViewModels.StockOptionRecord;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class StockOptionRecordBiz
  {
    public static List<StockOptionRecordList> GetStockOptionRecordList(
      StockOptionRecordFilter? filter)
    {
      string str = SqlTool.Build<StockOptionRecordFilter>(filter).Must("member.is_del = 0");
      if (filter.filter_out_test_account)
        str = str.Must("member.is_test_account = 0");
      List<StockOptionRecordList> optionRecordList = StockOptionRecordService.FindStockOptionRecordList(str);
      return optionRecordList == null ? (List<StockOptionRecordList>) null : optionRecordList.Select<StockOptionRecordList, StockOptionRecordList>((Func<StockOptionRecordList, StockOptionRecordList>) (so => PublicTool.convertUtcToLocalTime<StockOptionRecordList>(so))).ToList<StockOptionRecordList>();
    }
  }
}
