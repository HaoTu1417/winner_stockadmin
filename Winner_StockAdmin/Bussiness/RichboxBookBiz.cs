// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.RichboxBookBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
// using NuGet.Packaging;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.Member;
using stockadmin.ViewModels.RichboxBook;
using System;
using System.Collections.Generic;
using System.Linq;
using tradeapi.Models.RichBox;

#nullable enable
namespace stockadmin.Business
{
  public class RichboxBookBiz
  {
    public static Decimal PrincipalTotalAmount(
      int member_fk,
      List<RichBoxPrincipalDto> richBox_principal_list)
    {
      List<RichBoxPrincipalDto> all = richBox_principal_list.FindAll((Predicate<RichBoxPrincipalDto>) (x => x.member_fk == member_fk));
      return all.Count != 0 ? all.Sum<RichBoxPrincipalDto>((Func<RichBoxPrincipalDto, Decimal>) (x => x.amount)) : 0M;
    }

    public static DateTime? PrincipalFirstDate(
      int member_fk,
      List<RichBoxPrincipalDto> richBox_principal_list)
    {
      List<RichBoxPrincipalDto> all = richBox_principal_list.FindAll((Predicate<RichBoxPrincipalDto>) (x => x.member_fk == member_fk));
      return all.Count != 0 ? new DateTime?(all.Min<RichBoxPrincipalDto, DateTime>((Func<RichBoxPrincipalDto, DateTime>) (x => x.date))) : new DateTime?();
    }

    public static DateTime? InterestLastDate(
      int member_fk,
      List<RichBoxInterestDto> richBox_interest_list)
    {
      List<RichBoxInterestDto> all = richBox_interest_list.FindAll((Predicate<RichBoxInterestDto>) (x => x.member_fk == member_fk));
      return all.Count != 0 ? new DateTime?(all.Max<RichBoxInterestDto, DateTime>((Func<RichBoxInterestDto, DateTime>) (x => x.date))) : new DateTime?();
    }

    private static Decimal NotRecordedInterest(
      int member_fk,
      RichboxConfigDto richbox_config,
      List<RichBoxPrincipalDto> richBox_principal_list,
      List<RichBoxInterestDto> richBox_interest_list)
    {
      Decimal num1 = RichboxBookBiz.PrincipalTotalAmount(member_fk, richBox_principal_list);
      DateTime utcNow = DateTime.UtcNow;
      DateTime? nullable1 = RichboxBookBiz.PrincipalFirstDate(member_fk, richBox_principal_list);
      DateTime? nullable2 = RichboxBookBiz.InterestLastDate(member_fk, richBox_interest_list);
      if (nullable1.HasValue && nullable2.HasValue && num1 >= richbox_config.begin_profit)
      {
        DateTime dateTime = utcNow;
        DateTime? nullable3 = nullable1;
        if ((nullable3.HasValue ? new TimeSpan?(dateTime - nullable3.GetValueOrDefault()) : new TimeSpan?()).Value.TotalHours >= 24.0)
        {
          Decimal num2 = (Decimal) Math.Max((utcNow - nullable2.Value).TotalMinutes - 1.0, 0.0);
          Decimal num3 = richbox_config.interest_rate / 365M / 24M / 60M;
          return num1 * num2 * num3;
        }
      }
      return 0M;
    }

    private static Decimal InterestTotalRecordedAmount(
      int member_fk,
      List<RichBoxInterestDto> richBox_interest_list)
    {
      List<RichBoxInterestDto> all = richBox_interest_list.FindAll((Predicate<RichBoxInterestDto>) (x => x.member_fk == member_fk));
      return all.Count != 0 ? all.Sum<RichBoxInterestDto>((Func<RichBoxInterestDto, Decimal>) (x => x.amount)) : 0M;
    }

    private static Decimal InterestGrandTotalRecordedAmount(
      int member_fk,
      List<RichBoxInterestDto> richBox_interest_list)
    {
      List<RichBoxInterestDto> all = richBox_interest_list.FindAll((Predicate<RichBoxInterestDto>) (x => x.member_fk == member_fk && x.amount > 0M));
      return all.Count != 0 ? all.Sum<RichBoxInterestDto>((Func<RichBoxInterestDto, Decimal>) (x => x.amount)) : 0M;
    }

