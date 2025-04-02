// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.BorrowFeeBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.BorrowFee;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class BorrowFeeBiz
  {
    public static (Decimal totalfee, DataCountBase<BorrowFeeList>) GetBorrowFeeList(
      BorrowFeeFilter? filter,
      int page,
      int pageSize)
    {
      string str = SqlTool.Build<BorrowFeeFilter>(filter).Must("member.is_test_account = 0 and member.is_del = 0");
      if (filter.filter_out_test_account)
        str = str.Must("member.is_test_account = 0");
      (Decimal num, DataCountBase<BorrowFeeList> dataCountBase) = BorrowFeeService.FindBorrowFeeList(page, pageSize, str);
      if (dataCountBase.data != null)
      {
        Dictionary<string, string> durationQuantities = BorrowFeeBiz.GetBorrowDurationQuantities();
        foreach (BorrowFeeList borrowFeeList in dataCountBase.data)
          borrowFeeList.borrow_duration_string = borrowFeeList.borrow_duration.ToString() + durationQuantities[borrowFeeList.loan_type];
      }
      return (num, new DataCountBase<BorrowFeeList>(dataCountBase.count, dataCountBase.data.Select<BorrowFeeList, BorrowFeeList>((Func<BorrowFeeList, BorrowFeeList>) (borrowFee => PublicTool.convertUtcToLocalTime<BorrowFeeList>(borrowFee)))));
    }

    public static Dictionary<string, string> GetBorrowDurationQuantities()
    {
      List<BorrowPlanDto> all = BorrowPlanService.FindAll();
      Dictionary<string, string> borrowPlanQuantities = new Dictionary<string, string>();
      all.ForEach((Action<BorrowPlanDto>) (borrowPlan =>
      {
        string str;
        switch (borrowPlan.sort)
        {
          case 0:
          case 1:
          case 2:
            str = "D";
            break;
          case 3:
            str = "W";
            break;
          default:
            str = "M";
            break;
        }
        borrowPlanQuantities[borrowPlan.name] = str;
      }));
      return borrowPlanQuantities;
    }

    public static BorrowFeeDto Get(int pk) => BorrowFeeService.Find(pk);

    public static void PostCreate(BorrowFeeDto req)
    {
      if (BorrowFeeService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(BorrowFeeDto req)
    {
      if (BorrowFeeService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => BorrowFeeService.Remove(pk);

    public static Decimal GetBorrowFeeSummary(BorrowFeeFilter? filter)
    {
      return BorrowFeeService.GetBorrowFeeSummary(SqlTool.Build<BorrowFeeFilter>(filter).Must("member.is_test_account = 0 and member.is_del = 0"));
    }

    public static byte[]? DownloadBorrowFeeList(BorrowFeeFilter? filter)
    {
      (Decimal totalfee, DataCountBase<BorrowFeeList>) borrowFeeList = BorrowFeeBiz.GetBorrowFeeList(filter, 1, int.MaxValue);
      Decimal totalfee = borrowFeeList.totalfee;
      return Exportlib.ExportExcel<BorrowFeeList>(borrowFeeList.Item2.data);
    }
  }
}
