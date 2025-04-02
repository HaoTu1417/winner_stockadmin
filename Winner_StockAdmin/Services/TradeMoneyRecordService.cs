// Decompiled with JetBrains decompiler
// Type: DB.Services.TradeMoneyRecordService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.TradeMoneyRecord;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class TradeMoneyRecordService
  {
    public static TradeMoneyRecordDto Find(int pk)
    {
      string sql = "SELECT * FROM `trade_money_record` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<TradeMoneyRecordDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyRecordService][Find]" + ex.Message);
        return (TradeMoneyRecordDto) null;
      }
    }

    public static List<TradeMoneyRecordDto> FindAll()
    {
      string sql = "SELECT * FROM `trade_money_record`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeMoneyRecordDto>(sql).AsList<TradeMoneyRecordDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyRecordService][FindAll]" + ex.Message);
        return (List<TradeMoneyRecordDto>) null;
      }
    }

    public static int FindPkAfterInsert(TradeMoneyRecordDto source)
    {
      string sql = "INSERT INTO `trade_money_record` (\n\t\t\t\t`member_fk`, `sub_account`, `trade_deal_fk`, `sn`, `temp_id`, `op`, `currency`, `balance`, `affect`, `exchange`, `wallet_amount`, `info`, `reviewer`, `create_datetime`, `market`, `order_type`, `stock_code`, `stock_name`)\n\t\t\t\tVALUES (@member_fk, @sub_account, @trade_deal_fk, @sn, @temp_id, @op, @currency, @balance, @affect, @exchange, @wallet_amount, @info, @reviewer, @create_datetime, @market, @order_type, @stock_code, @stock_name);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyRecordService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(TradeMoneyRecordDto model)
    {
      string sql = "UPDATE `trade_money_record` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`sub_account` = @sub_account,\n\t\t\t\t`trade_deal_fk` = @trade_deal_fk,\n\t\t\t\t`sn` = @sn,\n\t\t\t\t`temp_id` = @temp_id,\n\t\t\t\t`op` = @op,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`balance` = @balance,\n\t\t\t\t`affect` = @affect,\n\t\t\t\t`exchange` = @exchange,\n\t\t\t\t`wallet_amount` = @wallet_amount,\n\t\t\t\t`info` = @info,\n\t\t\t\t`reviewer` = @reviewer,\n\t\t\t\t`create_datetime` = @create_datetime,\n\t\t\t\t`market` = @market,\n\t\t\t\t`order_type` = @order_type,\n\t\t\t\t`stock_code` = @stock_code,\n\t\t\t\t`stock_name` = @stock_name\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyRecordService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `trade_money_record` WHERE `pk` = @pk";
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
        LogLib.Log("[TradeMoneyRecordService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Insert(TradeMoneyRecordDto model)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute("INSERT INTO trade_money_record (sub_account, member_fk, trade_deal_fk, sn, temp_id, op,currency, balance, affect, exchange,wallet_amount,info,reviewer,create_datetime,market,stock_code,stock_name) VALUES(@sub_account, @member_fk, @trade_deal_fk, @sn, @temp_id, @op, @currency, @balance, @affect, @exchange, @wallet_amount, @info, @reviewer, @create_datetime, @market, @stock_code, @stock_name);", (object) new
          {
            sub_account = model.sub_account,
            member_fk = model.member_fk,
            trade_deal_fk = model.trade_deal_fk,
            sn = model.sn,
            temp_id = model.temp_id,
            op = model.op,
            currency = model.currency,
            balance = model.balance,
            affect = model.affect,
            exchange = model.exchange,
            wallet_amount = model.wallet_amount,
            info = model.info,
            reviewer = model.reviewer,
            create_datetime = model.create_datetime,
            market = model.market,
            stock_code = model.stock_code,
            stock_name = model.stock_name
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyRecordService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<TradeMoneyRecordList> FindTradeMoneyRecordList(string whereSql = "")
    {
      string sql = "SELECT trade_money_record.pk AS pk, trade_template.name AS temp_name , trade_money_record.create_datetime as create_datetime, trade_money_record.sub_account as sub_account, trade_money_record.sn as sn, trade_money_record.temp_id as temp_id, trade_money_record.info as info, trade_money_record.affect as affect, trade_money_record.exchange as exchange, trade_money_record.wallet_amount as wallet_amount, trade_money_record.balance as balance FROM `trade_money_record`\n                        LEFT JOIN `member` ON trade_money_record.member_fk=member.pk\n                        LEFT JOIN `trade_template` ON trade_template.temp_id=trade_money_record.temp_id AND trade_template.lang=member.lang\n                        " + whereSql + " ORDER BY trade_money_record.create_datetime DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeMoneyRecordList>(sql).AsList<TradeMoneyRecordList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyRecordService][FindTradeMoneyRecordList]" + ex.Message);
        return (List<TradeMoneyRecordList>) null;
      }
    }

    public static List<TradeMoneyRecordList> FindTradeMoneyRecordList(string whereSql = "", string lang = "VN")
    {
      string sql = "SELECT trade_template.template AS template, trade_money_record.param AS param, trade_template.name AS temp_name , trade_money_record.create_datetime as create_datetime, trade_money_record.sub_account as sub_account, trade_money_record.sn as sn, trade_money_record.temp_id as temp_id, trade_money_record.info as info, trade_money_record.affect as affect, trade_money_record.exchange as exchange, trade_money_record.wallet_amount as wallet_amount, trade_money_record.balance as balance, trade_money_record.pk as pk FROM `trade_money_record`\n                        LEFT JOIN `member` ON trade_money_record.member_fk=member.pk\n                        LEFT JOIN `trade_template` ON trade_template.temp_id=trade_money_record.temp_id AND trade_template.lang=@lang\n                        " + whereSql + " ORDER BY trade_money_record.create_datetime DESC";
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@lang", (object) lang);
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeMoneyRecordList>(sql, (object) dynamicParameters).AsList<TradeMoneyRecordList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyRecordService][FindTradeMoneyRecordList]" + ex.Message);
        return (List<TradeMoneyRecordList>) null;
      }
    }

    public static TradeMoneyRecordDto GetByAccount(string sub_account)
    {
      string sql = "SELECT * FROM `trade_money_record` WHERE sub_account = @sub_account ORDER BY create_datetime DESC ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            sub_account = sub_account
          });
          return readConnection.QueryFirstOrDefault<TradeMoneyRecordDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyRecordService][GetByAccount]" + ex.Message);
        return (TradeMoneyRecordDto) null;
      }
    }
  }
}
