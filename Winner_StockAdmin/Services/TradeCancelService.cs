// Decompiled with JetBrains decompiler
// Type: DB.Services.TradeCancelService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.TradeCancel;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class TradeCancelService
  {
    public static TradeCancelDto Find(int pk)
    {
      string sql = "SELECT * FROM `trade_cancel` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<TradeCancelDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeCancelService][Find]" + ex.Message);
        return (TradeCancelDto) null;
      }
    }

    public static List<TradeCancelDto> FindAll()
    {
      string sql = "SELECT * FROM `trade_cancel`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeCancelDto>(sql).AsList<TradeCancelDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeCancelService][FindAll]" + ex.Message);
        return (List<TradeCancelDto>) null;
      }
    }

    public static int FindPkAfterInsert(TradeCancelDto source)
    {
      string sql = "INSERT INTO `trade_cancel` (\n\t\t\t\t`trade_order_sn`, `sub_account`, `sn`, `market`, `stock_code`, `stock_name`, `request_volume`, `cancel_volume`, `order_ip`, `order_client`, `cancel_type`, `cancel_datetime`, `cancel_by`)\n\t\t\t\tVALUES (@trade_order_sn, @sub_account, @sn, @market, @stock_code, @stock_name, @request_volume, @cancel_volume, @order_ip, @order_client, @cancel_type, @cancel_datetime, @cancel_by);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeCancelService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(TradeCancelDto model)
    {
      string sql = "UPDATE `trade_cancel` SET \n\t\t\t\t`trade_order_sn` = @trade_order_sn,\n\t\t\t\t`sub_account` = @sub_account,\n\t\t\t\t`sn` = @sn,\n\t\t\t\t`market` = @market,\n\t\t\t\t`stock_code` = @stock_code,\n\t\t\t\t`stock_name` = @stock_name,\n\t\t\t\t`request_volume` = @request_volume,\n\t\t\t\t`cancel_volume` = @cancel_volume,\n\t\t\t\t`order_ip` = @order_ip,\n\t\t\t\t`order_client` = @order_client,\n\t\t\t\t`cancel_type` = @cancel_type,\n\t\t\t\t`cancel_datetime` = @cancel_datetime,\n\t\t\t\t`cancel_by` = @cancel_by\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeCancelService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `trade_cancel` WHERE `pk` = @pk";
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
        LogLib.Log("[TradeCancelService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<TradeCancelList> FindTradeCancelList(string whereSql = "")
    {
      string sql = "SELECT trade_cancel.cancel_datetime, trade_cancel.sub_account, trade_cancel.sn, trade_cancel.trade_order_sn, trade_cancel.stock_code, trade_cancel.stock_name, trade_cancel.cancel_volume, trade_cancel.cancel_type FROM `trade_cancel`" + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeCancelList>(sql).AsList<TradeCancelList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeCancelService][FindTradeCancelList]" + ex.Message);
        return (List<TradeCancelList>) null;
      }
    }

    public static int AddCancelOrderRecord(TradeOrderDto order, string adminIp, string adminName)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            sn = order.sn,
            sub_account = order.sub_account,
            market = order.market,
            stock_code = order.stock_code,
            stock_name = order.stock_name,
            request_volume = order.free_volume,
            cancel_volume = order.free_volume,
            order_ip = adminIp,
            cancel_type = 3,
            cancel_datetime = DateTime.Now,
            cancel_by = adminName
          });
          return writeConntion.Execute("INSERT INTO\n    `usstock`.`trade_cancel` (\n        `trade_order_sn`,\n        `sub_account`,\n        `market`,\n        `stock_code`,\n        `stock_name`,\n        `request_volume`,\n        `cancel_volume`,\n        `order_ip`,\n        `cancel_type`,\n        `cancel_datetime`,\n        `cancel_by`\n    )\nVALUES (\n        @sn,\n        @sub_account,\n        @market,\n        @stock_code,\n        @stock_name,\n        @request_volume,\n        @cancel_volume,\n        @order_ip,\n        @cancel_type,\n        @cancel_datetime,\n        @cancel_by\n    );\nUPDATE trade_cancel SET sn =  CONCAT('C',DATE_FORMAT(NOW(), '%y'), LPAD(LAST_INSERT_ID(), 8, '0')) WHERE pk =LAST_INSERT_ID();\n", (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeCancelService][AddCancelOrderRecord]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
