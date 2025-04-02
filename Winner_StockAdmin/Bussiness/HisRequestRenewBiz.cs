// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.HisRequestRenewBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.HisRequestRenew;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class HisRequestRenewBiz
  {
    public static List<HisRequestRenewList> GetHisRequestRenewList(HisRequestRenewFilter? filter)
    {
      List<HisRequestRenewList> requestRenewList = BorrowRequestService.FindHisRequestRenewList(SqlTool.Build<HisRequestRenewFilter>(filter));
      return requestRenewList == null ? (List<HisRequestRenewList>) null : requestRenewList.Select<HisRequestRenewList, HisRequestRenewList>((Func<HisRequestRenewList, HisRequestRenewList>) (hisRequestRenew => PublicTool.convertUtcToLocalTime<HisRequestRenewList>(hisRequestRenew))).ToList<HisRequestRenewList>();
    }

    public static BorrowRequestDto Get(int pk) => BorrowRequestService.Find(pk);

    public static void PostCreate(BorrowRequestDto req)
    {
      if (BorrowRequestService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(BorrowRequestDto req)
    {
      if (BorrowRequestService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => BorrowRequestService.Remove(pk);
  }
}
