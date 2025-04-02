// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.RequestStopBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Tool;
using stockadmin.ViewModels.RequestStop;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class RequestStopBiz
  {
    public static List<RequestStopList> GetRequestStopList(RequestStopFilter? filter)
    {
      List<RequestStopList> requestStopList = BorrowRequestService.FindRequestStopList(SqlTool.Build<RequestStopFilter>(filter).Must("borrow_request.type = 2").Must("borrow_request.status = 0"));
      return requestStopList == null ? (List<RequestStopList>) null : requestStopList.Select<RequestStopList, RequestStopList>((Func<RequestStopList, RequestStopList>) (requestStop => PublicTool.convertUtcToLocalTime<RequestStopList>(requestStop))).ToList<RequestStopList>();
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

    public static RequestStopReview GetReview(int pk)
    {
      return BorrowRequestService.FindRequestStopReview(pk);
    }

    public static void TerminateVerify(int adminId, int borrowRequestId, bool verifyStatus)
    {
      BorrowRequestDto borrowRequestDto = BorrowRequestService.Find(borrowRequestId);
      TradeAccountDto tradeAccountDto = borrowRequestDto.status == 0 ? TradeAccountService.Find(borrowRequestDto.sub_account) : throw new AppException(3032, "verify_status_incorrect");
      if (tradeAccountDto.close_time.HasValue)
      {
        BorrowRequestService.UpdateState(borrowRequestId, verifyStatus);
        throw new AppException(3050, "account_already_close");
      }
      if (verifyStatus)
      {
        if (TradePositionService.GetPositionBySubAccount(borrowRequestDto.sub_account) > 0)
          throw new AppException(3051, "stock_not_position");
        if (tradeAccountDto.loan_type == "trial")
          throw new AppException(3051, "trial_no_early_terminate");
        TradeAccountService.InAdvanceClose(borrowRequestDto.sub_account, 2, DateTime.UtcNow);
        BorrowService.InAdvanceReset(borrowRequestDto.borrow_fk, borrowRequestDto.sub_account);
        BorrowService.UpdateStatus(borrowRequestDto.borrow_fk, BorrowStatus.End);
      }
      BorrowRequestService.UpdateState(borrowRequestId, verifyStatus);
      int temp_id = verifyStatus ? 53 : 54;
      SendMessageLib.Send(borrowRequestDto.member_fk, temp_id, (object) borrowRequestDto.pk);
    }
  }
}
