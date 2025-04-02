// Decompiled with JetBrains decompiler
// Type: DB.Services.WalletWithdrawService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.EndWalletWithdraw;
using stockadmin.ViewModels.WalletWithdraw;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class WalletWithdrawService
  {
    public static WalletWithdrawDto Find(int pk)
    {
      string sql = "SELECT * FROM `wallet_withdraw` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<WalletWithdrawDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletWithdrawService][Find]" + ex.Message);
        return (WalletWithdrawDto) null;
      }
    }

    public static List<WalletWithdrawDto> FindAll()
    {
      string sql = "SELECT * FROM `wallet_withdraw`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WalletWithdrawDto>(sql).AsList<WalletWithdrawDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletWithdrawService][FindAll]" + ex.Message);
        return (List<WalletWithdrawDto>) null;
      }
    }

    public static int FindPkAfterInsert(WalletWithdrawDto source)
    {
      string sql = "INSERT INTO `wallet_withdraw` (\n\t\t\t\t`member_fk`, `member_bank_fk`, `order_no`, `wallet_amount`, `exchange`, `currency`, `money`, `fee`, `status`, `note`, `create_time`, `create_ip`, `verify_admin_pk`, `verify_time`, `reject_result`)\n\t\t\t\tVALUES (@member_fk, @member_bank_fk, @order_no, @wallet_amount, @exchange, @currency, @money, @fee, @status, @note, @create_time, @create_ip, @verify_admin_pk, @verify_time, @reject_result);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletWithdrawService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(WalletWithdrawDto model)
    {
      string sql = "UPDATE `wallet_withdraw` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`member_bank_fk` = @member_bank_fk,\n\t\t\t\t`order_no` = @order_no,\n\t\t\t\t`wallet_amount` = @wallet_amount,\n\t\t\t\t`exchange` = @exchange,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`money` = @money,\n\t\t\t\t`fee` = @fee,\n\t\t\t\t`status` = @status,\n\t\t\t\t`note` = @note,\n\t\t\t\t`create_time` = @create_time,\n\t\t\t\t`create_ip` = @create_ip,\n\t\t\t\t`verify_admin_pk` = @verify_admin_pk,\n\t\t\t\t`verify_time` = @verify_time,\n\t\t\t\t`reject_result` = @reject_result\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletWithdrawService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `wallet_withdraw` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletWithdrawService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int VerifyWithdraw(
      int pk,
      Decimal balance,
      int adminPk,
      int status,
      string? rejectResult)
    {
      string sql = "UPDATE `wallet_withdraw` SET \n\t\t\t\t`verify_admin_pk` = @verifyAdminPk,\n                `balance` = @balance,\n\t\t\t\t`verify_time` = @verifyTime,\n\t\t\t\t`status` = @status,\n\t\t\t\t`reject_result` = @rejectResult\t\t\t\t\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            pk = pk,
            verifyAdminPk = adminPk,
            balance = balance,
            verifyTime = DateTime.UtcNow,
            status = status,
            rejectResult = rejectResult
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRechargeService][VerifyRecharge]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static EndWalletWithdrawEditVm FindEndWalletWithdrawEditVm(int pk, string lang)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(719, 2);
      interpolatedStringHandler.AppendLiteral("SELECT wallet_withdraw.verify_time, wallet_withdraw.verify_admin_pk, wallet_withdraw.status, wallet_withdraw.reject_result, \n                wallet_withdraw.create_time, wallet_withdraw.order_no, wallet_withdraw.wallet_amount, wallet_withdraw.exchange, wallet_withdraw.currency, \n                wallet_withdraw.money, member_bank.card, member_bank.account as bank_account, member.account, member.nickname, member_bank.bank, member_bank.branch, '");
      interpolatedStringHandler.AppendFormatted(lang);
      interpolatedStringHandler.AppendLiteral("' as admin_lang\n                FROM `wallet_withdraw`\n                INNER JOIN member_bank on member_bank.card_pk = wallet_withdraw.member_bank_fk\n                INNER JOIN `member` on member.pk = wallet_withdraw.member_fk   \n                where wallet_withdraw.pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<EndWalletWithdrawEditVm>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletWithdrawService][FindEndWalletWithdrawEditVm]" + ex.Message);
        return (EndWalletWithdrawEditVm) null;
      }
    }

    public static DataCountBase<EndWalletWithdrawList> FindEndWalletWithdrawList(
      int page,
      int pageSize,
      string whereSql = "",
      string lang = "VN")
    {
      string sql = "\n                            SELECT \n                                COUNT(*) AS count\n                            FROM `wallet_withdraw`\n                            INNER JOIN member_bank on member_bank.card_pk = wallet_withdraw.member_bank_fk\n                            INNER JOIN `member` on member.pk = wallet_withdraw.member_fk\n                            LEFT JOIN `admin_user` on admin_user.pk = wallet_withdraw.verify_admin_pk\n                            " + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1050, 4);
      interpolatedStringHandler.AppendLiteral("SELECT wallet_withdraw.status, wallet_withdraw.verify_time, wallet_withdraw.verify_admin_pk, admin_user.account as admin_account, wallet_withdraw.reject_result, wallet_withdraw.create_time, \n                    wallet_withdraw.order_no, wallet_withdraw.wallet_amount, wallet_withdraw.exchange, wallet_withdraw.currency, wallet_withdraw.money, wallet_withdraw.balance,\n                    wallet_withdraw.pk, member_bank.bank, member_bank.branch, member_bank.card, member_bank.account as bank_account, member.account, \n                    member.nickname, member.is_test_account, '");
      interpolatedStringHandler.AppendFormatted(lang);
      interpolatedStringHandler.AppendLiteral("' as admin_lang\n                    FROM `wallet_withdraw`\n                    INNER JOIN member_bank on member_bank.card_pk = wallet_withdraw.member_bank_fk\n                    INNER JOIN `member` on member.pk = wallet_withdraw.member_fk\n                    LEFT JOIN `admin_user` on admin_user.pk = wallet_withdraw.verify_admin_pk\n                    ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\n                    ORDER BY wallet_withdraw.verify_time DESC\n                    LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n                    OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<EndWalletWithdrawList>(readConnection.QuerySingle<int>(sql), (IEnumerable<EndWalletWithdrawList>) readConnection.Query<EndWalletWithdrawList>(stringAndClear).AsList<EndWalletWithdrawList>());
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletWithdrawService][FindEndWalletWithdrawList]" + ex.Message);
        return new DataCountBase<EndWalletWithdrawList>();
      }
    }

    public static DataCountBase<WalletWithdrawList> FindWalletWithdrawList(
      int page,
      int pageSize,
      string whereSql = "")
    {
      string sql = "\n                SELECT \n                    COUNT(*) AS count\n                FROM `wallet_withdraw`\n                INNER JOIN member_bank on member_bank.card_pk = wallet_withdraw.member_bank_fk\n                INNER JOIN `member` on member.pk = wallet_withdraw.member_fk\n                " + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(800, 3);
      interpolatedStringHandler.AppendLiteral("SELECT wallet_withdraw.create_time, wallet_withdraw.order_no, wallet_withdraw.wallet_amount, wallet_withdraw.exchange, \n                wallet_withdraw.currency, wallet_withdraw.money, wallet_withdraw.pk, member_bank.bank, member_bank.branch, member_bank.card, \n                member_bank.account AS bank_account, member.account, member.nickname, member.is_test_account, wallet.balance as balance \n                FROM `wallet_withdraw`\n                INNER JOIN member_bank on member_bank.card_pk = wallet_withdraw.member_bank_fk\n                INNER JOIN `member` on member.pk = wallet_withdraw.member_fk\n                INNER JOIN `wallet` ON member.pk = wallet.member_fk\n                ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\n                ORDER BY wallet_withdraw.create_time DESC\n                LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n                OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<WalletWithdrawList>(readConnection.QuerySingle<int>(sql), (IEnumerable<WalletWithdrawList>) readConnection.Query<WalletWithdrawList>(stringAndClear).AsList<WalletWithdrawList>());
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletWithdrawService][FindWalletWithdrawList]" + ex.Message);
        return new DataCountBase<WalletWithdrawList>();
      }
    }

    public static WalletWithdrawReview FindWalletWithdrawReview(int pk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(808, 1);
      interpolatedStringHandler.AppendLiteral("SELECT wallet_withdraw.create_time, wallet_withdraw.order_no, wallet_withdraw.wallet_amount, wallet_withdraw.exchange, \n                wallet_withdraw.currency, wallet_withdraw.money, wallet_withdraw.member_bank_fk, wallet_withdraw.pk, wallet_withdraw.status, wallet_withdraw.id_selfie,\n                member_bank.currency, member_bank.is_confirm, member_bank.bank, member_bank.branch, member_bank.card, member_bank.account AS bank_account, member.account, \n                member.nickname, member.id_auth, member.admin_user_fk, member.pk AS member_fk\n                FROM `wallet_withdraw`\n                INNER JOIN member_bank on member_bank.card_pk = wallet_withdraw.member_bank_fk\n                INNER JOIN `member` on member.pk = wallet_withdraw.member_fk\n                WHERE wallet_withdraw.pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<WalletWithdrawReview>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletWithdrawService][FindWalletWithdrawReview]" + ex.Message);
        return (WalletWithdrawReview) null;
      }
    }

    public static int GetWithdrawApplyCount()
    {
      string sql = "SELECT COUNT(*) FROM `wallet_withdraw` INNER JOIN `member` ON (wallet_withdraw.member_fk = `member`.pk AND member.is_del = 0) where wallet_withdraw.status = 0";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.ExecuteScalar<int>(sql);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRechargeService][GetRechargeApplyCount]" + ex.Message);
        return 0;
      }
    }

    public static Decimal GetWithdrawNeedVerify()
    {
      try
      {
        string sql = "SELECT SUM(wallet_amount) FROM `wallet_withdraw`\n                            INNER JOIN `member` ON (member.pk = wallet_withdraw.member_fk AND member.is_test_account = 0 AND member.is_del = 0) WHERE wallet_withdraw.status = 0";
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.ExecuteScalar<Decimal>(sql);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletWithdrawService][GetWithdrawNeedVerify]" + ex.Message);
        return 0M;
      }
    }
  }
}
