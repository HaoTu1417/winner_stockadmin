// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.ReviewMemberBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Cache;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Admin;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.Home;
using stockadmin.ViewModels.ReviewMember;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class ReviewMemberBiz
  {
    public static DataCountBase<ReviewMemberList> GetReviewMemberList(
      ReviewMemberFilter? filter,
      int page,
      int pageSize,
      string lang)
    {
      string str = SqlTool.Build<ReviewMemberFilter>(filter).Must("member.id_auth <> 1").Must("member.id_auth <> 2").Must("member.is_del = 0");
      if (filter.has_recommend)
        str = str.Must("m2.pk IS NOT NULL");
      if (IdAuthStatusConvertEnum.ConvertIdAuthString(filter.id_auth_string) == 0)
        str = str.Must("member.id_auth = 0");
      else if (IdAuthStatusConvertEnum.ConvertIdAuthString(filter.id_auth_string) == 3)
        str = str.Must("member.id_auth = 3");
      DataCountBase<ReviewMemberList> reviewMemberList = MemberService.FindReviewMemberList(page, pageSize, str, lang);
      return new DataCountBase<ReviewMemberList>(reviewMemberList.count, reviewMemberList.data.Select<ReviewMemberList, ReviewMemberList>((Func<ReviewMemberList, ReviewMemberList>) (reviewMember => PublicTool.convertUtcToLocalTime<ReviewMemberList>(reviewMember))));
    }

    public static DataCountBase<ReviewMemberList> GetReviewMemberFailList(
      ReviewMemberFilter? filter,
      int page,
      int pageSize,
      string lang)
    {
      string str = SqlTool.Build<ReviewMemberFilter>(filter).Must("member.id_auth = 2");
      if (filter.has_recommend)
        str = str.Must("m2.pk IS NOT NULL");
      DataCountBase<ReviewMemberList> reviewMemberList = MemberService.FindReviewMemberList(page, pageSize, str, lang);
      return new DataCountBase<ReviewMemberList>(reviewMemberList.count, reviewMemberList.data.Select<ReviewMemberList, ReviewMemberList>((Func<ReviewMemberList, ReviewMemberList>) (reviewMember => PublicTool.convertUtcToLocalTime<ReviewMemberList>(reviewMember))));
    }

    public static Summary GetSummary()
    {
      Summary summary = new Summary();
      string whereSql1 = SqlTool.Build<ReviewMemberFilter>(new ReviewMemberFilter()).Must("member.id_auth <> 1").Must("member.id_auth != 2").Must("member.is_del = 0");
      summary.total_member = MemberService.GetMemberCount(whereSql1);
      string whereSql2 = SqlTool.Build<ReviewMemberFilter>(new ReviewMemberFilter()).Must("member.id_auth <> 1").Must("member.id_auth != 2").Must("member.is_del = 0").Must("m2.pk IS NOT NULL");
      summary.has_recommend_id = MemberService.GetMemberCount(whereSql2);
      summary.dont_have_recommend_id = summary.total_member - summary.has_recommend_id;
      return summary;
    }

    public static MemberDto Get(int pk) => MemberService.Find(pk);

    public static ReviewMemberReview GetReview(int pk) => MemberService.FindReviewMemberReview(pk);

    public static void Delete(int pk)
    {
      MemberService.Remove(pk);
      WalletService.Remove(pk);
      MemberNotifyService.Remove(pk);
      RecommendRegisterService.Remove(pk);
    }

    public static void VerifyMember(ReviewMemberReview vm, bool result, int current_admin_pk)
    {
      if (result)
      {
        MemberDto member = MemberService.Find(vm.pk);
        if (!vm.is_test_account && string.IsNullOrEmpty(member.card_pic_front))
          throw new AppException(1221, "need_to_upload_front_id_card");
        ReviewMemberBiz.VerifySucess(vm, member, current_admin_pk);
      }
      else
      {
        MemberService.UpdateStatus(vm.pk, 2);
        MemberService.UpdateAuthTimeAndResult(vm.pk, DateTime.UtcNow, vm.auth_result);
        MemberService.UpdateAdminUserFk(vm.pk, current_admin_pk);
        SendMessageLib.Send(vm.pk, 116, (object) vm.auth_result);
      }
      ReviewMemberBiz.UpdateReviewMemberCount();
      if (vm.is_test_account)
        ReviewMemberBiz.SetTestAccount(vm.pk);
      AdminUserDto adminUserDto = AdminUserService.Find(current_admin_pk);
      string account = MemberService.Find(vm.pk).account;
      object[] objArray = new object[3]
      {
        (object) adminUserDto.account,
        (object) adminUserDto.nickname,
        (object) account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = current_admin_pk,
        admin_menu_fk = 433,
        list = objArray,
        member_account = account
      });
    }

    private static void SetTestAccount(int member) => MemberService.UpdateTestAccount(member);

    public static void VerifySucess(ReviewMemberReview vm, MemberDto member, int current_admin_pk)
    {
      member.status = true;
      member.id_auth = 1;
      member.admin_user_fk = new int?(vm.admin_user_fk);
      member.auth_result = "Success";
      member.nickname = !string.IsNullOrEmpty(vm.nickname) ? vm.nickname : member.real_name;
      MemberService.UpdateFull(member);
      MemberTaskLib.MemberTaskFinish(vm.pk, 2);
      SendMessageLib.Send(vm.pk, 115);
    }

    public static void UpdateReviewMemberCount()
    {
      int reviewMemberCount = MemberService.GetReviewMemberCount();
      CacheQuery.SelectDB(CacheEnum.admin);
      HomeVm redisValue = CacheQuery.StringGet<HomeVm>("HomeVm");
      if (redisValue == null)
        return;
      redisValue.MemberVerifying = reviewMemberCount.ToString();
      CacheQuery.StringSet<HomeVm>("HomeVm", redisValue);
    }
  }
}
