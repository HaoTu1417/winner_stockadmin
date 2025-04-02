// Decompiled with JetBrains decompiler
// Type: DB.Services.WalletRecordService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.StatBalance;
using stockadmin.ViewModels.StatWalletRecordDetail;
using stockadmin.ViewModels.WalletRecord;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class WalletRecordService
  {
    public static WalletRecordDto Find(int pk)
    {
      string sql = "SELECT * FROM `wallet_record` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<WalletRecordDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRecordService][Find]" + ex.Message);
        return (WalletRecordDto) null;
      }
    }

    public static List<WalletRecordDto> FindAll()
    {
      string sql = "SELECT * FROM `wallet_record`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WalletRecordDto>(sql).AsList<WalletRecordDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRecordService][FindAll]" + ex.Message);
        return (List<WalletRecordDto>) null;
      }
    }

    public static int FindPkAfterInsert(WalletRecordDto source)
    {
      string sql = "INSERT INTO `wallet_record` (\n\t\t\t\t`member_fk`, `type`, `currency`, `affect`, `freeze`, `balance`, `coupon`, `param`, `templat_id`, `info`, `create_time`, `create_ip`)\n\t\t\t\tVALUES (@member_fk, @type, @currency, @affect, @freeze, @balance, @coupon, @param, @templat_id, @info, @create_time, @create_ip);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRecordService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(WalletRecordDto model)
    {
      string sql = "UPDATE `wallet_record` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`type` = @type,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`affect` = @affect,\n\t\t\t\t`freeze` = @freeze,\n\t\t\t\t`balance` = @balance,\n\t\t\t\t`coupon` = @coupon,\n\t\t\t\t`param` = @param,\n\t\t\t\t`templat_id` = @templat_id,\n\t\t\t\t`info` = @info,\n\t\t\t\t`create_time` = @create_time,\n\t\t\t\t`create_ip` = @create_ip\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRecordService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `wallet_record` WHERE `pk` = @pk";
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
        LogLib.Log("[WalletRecordService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static DataCountBase<StatWalletRecordDetailList> FindStatWalletRecordDetailList(
      int page,
      int pageSize,
      string whereSql = "",
      string lang = "CN")
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(490, 2);
      interpolatedStringHandler.AppendLiteral("\n                SELECT \n                    COUNT(*) AS count\n                FROM `wallet_record`\n                INNER JOIN `member` ON wallet_record.member_fk = member.pk \n                INNER JOIN `sys_market` ON wallet_record.currency=sys_market.currency\n                LEFT JOIN `wallet_template` ON wallet_record.templat_id = wallet_template.temp_id AND wallet_template.lang = '");
      interpolatedStringHandler.AppendFormatted(lang.ToUpper());
      interpolatedStringHandler.AppendLiteral("'\n                LEFT JOIN `admin_user` ON `admin_user`.pk = `member`.admin_user_fk\n                ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear1 = interpolatedStringHandler.ToStringAndClear();
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(913, 4);
      interpolatedStringHandler.AppendLiteral("SELECT wallet_record.pk,  admin_user.account AS admin_account, member.admin_user_fk, member.account, member.nickname, wallet_record.type, \n                wallet_record.affect, wallet_record.create_time, wallet_record.info, `member`.is_test_account, wallet_template.template as template\n                ,wallet_template.name AS template_name, wallet_record.param\n                FROM `wallet_record`\n                INNER JOIN `member` ON wallet_record.member_fk = member.pk \n                INNER JOIN `sys_market` ON wallet_record.currency=sys_market.currency\n                LEFT JOIN `wallet_template` ON wallet_record.templat_id = wallet_template.temp_id AND wallet_template.lang = '");
      interpolatedStringHandler.AppendFormatted(lang.ToUpper());
      interpolatedStringHandler.AppendLiteral("'\n                LEFT JOIN `admin_user` ON `admin_user`.pk = `member`.admin_user_fk\n                ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\n                ORDER BY wallet_record.create_time DESC, member.account ASC\n                LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n                OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear2 = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<StatWalletRecordDetailList>(readConnection.QuerySingle<int>(stringAndClear1), (IEnumerable<StatWalletRecordDetailList>) readConnection.Query<StatWalletRecordDetailList>(stringAndClear2).AsList<StatWalletRecordDetailList>());
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRecordService][FindStatWalletRecordDetailList]" + ex.Message);
        return new DataCountBase<StatWalletRecordDetailList>();
      }
    }

    public static List<WalletRecordList> FindWalletRecordList(
      int id,
      int page,
      int pageSize,
      string lang = "VN")
    {
      string sql = "\nSELECT wallet_record.pk, wallet_record.type, wallet_record.currency, wallet_record.affect, wallet_record.freeze, wallet_record.balance, wallet_record.coupon, wallet_record.info, wallet_record.create_time, wallet_record.create_ip, wallet_record.param, wallet_template.name as type_string, wallet_template.template as template\nFROM `wallet_record`\nLEFT JOIN wallet_template ON wallet_record.templat_id = wallet_template.temp_id AND wallet_template.lang = @lang\nWHERE member_fk = @id\nORDER BY wallet_record.pk DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WalletRecordList>(sql, (object) new
          {
            id = id,
            offset = ((page - 1) * pageSize),
            pageSize = pageSize,
            lang = lang
          }).AsList<WalletRecordList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRecordService][FindWalletRecordList]" + ex.Message);
        return (List<WalletRecordList>) null;
      }
    }

    public static (CountAndTotalAmount, DataCountBase<StatBalanceList>) FindStatBalanceList(
      int page,
      int pageSize,
      string whereSql = "",
      string lang = "VN")
    {
      string str = string.IsNullOrEmpty(whereSql) ? "WHERE wallet_record.type IN(1, 12) AND wallet_template.lang = '" + lang + "' AND `member`.is_test_account = 0 and member.is_del = 0" : whereSql + " AND wallet_record.type IN(1, 12) AND wallet_template.lang = 'CN' AND `member`.is_test_account = 0 and member.is_del = 0";
      string sql = "\n                            SELECT\n                                COUNT(0) as count,\n                                COUNT(CASE WHEN wallet_record.type = 1 THEN 1 END) AS recharge_count,\n                                COUNT(CASE WHEN wallet_record.type = 12 THEN 1 END) AS withdraw_count,\n                                SUM(CASE WHEN wallet_record.type = 1 THEN affect ELSE 0 END) AS total_recharge,\n                                SUM(CASE WHEN wallet_record.type = 12 THEN affect ELSE 0 END) AS total_withdraw\n                            FROM `wallet_record` \n                            LEFT JOIN `member` ON `member`.pk = wallet_record.member_fk\n                            LEFT JOIN `wallet_template` ON wallet_template.temp_id = wallet_record.type \n                            " + str + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(889, 3);
      interpolatedStringHandler.AppendLiteral("SELECT \n                                member.account, \n                                member.nickname, \n                                wallet_record.create_time, \n                                wallet_template.name, \n                                CASE WHEN wallet_record.type = 1 THEN affect ELSE 0 END AS recharge, \n                                CASE WHEN wallet_record.type = 12 THEN affect ELSE 0 END AS withdraw, \n                                wallet_record.type\n                            FROM `wallet_record` \n                            LEFT JOIN `member` ON `member`.pk = wallet_record.member_fk\n                            LEFT JOIN `wallet_template` ON wallet_template.temp_id = wallet_record.type \n                            ");
      interpolatedStringHandler.AppendFormatted(str);
      interpolatedStringHandler.AppendLiteral("\n                            ORDER BY wallet_record.create_time DESC\n                            LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n                            OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          CountAndTotalAmount countAndTotalAmount = readConnection.QuerySingle<CountAndTotalAmount>(sql);
          List<StatBalanceList> data = readConnection.Query<StatBalanceList>(stringAndClear).AsList<StatBalanceList>();
          return (countAndTotalAmount, new DataCountBase<StatBalanceList>(countAndTotalAmount.count, (IEnumerable<StatBalanceList>) data));
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletRecordService][FindStatBalanceList]" + ex.Message);
        return (new CountAndTotalAmount(), new DataCountBase<StatBalanceList>());
      }
    }
  }
}