    private static Decimal AssetsMaxAmount(
      int member_fk,
      List<RichBoxPrincipalDto> richBox_principal_list,
      List<RichBoxInterestDto> richBox_interest_list)
    {
      Dictionary<DateTime, Decimal> dictionary = new Dictionary<DateTime, Decimal>();
      // dictionary.AddRange<KeyValuePair<DateTime, Decimal>>((IEnumerable<KeyValuePair<DateTime, Decimal>>) richBox_principal_list.FindAll((Predicate<RichBoxPrincipalDto>) (x => x.member_fk == member_fk)).ToDictionary<RichBoxPrincipalDto, DateTime, Decimal>((Func<RichBoxPrincipalDto, DateTime>) (x => x.date), (Func<RichBoxPrincipalDto, Decimal>) (x => x.amount)));
      //
      dictionary = richBox_principal_list
        .FindAll(x => x.member_fk == member_fk)
        .ToDictionary(x => x.date, x => x.amount);

      foreach (var item in richBox_interest_list.FindAll(x => x.member_fk == member_fk))
      {
        dictionary[item.date] = item.amount;
      }
      
      
      // dictionary.AddRange<KeyValuePair<DateTime, Decimal>>((IEnumerable<KeyValuePair<DateTime, Decimal>>) richBox_interest_list.FindAll((Predicate<RichBoxInterestDto>) (x => x.member_fk == member_fk)).ToDictionary<RichBoxInterestDto, DateTime, Decimal>((Func<RichBoxInterestDto, DateTime>) (x => x.date), (Func<RichBoxInterestDto, Decimal>) (x => x.amount)));
      //
      foreach (var item in richBox_interest_list.FindAll(x => x.member_fk == member_fk))
      {
        dictionary[item.date] = item.amount;
      }

      dictionary = dictionary.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
      
      dictionary.OrderBy<KeyValuePair<DateTime, Decimal>, DateTime>((Func<KeyValuePair<DateTime, Decimal>, DateTime>) (x => x.Key));
      Decimal num1 = 0M;
      Decimal num2 = 0M;
      foreach (KeyValuePair<DateTime, Decimal> keyValuePair in dictionary)
      {
        num2 += keyValuePair.Value;
        if (num2 > num1)
          num1 = num2;
      }
      return num1;
    }

    public static List<RichboxBookList> GetRichboxBookList(RichboxBookFilter? filter)
    {
      string str = SqlTool.Build<RichboxBookFilter>(filter).Must("member.is_del = 0 AND member.is_test_account = 0");
      if (filter.filter_out_test_account)
        str = str.Must("member.is_test_account = 0");
      DataCountBase<MemberList> memberList = MemberService.FindMemberList(str, true);
      return memberList.data != null && memberList.count > 0 ? memberList.data.Select<MemberList, RichboxBookList>((Func<MemberList, RichboxBookList>) (x => new RichboxBookList()
      {
        is_test_account = x.is_test_account,
        account = x.account,
        real_name = x.real_name,
        total_assets = x.richbox_balance,
        total_earing = x.richbox_interest
      })).OrderByDescending<RichboxBookList, Decimal>((Func<RichboxBookList, Decimal>) (x => x.total_earing)).ToList<RichboxBookList>() : new List<RichboxBookList>();
    }

    public static List<RichHistoryResponse> GetHistory(string account)
    {
      MemberDto byAccount = MemberService.FindByAccount(account);
      int member_fk = 0;
      if (byAccount != null)
        member_fk = byAccount.pk;
      List<RichboxRecordDto> allByMember = RichboxRecordService.FindAllByMember(member_fk);
      List<RichHistoryResponse> source = new List<RichHistoryResponse>();
      source.AddRange(allByMember.Select<RichboxRecordDto, RichHistoryResponse>((Func<RichboxRecordDto, RichHistoryResponse>) (x => new RichHistoryResponse()
      {
        src = x.src,
        src_string = x.src == 1 ? "本金" : "利息",
        date = x.create_time,
        type_string = x.affect > 0M ? "存入" : "轉出",
        amount = x.affect,
        blance = x.balance
      })));
      return source.OrderByDescending<RichHistoryResponse, DateTime>((Func<RichHistoryResponse, DateTime>) (x => x.date)).ToList<RichHistoryResponse>();
    }
  }
}
