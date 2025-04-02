// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.DemoBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using stockadmin.Tool;
using stockadmin.ViewModels.Demo;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class DemoBiz
  {
    public static List<DemoSearchList> GetSearchList(DemoSearchFilter filter)
    {
      List<DemoSearchList> demoSearch1 = TradeMoneyCheckService.FindDemoSearch(SqlTool.Build<DemoSearchFilter>(filter));
      return demoSearch1 == null ? (List<DemoSearchList>) null : demoSearch1.Select<DemoSearchList, DemoSearchList>((Func<DemoSearchList, DemoSearchList>) (demoSearch => PublicTool.convertUtcToLocalTime<DemoSearchList>(demoSearch))).ToList<DemoSearchList>();
    }
  }
}
