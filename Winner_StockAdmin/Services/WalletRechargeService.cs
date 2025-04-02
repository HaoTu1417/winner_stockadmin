// Decompiled with JetBrains decompiler
// Type: DB.Services.WalletRechargeService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.HisWalletRecharge;
using stockadmin.ViewModels.Wallet;
using stockadmin.ViewModels.WalletRecharge;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class WalletRechargeService
  {
    public static WalletRechargeDto Find(int pk)
    {
      string sql = "SELECT * FROM `wallet_recharge` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<WalletRechargeDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRechargeService][Find]" + ex.Message);
        return (WalletRechargeDto) null;
      }
    }

    public static Decimal GetTotalAmount(string pay_name)
    {
      string sql = "SELECT SUM(wallet_amount) FROM `wallet_recharge` WHERE `line_bank` = @pay_name AND status = 1";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pay_name = pay_name
          });
          return readConnection.ExecuteScalar<Decimal>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRechargeService][GetTotalAmount]" + ex.Message);
        return 0M;
      }
    }

    public static List<WalletRechargeDto> FindAll()
    {
      string sql = "SELECT * FROM `wallet_recharge`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WalletRechargeDto>(sql).AsList<WalletRechargeDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRechargeService][FindAll]" + ex.Message);
        return (List<WalletRechargeDto>) null;
      }
    }

    public static int FindPkAfterInsert(WalletRechargeDto source)
    {
      string sql = "INSERT INTO `wallet_recharge` (\n\t\t\t\t`member_fk`, `agent_id`, `admin_bank_fk`, `order_no`, `money`, `type`, `fee`, `create_time`, `create_ip`, `line_bank`, `status`, `receipt_img`, `charge_type_id`, `form_name`, `currency`)\n\t\t\t\tVALUES (@member_fk, @agent_id, @admin_bank_fk, @order_no, @money, @type, @fee, @create_time, @create_ip, @line_bank, @status, @receipt_img, @charge_type_id, @form_name, @currency);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRechargeService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(WalletRechargeDto model)
    {
      string sql = "UPDATE `wallet_recharge` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`agent_id` = @agent_id,\n\t\t\t\t`admin_bank_fk` = @admin_bank_fk,\n\t\t\t\t`order_no` = @order_no,\n\t\t\t\t`money` = @money,\n\t\t\t\t`type` = @type,\n\t\t\t\t`fee` = @fee,\n\t\t\t\t`create_time` = @create_time,\n\t\t\t\t`create_ip` = @create_ip,\n\t\t\t\t`line_bank` = @line_bank,\n\t\t\t\t`status` = @status,\n\t\t\t\t`receipt_img` = @receipt_img,\n\t\t\t\t`charge_type_id` = @charge_type_id,\n\t\t\t\t`form_name` = @form_name,\n\t\t\t\t`currency` = @currency\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRechargeService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `wallet_recharge` WHERE `pk` = @pk";
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
        LogLib.Log("[WalletRechargeService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static DataCountBase<HisWalletRechargeList> FindHisWalletRechargeList(
      int page,
      int pageSize,
      string whereSql = "",
      string where_third_party = "",
      string lang = "VN")
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1053, 2);
      interpolatedStringHandler.AppendLiteral("\n                    SELECT COUNT(0) as count \n                    FROM\n                    (\n                        SELECT wallet_recharge.pk\n                        FROM `wallet_recharge`\n                        LEFT JOIN `member` ON member.pk = wallet_recharge.member_fk\n                        LEFT JOIN admin_bank ON admin_bank.pk = wallet_recharge.admin_bank_fk\n                        LEFT JOIN admin_user ON admin_user.pk = wallet_recharge.verify_admin_pk\n                        ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral(" AND wallet_recharge.type != 'third_party'\n\n                        UNION ALL\n\n                        SELECT wallet_recharge.pk\n                        FROM `wallet_recharge`\n                        LEFT JOIN `member` ON member.pk = wallet_recharge.member_fk\n                        LEFT JOIN wallet_payment ON wallet_payment.pk = wallet_recharge.admin_bank_fk\n                        LEFT JOIN admin_user ON admin_user.pk = wallet_recharge.verify_admin_pk\n                        ");
      interpolatedStringHandler.AppendFormatted(where_third_party);
      interpolatedStringHandler.AppendLiteral(" AND wallet_recharge.type = 'third_party'\n                    ) AS combinedResult;");
      string stringAndClear1 = interpolatedStringHandler.ToStringAndClear();
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(2487, 6);
      interpolatedStringHandler.AppendLiteral("\n                    SELECT * \n                    FROM\n                    (\n                        SELECT wallet_recharge.status, wallet_recharge.verify_admin_pk, admin_user.account AS admin_name, wallet_recharge.verify_time, wallet_recharge.reject_result, \n                        wallet_recharge.order_no, wallet_recharge.create_time, admin_bank.card as card, admin_bank.bank_name, admin_bank.payee, \n                        wallet_recharge.line_bank, wallet_recharge.pk, wallet_recharge.type, wallet_recharge.currency, wallet_recharge.money, wallet_recharge.balance, \n                        wallet_recharge.exchange, wallet_recharge.wallet_amount, member.account, member.nickname, member.is_test_account, '");
      interpolatedStringHandler.AppendFormatted(lang);
      interpolatedStringHandler.AppendLiteral("' as admin_lang\n                        FROM `wallet_recharge`\n                        LEFT JOIN `member` ON member.pk = wallet_recharge.member_fk\n                        LEFT JOIN admin_bank ON admin_bank.pk = wallet_recharge.admin_bank_fk\n                        LEFT JOIN admin_user ON admin_user.pk = wallet_recharge.verify_admin_pk\n                        ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral(" AND wallet_recharge.type != 'third_party'\n\n                        UNION ALL\n\n                        SELECT wallet_recharge.status, wallet_recharge.verify_admin_pk, admin_user.account AS admin_name, IFNULL(NULLIF(wallet_recharge.verify_time, '0000-00-00 00:00:00'), NULL) as verify_time, wallet_recharge.reject_result, \n                        wallet_recharge.order_no, IFNULL(NULLIF(wallet_recharge.create_time, '0000-00-00 00:00:00'), NULL) as create_time, wallet_payment.pay_code as card, wallet_payment.pay_name as bank_name, wallet_payment.pay_name as payee, \n                        wallet_recharge.line_bank, wallet_recharge.pk, wallet_recharge.type, wallet_recharge.currency, wallet_recharge.money,  wallet_recharge.balance, \n                        wallet_recharge.exchange, wallet_recharge.wallet_amount, member.account, member.nickname, member.is_test_account, '");
      interpolatedStringHandler.AppendFormatted(lang);
      interpolatedStringHandler.AppendLiteral("' as admin_lang\n                        FROM `wallet_recharge`\n                        LEFT JOIN `member` ON member.pk = wallet_recharge.member_fk\n                        LEFT JOIN wallet_payment ON wallet_payment.pk = wallet_recharge.admin_bank_fk\n                        LEFT JOIN admin_user ON admin_user.pk = wallet_recharge.verify_admin_pk\n                        ");
      interpolatedStringHandler.AppendFormatted(where_third_party);
      interpolatedStringHandler.AppendLiteral(" AND wallet_recharge.type = 'third_party'\n                    ) t\n                    ORDER BY t.verify_time DESC\n                    LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n                    OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear2 = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<HisWalletRechargeList>(readConnection.QuerySingle<int>(stringAndClear1), (IEnumerable<HisWalletRechargeList>) readConnection.Query<HisWalletRechargeList>(stringAndClear2).AsList<HisWalletRechargeList>());
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        LogLib.Log("[WalletRechargeService][FindHisWalletRechargeList]" + ex.Message);
        return new DataCountBase<HisWalletRechargeList>();
      }
    }

    public static DataCountBase<WalletRechargeList> FindWalletRechargeList(
      int page,
      int pageSize,
      string whereSql = "")
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1017, 2);
      interpolatedStringHandler.AppendLiteral("\n                    SELECT COUNT(0) as count \n                    FROM\n                    (\n                        SELECT wallet_recharge.pk\n                        FROM `wallet_recharge`\n                        INNER JOIN `member` ON member.pk = wallet_recharge.member_fk\n                        INNER JOIN `wallet` ON member.pk = wallet.member_fk\n                        INNER JOIN admin_bank ON admin_bank.pk = wallet_recharge.admin_bank_fk\n                        ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral(" AND wallet_recharge.type != 'third_party'\n\n                        UNION ALL\n\n                        SELECT wallet_recharge.pk\n                        FROM `wallet_recharge`\n                        INNER JOIN `member` ON member.pk = wallet_recharge.member_fk\n                        INNER JOIN `wallet` ON member.pk = wallet.member_fk\n                        INNER JOIN wallet_payment ON wallet_payment.pk = wallet_recharge.admin_bank_fk\n                        ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral(" AND wallet_recharge.type = 'third_party'\n                    ) AS combinedResult;");
      string stringAndClear1 = interpolatedStringHandler.ToStringAndClear();
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(2311, 4);
      interpolatedStringHandler.AppendLiteral("\n                    SELECT * \n                    FROM\n                    (\n                        SELECT wallet_recharge.create_time, admin_bank.card, admin_bank.bank_name, admin_bank.payee, wallet_recharge.order_no, \n                        wallet_recharge.line_bank, wallet_recharge.pk, wallet_recharge.type, wallet_recharge.currency, wallet_recharge.money,  wallet.balance as balance, \n                        wallet_recharge.exchange, wallet_recharge.wallet_amount, wallet_recharge.member_fk, member.account, member.nickname, \n                        wallet_recharge.create_ip, wallet_recharge.status, member.admin_user_fk, member.id_auth, member.level_id , wallet_recharge.last_five, member.is_test_account\n                        FROM `wallet_recharge`\n                        INNER JOIN `member` ON member.pk = wallet_recharge.member_fk\n                        INNER JOIN `wallet` ON member.pk = wallet.member_fk\n                        INNER JOIN admin_bank ON admin_bank.pk = wallet_recharge.admin_bank_fk\n                        ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral(" AND wallet_recharge.type != 'third_party'\n\n                        UNION ALL\n\n                        SELECT wallet_recharge.create_time, wallet_payment.pay_code as card, wallet_payment.pay_name as bank_name, wallet_payment.pay_name as payee, wallet_recharge.order_no, \n                        wallet_recharge.line_bank, wallet_recharge.pk, wallet_recharge.type, wallet_recharge.currency, wallet_recharge.money,  wallet.balance as balance, \n                        wallet_recharge.exchange, wallet_recharge.wallet_amount, wallet_recharge.member_fk, member.account, member.nickname, \n                        wallet_recharge.create_ip, wallet_recharge.status, member.admin_user_fk, member.id_auth, member.level_id, wallet_recharge.last_five, member.is_test_account\n                        FROM `wallet_recharge`\n                        INNER JOIN `member` ON member.pk = wallet_recharge.member_fk\n                        INNER JOIN `wallet` ON member.pk = wallet.member_fk\n                        INNER JOIN wallet_payment ON wallet_payment.pk = wallet_recharge.admin_bank_fk\n                        ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral(" AND wallet_recharge.type = 'third_party'\n                    ) t\n                    ORDER BY t.create_time DESC\n                    LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n                    OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear2 = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<WalletRechargeList>(readConnection.QuerySingle<int>(stringAndClear1), (IEnumerable<WalletRechargeList>) readConnection.Query<WalletRechargeList>(stringAndClear2).AsList<WalletRechargeList>());
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        LogLib.Log("[WalletRechargeService][FindWalletRechargeList]" + ex.Message);
        return new DataCountBase<WalletRechargeList>();
      }
    }

    public static WalletRechargeReview FindWalletRechargeReview(int pk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(831, 1);
      interpolatedStringHandler.AppendLiteral("SELECT wallet_recharge.create_time, admin_bank.card, admin_bank.bank_name, admin_bank.payee, wallet_recharge.order_no, \n                wallet_recharge.line_bank, wallet_recharge.pk, wallet_recharge.type, wallet_recharge.currency, wallet_recharge.money, \n                wallet_recharge.exchange, wallet_recharge.wallet_amount, wallet_recharge.member_fk, member.account, member.nickname, \n                wallet_recharge.create_ip, wallet_recharge.status, wallet_recharge.form_name, wallet_recharge.reject_result, member.admin_user_fk, member.id_auth, \n                member.level_id \n                FROM `wallet_recharge`\n                INNER JOIN `member` ON member.pk = wallet_recharge.member_fk\n                LEFT JOIN admin_bank ON admin_bank.pk = wallet_recharge.admin_bank_fk\n                WHERE wallet_recharge.pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<WalletRechargeReview>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRechargeService][FindWalletRechargeReview]" + ex.Message);
        return (WalletRechargeReview) null;
      }
    }

    public static List<WalletRechargeSearchList> GetRecharge(string where)
    {
      string sql = "SELECT * FROM `wallet_recharge` " + where;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WalletRechargeSearchList>(sql).AsList<WalletRechargeSearchList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRechargeService][GetRecharge]" + ex.Message);
        return (List<WalletRechargeSearchList>) null;
      }
    }

    public static int GetRechargeApplyCount()
    {
      string sql = "SELECT COUNT(*) FROM `wallet_recharge` INNER JOIN `member` ON (wallet_recharge.member_fk = `member`.pk AND member.is_del = 0) where wallet_recharge.status = 0";
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

    public static int AccecptRecharge(int pk, Decimal balance, int verifyAdminPk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(159, 3);
      interpolatedStringHandler.AppendLiteral("UPDATE `wallet_recharge` SET \n\t\t\t\t`verify_admin_pk` = ");
      interpolatedStringHandler.AppendFormatted<int>(verifyAdminPk);
      interpolatedStringHandler.AppendLiteral(",\n                `balance` = ");
      interpolatedStringHandler.AppendFormatted<Decimal>(balance);
      interpolatedStringHandler.AppendLiteral(",\n\t\t\t\t`verify_time` = UTC_TIMESTAMP(),\n\t\t\t\t`status` = 1\t\n\t\t\t\t WHERE `pk` = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRechargeService][AccecptRecharge]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int RejectRecharge(
      int pk,
      Decimal balance,
      int verifyAdminPk,
      string rejectResult)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(196, 4);
      interpolatedStringHandler.AppendLiteral("UPDATE `wallet_recharge` SET \n                `verify_admin_pk` = ");
      interpolatedStringHandler.AppendFormatted<int>(verifyAdminPk);
      interpolatedStringHandler.AppendLiteral(",\n                `balance` = ");
      interpolatedStringHandler.AppendFormatted<Decimal>(balance);
      interpolatedStringHandler.AppendLiteral(",\n\t\t\t\t`verify_time` = UTC_TIMESTAMP(),\n\t\t\t\t`status` = 2,\n\t\t\t\t`reject_result` = '");
      interpolatedStringHandler.AppendFormatted(rejectResult);
      interpolatedStringHandler.AppendLiteral("'\n\t\t\t\t WHERE `pk` = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRechargeService][RejectRecharge]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static Decimal GetRechargeNeedVerify()
    {
      string sql = "SELECT SUM(wallet_amount) FROM `wallet_recharge`\n                INNER JOIN `member` ON member.pk = wallet_recharge.member_fk\n                WHERE `wallet_recharge`.`status` = 0 AND member.is_test_account = 0  AND member.is_del = 0";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.ExecuteScalar<Decimal>(sql);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRechargeService][GetRechargeNeedVerify]" + ex.Message);
        return 0M;
      }
    }
  }
}
