// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.WalletBiz
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
using stockadmin.ViewModels.Wallet;
using stockadmin.ViewModels.WalletRecord;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class WalletBiz
  {
    public static DataCountBase<WalletList> GetWalletList(
      WalletFilter? filter,
      int page,
      int pageSize)
    {
      string str = SqlTool.Build<WalletFilter>(filter).Must("wallet.status = 1 and member.is_del = 0");
      if (filter.filter_out_test_account)
        str = str.Must("member.is_test_account = 0");
      DataCountBase<WalletList> walletList = WalletService.FindWalletList(page, pageSize, str);
      return new DataCountBase<WalletList>(walletList.count, walletList.data.Select<WalletList, WalletList>((Func<WalletList, WalletList>) (wallet => PublicTool.convertUtcToLocalTime<WalletList>(wallet))));
    }

    public static WalletDto Get(int member_fk) => WalletService.Find(member_fk);

    public static void PostCreate(WalletDto req)
    {
      if (WalletService.Insert(PublicTool.convertLocalToUtcTime<WalletDto>(req)) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(WalletDto req, AdminSession adminUser)
    {
      if (WalletService.UpdateWalletStatus(PublicTool.convertLocalToUtcTime<WalletDto>(req)) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.member_fk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 264,
        list = objArray,
        member_account = MemberService.Find(req.member_fk).account
      });
    }

    public static void Delete(int member_fk) => WalletService.Remove(member_fk);

    public static WalletEditVm GetEditVm(int member_fk)
    {
      WalletEditVm walletEditVm = WalletService.FindWalletEditVm(member_fk);
      walletEditVm.real_name = PublicTool.ReplaceWithSpecialChar(walletEditVm.real_name);
      return walletEditVm;
    }

    public static WalletChangeExceptionVm GetChangeException(int member_fk)
    {
      WalletEditVm walletEditVm = WalletService.FindWalletEditVm(member_fk);
      return new WalletChangeExceptionVm()
      {
        member_fk = walletEditVm.member_fk,
        account = walletEditVm.account,
        real_name = walletEditVm.real_name,
        currency = walletEditVm.currency,
        balance = walletEditVm.balance,
        coupon = walletEditVm.coupon
      };
    }

    public static byte[]? DownloadWalletList(WalletFilter? filter)
    {
      return Exportlib.ExportExcel<WalletList>(WalletBiz.GetWalletList(filter ?? new WalletFilter(), 1, int.MaxValue).data);
    }
  }
}
