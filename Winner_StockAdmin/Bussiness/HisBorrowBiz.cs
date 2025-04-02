// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.HisBorrowBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.HisBorrow;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class HisBorrowBiz
  {
    public static DataCountBase<HisBorrowList> GetHisBorrowList(
      HisBorrowFilter? filter,
      int page,
      int pageSize)
    {
      string str = SqlTool.Build<HisBorrowFilter>(filter).Must("t.is_del = 0");
      if (filter.filter_out_test_account)
        str = str.Must("t.is_test_account = 0");
      DataCountBase<HisBorrowList> hisBorrowList = BorrowService.FindHisBorrowList(page, pageSize, str);
      return new DataCountBase<HisBorrowList>(hisBorrowList.count, hisBorrowList.data.Select<HisBorrowList, HisBorrowList>((Func<HisBorrowList, HisBorrowList>) (hisBorrow => PublicTool.convertUtcToLocalTime<HisBorrowList>(hisBorrow))));
    }

    public static BorrowDto Get(int pk) => BorrowService.Find(pk);

    public static void PostCreate(BorrowDto req)
    {
      if (BorrowService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(BorrowDto req)
    {
      if (BorrowService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void EditRenewal(int pk, bool auto_renewal)
    {
      if (BorrowService.UpdateRenewal(pk, auto_renewal) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => BorrowService.Remove(pk);

    public static HisBorrowEditVm GetDetailVm(int pk)
    {
      HisBorrowEditVm hisBorrowEditVm = BorrowService.FindHisBorrowEditVm(pk);
      hisBorrowEditVm.status_string = BorrowConvertEnum.ConvertBorrowStatus(hisBorrowEditVm.status);
      return hisBorrowEditVm;
    }
  }
}
