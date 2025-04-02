// Decompiled with JetBrains decompiler
// Type: DB.Services.WalletCouponRecordService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.WalletCouponRecord;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class WalletCouponRecordService
  {
    public static WalletCouponRecordDto Find(int pk)
    {
      string sql = "SELECT * FROM `wallet_coupon_record` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<WalletCouponRecordDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletCouponRecordService][Find]" + ex.Message);
        return (WalletCouponRecordDto) null;
      }
    }

    public static WalletCouponRecordDto Find(int pk, int member_fk)
    {
      string sql = "SELECT * FROM `wallet_coupon_record` WHERE `pk` = @pk AND `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk,
            member_fk = member_fk
          });
          return readConnection.QueryFirstOrDefault<WalletCouponRecordDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletCouponRecordService][Find]" + ex.Message);
        return (WalletCouponRecordDto) null;
      }
    }

    public static List<WalletCouponRecordDto> FindAll()
    {
      string sql = "SELECT * FROM `wallet_coupon_record`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WalletCouponRecordDto>(sql).AsList<WalletCouponRecordDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletCouponRecordService][FindAll]" + ex.Message);
        return (List<WalletCouponRecordDto>) null;
      }
    }

    public static int FindPkAfterInsert(WalletCouponRecordDto source)
    {
      string sql = "INSERT INTO `wallet_coupon_record` (\n\t\t\t\t`member_fk`, `cms_promotion_fk`, `currency`, `affect`, `exchange`, `wallet_amount`, `coupon_balance`, `money_type`, `type`, `sub_type`, `info`, `create_time`, `create_user`, `sended`, `send_time`, `param`)\n\t\t\t\tVALUES (@member_fk, @cms_promotion_fk, @currency, @affect, @exchange, @wallet_amount, @coupon_balance, @money_type, @type, @sub_type, @info, @create_time, @create_user, @sended, @send_time, @param);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletCouponRecordService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(WalletCouponRecordDto model)
    {
      string sql = "UPDATE `wallet_coupon_record` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`cms_promotion_fk` = @cms_promotion_fk,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`affect` = @affect,\n\t\t\t\t`exchange` = @exchange,\n\t\t\t\t`wallet_amount` = @wallet_amount,\n\t\t\t\t`coupon_balance` = @coupon_balance,\n\t\t\t\t`money_type` = @money_type,\n\t\t\t\t`type` = @type,\n\t\t\t\t`sub_type` = @sub_type,\n\t\t\t\t`info` = @info,\n\t\t\t\t`create_time` = @create_time,\n\t\t\t\t`create_user` = @create_user,\n                `sended` = @sended,\n                `send_time` = @send_time\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletCouponRecordService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateStatusAndSendTimeAndSendUser(
      int cms_promotion_fk,
      DateTime send_time,
      string give_out_user)
    {
      string sql = "UPDATE `wallet_coupon_record` SET \n                `sended` = 1,\n                `send_time` = @send_time,\n                `create_user` = @give_out_user\n\t\t\t\t WHERE `cms_promotion_fk` = @cms_promotion_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            cms_promotion_fk = cms_promotion_fk,
            send_time = send_time,
            give_out_user = give_out_user
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletCouponRecordService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateWalletCoupon(WalletCouponRecordDto model)
    {
      string sql = "UPDATE `wallet_coupon_record` SET \n\t\t\t\t`currency` = @currency,\n\t\t\t\t`affect` = @affect,\n\t\t\t\t`exchange` = @exchange,\n\t\t\t\t`wallet_amount` = @wallet_amount,\n\t\t\t\t`money_type` = @money_type,\n\t\t\t\t`info` = @info\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletCouponRecordService][UpdateWalletCoupon]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `wallet_coupon_record` WHERE `pk` = @pk";
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
        LogLib.Log("[WalletCouponRecordService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static WalletCouponRecordEditVm FindWalletCouponRecordEditVm(int pk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(552, 1);
      interpolatedStringHandler.AppendLiteral("SELECT member.account, member.nickname, wallet_coupon_record.cms_promotion_fk, wallet_coupon_record.money_type, wallet_coupon_record.currency, wallet_coupon_record.affect, wallet_coupon_record.member_fk, wallet_coupon_record.cms_promotion_fk, wallet_coupon_record.pk, wallet_coupon_record.info, \n                wallet_coupon_record.send_time, wallet_coupon_record.create_user \n                FROM `wallet_coupon_record`\n                INNER JOIN `member` on member.pk = wallet_coupon_record.member_fk\n                WHERE wallet_coupon_record.pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<WalletCouponRecordEditVm>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletCouponRecordService][FindWalletCouponRecordEditVm]" + ex.Message);
        return (WalletCouponRecordEditVm) null;
      }
    }

    public static List<WalletCouponRecordDto> FindAll(string whereSql = "")
    {
      string sql = "SELECT * FROM `wallet_coupon_record` " + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WalletCouponRecordDto>(sql).AsList<WalletCouponRecordDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletCouponRecordService][FindWalletCouponRecordList]" + ex.Message);
        return (List<WalletCouponRecordDto>) null;
      }
    }

    public static List<WalletCouponRecordList> FindWalletCouponRecordList(string whereSql = "")
    {
      string sql = "SELECT wallet_coupon_record.pk, member.account, member.nickname, wallet_coupon_record.money_type, \n                wallet_coupon_record.currency, wallet_coupon_record.affect, wallet_coupon_record.info, \n                wallet_coupon_record.create_time AS send_time, wallet_coupon_record.coupon_balance\n                FROM `wallet_coupon_record`\n                INNER JOIN `member` on member.pk = wallet_coupon_record.member_fk\n                " + whereSql + "\n                order by send_time DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WalletCouponRecordList>(sql).AsList<WalletCouponRecordList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletCouponRecordService][FindWalletCouponRecordList]" + ex.Message);
        return (List<WalletCouponRecordList>) null;
      }
    }

    public static List<WalletCouponRecordList> FindWalletCouponRecordList(
      int member_fk,
      string lang = "VN")
    {
      string sql = "SELECT wallet_coupon_record.pk, member.account, member.nickname, wallet_coupon_record.money_type, \n                wallet_coupon_record.type,\n                wallet_coupon_record.currency, wallet_coupon_record.affect, wallet_coupon_record.info, \n                wallet_coupon_record.param,\n                wallet_coupon_record.create_time AS send_time,\n                wallet_template.template, wallet_coupon_record.coupon_balance\n                FROM `wallet_coupon_record`\n                INNER JOIN `member` on member.pk = wallet_coupon_record.member_fk\n                LEFT JOIN wallet_template ON wallet_coupon_record.type = wallet_template.temp_id AND wallet_template.lang = @lang\n                WHERE member_fk = @member_fk\n                order by send_time DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WalletCouponRecordList>(sql, (object) new
          {
            lang = lang,
            member_fk = member_fk
          }).AsList<WalletCouponRecordList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletCouponRecordService][FindWalletCouponRecordList]" + ex.Message);
        return (List<WalletCouponRecordList>) null;
      }
    }

    public static WalletCouponRecordDto FindByMemberFK_Type_SubType(
      int member_fk,
      int type,
      int sub_type)
    {
      string sql = "SELECT * FROM `wallet_coupon_record` \nWHERE `member_fk` = @member_fk AND `type` = @type AND `sub_type` = @sub_type";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<WalletCouponRecordDto>(sql, (object) new
          {
            member_fk = member_fk,
            type = type,
            sub_type = sub_type
          });
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }
  }
}
