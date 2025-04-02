// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.MemberBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Business
{
  public class MemberBiz
  {
    public static DataCountBase<MemberList> GetMemberList(
      MemberFilter? filter,
      bool fuzzy_search,
      int page,
      int pageSize,
      string lang)
    {
      string str = SqlTool.Build<MemberFilter>(filter, !fuzzy_search).Must("(member.is_del = 0)");
      if (filter.filter_out_test_account)
        str = str.Must("member.is_test_account = 0");
      if (filter.only_id_auth)
        str = str.Must("member.id_auth = 1");
      if (filter.only_no_recommend)
        str = str.Must("m2.recommend_id IS NULL");
      DataCountBase<MemberList> memberList = MemberService.FindMemberList(str, page: page, pageSize: pageSize, lang: lang);
      return new DataCountBase<MemberList>(memberList.count, memberList.data.Select<MemberList, MemberList>((Func<MemberList, MemberList>) (member => PublicTool.convertUtcToLocalTime<MemberList>(member))));
    }

    public static DataCountBase<MemberList> GetPromotionMemberList(
      MemberFilter? filter,
      int invitationCode,
      bool fuzzy_search,
      int page,
      int pageSize)
    {
      string sourceStr1 = SqlTool.Build<MemberFilter>(filter, !fuzzy_search).Must("(member.is_del = 0)");
      if (filter.filter_out_test_account)
        sourceStr1 = sourceStr1.Must("member.is_test_account = 0");
      if (AdminConfigService.Find("enable_id_auth").value == "1")
        sourceStr1 = sourceStr1.Must("member.id_auth = 1");
      string sourceStr2 = sourceStr1;
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
      interpolatedStringHandler.AppendLiteral("member.`recommend` = ");
      interpolatedStringHandler.AppendFormatted<int>(invitationCode);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      DataCountBase<MemberList> memberList = MemberService.FindMemberList(sourceStr2.Must(stringAndClear), page: page, pageSize: pageSize);
      return new DataCountBase<MemberList>(memberList.count, memberList.data.Select<MemberList, MemberList>((Func<MemberList, MemberList>) (member => PublicTool.convertUtcToLocalTime<MemberList>(member))));
    }

    public static byte[]? DownloadMemberList(MemberFilter? filter, bool hide_member_detail)
    {
      string str = SqlTool.Build<MemberFilter>(filter).Must("(member.is_del = 0)");
      if (AdminConfigService.Find("enable_id_auth").value == "1")
        str = str.Must("member.id_auth = 1");
      if (filter.only_no_recommend)
        str = str.Must("m2.recommend_id IS NULL");
      DataCountBase<MemberList> memberList1 = MemberService.FindMemberList(str, true);
      if (hide_member_detail)
      {
        foreach (MemberList memberList2 in memberList1.data)
        {
          if (!string.IsNullOrEmpty(memberList2.mobile_number))
            memberList2.mobile_number = PublicTool.ReplaceWithSpecialChar(memberList2.mobile_number);
          if (!string.IsNullOrEmpty(memberList2.email))
            memberList2.email = PublicTool.ReplaceWithSpecialChar(memberList2.email);
        }
      }
      return Exportlib.ExportExcel<MemberList>(memberList1.data);
    }

    public static int GetRecommendMemberCount(MemberFilter? filter)
    {
      string str = SqlTool.Build<MemberFilter>(filter).Must("(member.is_del = 0 AND member.is_test_account = 0 AND m2.recommend_id IS NOT NULL)");
      if (AdminConfigService.Find("enable_id_auth").value == "1")
        str = str.Must("member.id_auth = 1");
      return MemberService.FindMemberList(str).count;
    }

    public static int GetNoRecommendMemberCount(MemberFilter? filter)
    {
      string str = SqlTool.Build<MemberFilter>(filter).Must("(member.is_del = 0 AND member.is_test_account = 0 AND m2.recommend_id IS NULL)");
      if (AdminConfigService.Find("enable_id_auth").value == "1")
        str = str.Must("member.id_auth = 1");
      return MemberService.FindMemberList(str).count;
    }

    public static MemberDto Get(int pk, AdminSession adminUser)
    {
      MemberDto memberDto1 = MemberService.Find(pk);
      RecommendRegisterDto recommendRegisterDto = RecommendRegisterService.Find(pk);
      if (recommendRegisterDto != null && MemberService.Find(recommendRegisterDto.member_fk) != null)
      {
        MemberDto memberDto2 = MemberService.Find(recommendRegisterDto.member_fk);
        memberDto1.recommend_name = memberDto2.account;
        memberDto1.recommend = memberDto2.invitation_code;
      }
      if (!AdminRoleBiz.VerifyPower(252, 4, AdminUserService.Find(adminUser.pk).role))
      {
        memberDto1.email = PublicTool.ReplaceWithSpecialChar(memberDto1.email);
        memberDto1.mobile = PublicTool.ReplaceWithSpecialChar(memberDto1.mobile);
      }
      if (memberDto1.richbox_rate != null)
        memberDto1.richbox_rate = (Convert.ToDecimal(memberDto1.richbox_rate) * 100M).ToString();
      return memberDto1;
    }

    public static void PostCreate(MemberDto req)
    {
      if (MemberService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static Decimal NotRecordedInterest(
      int member_fk,
      Decimal total_principal,
      RichboxConfigDto richbox_config)
    {
      DateTime utcNow = DateTime.UtcNow;
      DateTime? nullable1 = RichboxPrincipalService.FirstDate(member_fk);
      DateTime? nullable2 = RichboxInterestService.LastDate(member_fk) ?? RichboxPrincipalService.LastDate(member_fk);
      if (nullable1.HasValue && nullable2.HasValue && total_principal >= richbox_config.begin_profit)
      {
        DateTime dateTime = utcNow;
        DateTime? nullable3 = nullable1;
        if ((nullable3.HasValue ? new TimeSpan?(dateTime - nullable3.GetValueOrDefault()) : new TimeSpan?()).Value.TotalHours >= 24.0)
        {
          Decimal num1 = (Decimal) Math.Max((utcNow - nullable2.Value).TotalMinutes - 1.0, 0.0);
          Decimal num2 = richbox_config.interest_rate / 365M / 24M / 60M;
          return total_principal * num1 * num2;
        }
      }
      return 0M;
    }

    public static void PostEdit(MemberDto req, AdminSession adminUser)
    {
      MemberDto memberDto = MemberService.Find(req.pk);
      Decimal result;
      if (!Decimal.TryParse(req.richbox_rate, out result))
        throw new AppException("財富撲滿利率需為純數字");
      Decimal richbox_rate = result / 100M;
      Decimal num1 = Convert.ToDecimal(memberDto.richbox_rate);
      if (richbox_rate != num1)
      {
        Decimal richBoxRate = MemberService.GetRichBoxRate(req.pk);
        if (MemberService.UpdateRichBoxRate(req.pk, richbox_rate) == 0)
          throw new AppException(3010, "record_update_false");
        Decimal total_principal = RichboxPrincipalService.TotalAmount(req.pk);
        RichboxConfigDto richbox_config = RichboxConfigService.Find();
        richbox_config.interest_rate = richBoxRate;
        Decimal num2 = MemberBiz.NotRecordedInterest(req.pk, total_principal, richbox_config);
        int num3 = (int) RichboxInterestService.Insert(new RichBoxInterestDto()
        {
          member_fk = req.pk,
          amount = num2,
          date = DateTime.UtcNow
        });
      }
      if (MemberService.UpdatePart(req) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 250,
        list = objArray,
        member_account = req.account
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      MemberDto memberDto = MemberService.Find(pk);
      List<TradeAccountDto> tradeAccountByMember = TradeAccountService.GetActiveTradeAccountByMember(pk);
      if (tradeAccountByMember != null && tradeAccountByMember.Count != 0)
        TradeAccountService.BatchInAdvanceClose("where sub_account in (" + string.Join(", ", tradeAccountByMember.Select<TradeAccountDto, string>((Func<TradeAccountDto, string>) (tradeAccountDto => "'" + tradeAccountDto.sub_account + "'"))) + ")", 2, DateTime.UtcNow);
      MemberService.UpdateDel(pk, true);
      MemberService.SetStatus(pk, 0);
      MemberService.RemoveEmailAndIdCard(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) memberDto.account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 251,
        list = objArray,
        member_account = memberDto.account
      });
    }

    public static void Block(int pk, AdminSession adminUser)
    {
      MemberDto memberDto = MemberService.Find(pk);
      MemberService.SetStatus(pk, 0);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) memberDto.account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 252,
        list = objArray,
        member_account = memberDto.account
      });
    }

    public static void Unblock(int pk, AdminSession adminUser)
    {
      MemberDto memberDto = MemberService.Find(pk);
      MemberService.SetStatus(pk, 1);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) memberDto.account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 253,
        list = objArray,
        member_account = memberDto.account
      });
    }

    public static bool loopCheck(int invitee, int inviter, int depth)
    {
      if (depth >= 2)
        return false;
      RecommendRegisterDto byInviteeFk = RecommendRegisterService.FindByInviteeFk(inviter);
      if (byInviteeFk == null)
        return false;
      return byInviteeFk.member_fk == invitee || MemberBiz.loopCheck(invitee, byInviteeFk.member_fk, depth + 1);
    }

    public static void AddInviter(int invitee, string account, AdminSession adminUser)
    {
      if (RecommendRegisterService.FindByInviteeFk(invitee) != null)
        throw new AppException("会员已经设置过推荐人");
      RecommendRegisterService.Find(invitee);
      MemberDto byAccount = MemberService.FindByAccount(account);
      if (MemberBiz.loopCheck(invitee, byAccount.pk, 0))
        throw new AppException("被推荐人的帐号不可為推荐人上層帳號");
      if (byAccount == null)
        throw new AppException("推荐人的帐号不存在");
      if (byAccount.is_test_account)
        throw new AppException("推荐人的帐号不可為測試帐号");
      RecommendRegisterDto model = new RecommendRegisterDto()
      {
        member_fk = byAccount.pk,
        invitee_fk = invitee,
        register_date = DateTime.UtcNow
      };
      List<BorrowDto> firstTrade = BorrowService.FindFirstTrade(byAccount.pk);
      if (firstTrade != null && firstTrade.Count != 0)
      {
        BorrowDto borrowDto = firstTrade.First<BorrowDto>();
        model.first_borrow_date = new DateTime?(borrowDto.verify_time);
      }
      RecommendRegisterService.Insert(model);
      MemberService.UpdateRecommend(invitee, byAccount.invitation_code, byAccount.pk);
      foreach (BorrowFeeDto rec in BorrowFeeService.FindByMemberFk(invitee))
        RecommendBiz.Profit(rec);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) byAccount.account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 250,
        list = objArray,
        member_account = byAccount.account
      });
    }
  }
}
