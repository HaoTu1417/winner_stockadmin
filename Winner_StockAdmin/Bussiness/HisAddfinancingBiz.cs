// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.HisAddfinancingBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.HisAddfinancing;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class HisAddfinancingBiz
  {
    public static DataCountBase<HisAddfinancingList> GetHisAddfinancingList(
      HisAddfinancingFilter? filter,
      int page,
      int pageSize,
      string lang)
    {
      string whereSql = SqlTool.Build<HisAddfinancingFilter>(filter).Must("member.is_del = 0");
      DataCountBase<HisAddfinancingList> addfinancingList = BorrowAddfinancingService.FindHisAddfinancingList(page, pageSize, whereSql, lang);
      return new DataCountBase<HisAddfinancingList>(addfinancingList.count, addfinancingList.data.Select<HisAddfinancingList, HisAddfinancingList>((Func<HisAddfinancingList, HisAddfinancingList>) (hisAddfinancing => PublicTool.convertUtcToLocalTime<HisAddfinancingList>(hisAddfinancing))));
    }

    public static BorrowAddfinancingDto Get(int pk) => BorrowAddfinancingService.Find(pk);

    public static void PostCreate(BorrowAddfinancingDto req)
    {
      if (BorrowAddfinancingService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(BorrowAddfinancingDto req)
    {
      if (BorrowAddfinancingService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => BorrowAddfinancingService.Remove(pk);

    public static HisAddfinancingEditVm GetEditVm(int pk)
    {
      return BorrowAddfinancingService.FindHisAddfinancingEditVm(pk);
    }
  }
}
