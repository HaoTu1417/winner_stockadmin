// Decompiled with JetBrains decompiler
// Type: DB.Services.WalletService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.Wallet;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class WalletService
  {
    public static WalletDto Find(int member_fk)
    {
      string sql = "SELECT * FROM `wallet` WHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return readConnection.QueryFirstOrDefault<WalletDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletService][Find]" + ex.Message);
        return (WalletDto) null;
      }
    }

    public static List<WalletDto> FindAll()
    {
      string sql = "SELECT * FROM `wallet`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WalletDto>(sql).AsList<WalletDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletService][FindAll]" + ex.Message);
        return (List<WalletDto>) null;
      }
    }

    public static int Insert(WalletDto model)
    {
      string sql = "INSERT INTO `wallet` (\n                `member_fk`, `currency`, `balance`, `freeze`, `richbox_balance`, `status`, `coupon`, `total_recharge`, `total_withdraw`, `last_update_time`)\n                VALUES (@member_fk, @currency, @balance, @freeze,  @richbox_balance, @status, @coupon, @total_recharge, @total_withdraw, @last_update_time); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(WalletDto model)
    {
      string sql = "UPDATE `wallet` SET \n                `currency` = @currency,\n                `balance` = @balance,\n                `freeze` = @freeze,\n                `richbox_balance` = @richbox_balance,\n                `status` = @status,\n                `coupon` = @coupon,\n                `total_recharge` = @total_recharge,\n                `total_withdraw` = @total_withdraw,\n                `last_update_time` = @last_update_time\n                 WHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int member_fk)
    {
      string sql = "DELETE FROM `wallet` WHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static void BalanceMoneyChange(int member_fk, Decimal change)
    {
      try
      {
        string sql = "\n                UPDATE wallet \n                SET balance = balance + @change\n                ,last_update_time = UTC_TIMESTAMP()\n                WHERE member_fk = @member_fk";
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            change = change,
            member_fk = member_fk
          });
          writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static void FreezeMoneyChange(int member_fk, Decimal change, DateTime updateTime)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          string sql = "\n                UPDATE wallet \n                SET freeze = freeze + @change,\n                last_update_time = @updateTime\n                WHERE member_fk = @member_fk";
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            change = change,
            member_fk = member_fk,
            updateTime = updateTime
          });
          writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static void WithdrawChange(int member_fk, Decimal change, DateTime updateTime)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          string sql = "UPDATE wallet \n                        SET total_withdraw = total_withdraw + @change,\n                        balance = balance - @change,\n                        freeze = freeze - @change,\n                        last_update_time = @updateTime\n                        WHERE member_fk = @member_fk";
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            change = change,
            member_fk = member_fk,
            updateTime = updateTime
          });
          writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletService][WithdrawChange]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static void couponMoneyChange(int member_fk, Decimal change)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          string sql = "\n                UPDATE wallet \n                SET coupon = coupon + @change\n                WHERE member_fk = @member_fk";
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            change = change,
            member_fk = member_fk
          });
          writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static void GmoneyMoneyChange(int member_fk, Decimal change)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          string sql = "\n                UPDATE wallet \n                SET coupon = coupon + @change, last_update_time = UTC_TIMESTAMP()\n                WHERE member_fk = @member_fk";
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            change = change,
            member_fk = member_fk
          });
          writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateWalletStatus(WalletDto model)
    {
      string sql = "UPDATE `wallet` SET \n                `status` = @status\n                 WHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletService][UpdateWalletStatus]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static DataCountBase<WalletList> FindWalletList(int page, int pageSize, string whereSql = "")
    {
      string sql = "\n                        SELECT \n                            COUNT(*) AS count\n                        FROM `wallet`\n                        INNER JOIN member on member.pk = wallet.member_fk\n                        " + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(631, 3);
      interpolatedStringHandler.AppendLiteral("SELECT wallet.member_fk, member.account, member.nickname, wallet.currency, wallet.balance, wallet.freeze, (wallet.balance - wallet.freeze) AS available_balance, wallet.status, wallet.coupon, wallet.total_recharge, wallet.total_withdraw, wallet.last_update_time, member.admin_user_fk, member.id_auth, member.last_login_time, member.last_login_ip, member.is_test_account\n                        FROM `wallet`\n                        INNER JOIN member on member.pk = wallet.member_fk\n                        ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\n                        ORDER BY wallet.last_update_time DESC\n                        LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n                        OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<WalletList>(readConnection.QuerySingle<int>(sql), (IEnumerable<WalletList>) readConnection.Query<WalletList>(stringAndClear).AsList<WalletList>());
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletService][FindWalletList]" + ex.Message);
        return new DataCountBase<WalletList>();
      }
    }

    public static WalletEditVm FindWalletEditVm(int member_fk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(753, 1);
      interpolatedStringHandler.AppendLiteral("SELECT wallet.member_fk, member.account, member.nickname, member.real_name, wallet.currency, wallet.balance, wallet.freeze, (wallet.balance - wallet.freeze) AS available_balance, wallet.richbox_balance, wallet.status, wallet.coupon, wallet.total_recharge, wallet.total_withdraw, wallet.last_update_time, member.admin_user_fk, member.email, member.id_auth, member.create_time, member.create_ip, member.last_login_time, member.last_login_ip, member.auth_time, admin_user.account as admin_user\n                            FROM `wallet`\n                            INNER JOIN member on member.pk = wallet.member_fk\n                            LEFT JOIN admin_user on member.admin_user_fk = admin_user.pk\n                            WHERE wallet.member_fk = ");
      interpolatedStringHandler.AppendFormatted<int>(member_fk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<WalletEditVm>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletService][FindWalletEditVm]" + ex.Message);
        return (WalletEditVm) null;
      }
    }

    public static void Recharge(int member_fk, Decimal change, DateTime updateTime)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          string sql = "UPDATE wallet SET \n                    balance = balance + @change,\n                    total_recharge = total_recharge + @change,\n                    last_update_time = @updateTime\n                    WHERE member_fk = @member_fk";
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            change = change,
            member_fk = member_fk,
            updateTime = updateTime
          });
          writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletService][Recharge]" + ex.Message);
        throw new AppException(1040, "write_db_exception");
      }
    }

    public static bool DebugBalance(int member)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(227, 1);
      interpolatedStringHandler.AppendLiteral("SELECT IFNULL((wallet.`balance` - SUM(wallet_record.affect)),0) AS b\n                FROM `wallet`\n                INNER JOIN wallet_record ON wallet_record.member_fk = wallet.member_fk\n                WHERE wallet.member_fk = ");
      interpolatedStringHandler.AppendFormatted<int>(member);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<Decimal>(stringAndClear) == 0M;
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletService][FindWalletList]" + ex.Message);
        return false;
      }
    }
  }
}
