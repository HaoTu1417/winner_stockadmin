// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.StockOptionPositionBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using stockadmin.Tool;
using stockadmin.ViewModels.StockOptionPosition;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Business
{
  public class StockOptionPositionBiz
  {
    public static List<StockOptionPositionList> GetStockOptionPositionList(
      StockOptionPositionFilter? filter,
      int page,
      int pageSize)
    {
      string str = SqlTool.Build<StockOptionPositionFilter>(filter).Must("member.is_del = 0");
      if (filter.filter_out_test_account)
        str = str.Must("member.is_test_account = 0");
      return StockOptionPositionService.FindStockOptionPositionList(str);
    }
  }
}
