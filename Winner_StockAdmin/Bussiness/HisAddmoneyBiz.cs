// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.HisAddmoneyBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.HisAddmoney;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class HisAddmoneyBiz
  {
    public static DataCountBase<HisAddmoneyList> GetHisAddmoneyList(
      HisAddmoneyFilter? filter,
      int page,
      int pageSize,
      string lang)
    {
      string str = SqlTool.Build<HisAddmoneyFilter>(filter).Must("member.is_del = 0");
      if (filter.filter_out_test_account)
        str = str.Must("member.is_test_account = 0");
      DataCountBase<HisAddmoneyList> hisAddmoneyList = BorrowAddmoneyService.FindHisAddmoneyList(page, pageSize, str, lang);
      return new DataCountBase<HisAddmoneyList>(hisAddmoneyList.count, hisAddmoneyList.data.Select<HisAddmoneyList, HisAddmoneyList>((Func<HisAddmoneyList, HisAddmoneyList>) (hisAddmoney => PublicTool.convertUtcToLocalTime<HisAddmoneyList>(hisAddmoney))));
    }

    public static BorrowAddmoneyDto Get(int pk) => BorrowAddmoneyService.Find(pk);

    public static void PostCreate(BorrowAddmoneyDto req)
    {
      if (BorrowAddmoneyService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(BorrowAddmoneyDto req)
    {
      if (BorrowAddmoneyService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => BorrowAddmoneyService.Remove(pk);

    public static HisAddmoneyEditVm GetEditVm(int pk)
    {
      return BorrowAddmoneyService.FindHisAddmoneyEditVm(pk);
    }
  }
}
