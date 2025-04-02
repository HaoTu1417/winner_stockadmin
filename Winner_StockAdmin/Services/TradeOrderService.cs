// Decompiled with JetBrains decompiler
// Type: DB.Services.TradeOrderService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.TradeAccount;
using stockadmin.ViewModels.UserTradeOrder;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class TradeOrderService
  {
    public static TradeOrderDto Find(int pk)
    {
      string sql = "SELECT * FROM `trade_order` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<TradeOrderDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeOrderService][Find]" + ex.Message);
        return (TradeOrderDto) null;
      }
    }

    public static List<TradeOrderDto> FindAll()
    {
      string sql = "SELECT * FROM `trade_order`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeOrderDto>(sql).AsList<TradeOrderDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeOrderService][FindAll]" + ex.Message);
        return (List<TradeOrderDto>) null;
      }
    }

    public static int FindPkAfterInsert(TradeOrderDto source)
    {
      string sql = "INSERT INTO `trade_order` (\n\t\t\t\t`sub_account`, `sn`, `stock_code`, `stock_name`, `market`, `dir`, `order_type`, `price_type`, `price`, `status`, `volume`, `free_volume`, `succeed_volume`, `cancel_volume`, `order_time`, `order_ip`, `order_client`, `order_source`, `cancel_datetime`, `cancel_type`, `cancel_by`, `live_mode`, `live_ordersn`, `live_request`, `live_succeed`, `live_price`)\n\t\t\t\tVALUES (@sub_account, @sn, @stock_code, @stock_name, @market, @dir, @order_type, @price_type, @price, @status, @volume, @free_volume, @succeed_volume, @cancel_volume, @order_time, @order_ip, @order_client, @order_source, @cancel_datetime, @cancel_type, @cancel_by, @live_mode, @live_ordersn, @live_request, @live_succeed, @live_price);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeOrderService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(TradeOrderDto model)
    {
      string sql = "UPDATE `trade_order` SET \n\t\t\t\t`sub_account` = @sub_account,\n\t\t\t\t`sn` = @sn,\n\t\t\t\t`stock_code` = @stock_code,\n\t\t\t\t`stock_name` = @stock_name,\n\t\t\t\t`market` = @market,\n\t\t\t\t`dir` = @dir,\n\t\t\t\t`order_type` = @order_type,\n\t\t\t\t`price_type` = @price_type,\n\t\t\t\t`price` = @price,\n\t\t\t\t`status` = @status,\n\t\t\t\t`volume` = @volume,\n\t\t\t\t`free_volume` = @free_volume,\n\t\t\t\t`succeed_volume` = @succeed_volume,\n\t\t\t\t`cancel_volume` = @cancel_volume,\n\t\t\t\t`order_time` = @order_time,\n\t\t\t\t`order_ip` = @order_ip,\n\t\t\t\t`order_client` = @order_client,\n\t\t\t\t`order_source` = @order_source,\n\t\t\t\t`cancel_datetime` = @cancel_datetime,\n\t\t\t\t`cancel_type` = @cancel_type,\n\t\t\t\t`cancel_by` = @cancel_by,\n\t\t\t\t`live_mode` = @live_mode,\n\t\t\t\t`live_ordersn` = @live_ordersn,\n\t\t\t\t`live_request` = @live_request,\n\t\t\t\t`live_succeed` = @live_succeed,\n\t\t\t\t`live_price` = @live_price\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeOrderService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `trade_order` WHERE `pk` = @pk";
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
        LogLib.Log("[TradeOrderService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<UserTradeOrderList> FindUserTradeOrderList(string whereSql = "")
    {
      string sql = "SELECT trade_order.pk, trade_order.sub_account, trade_order.order_time, trade_order.sn, trade_order.stock_code, \n                trade_order.stock_name, trade_order.market, trade_order.dir, trade_order.order_type, trade_order.price_type, trade_order.price, \n                trade_order.status, trade_order.volume, trade_order.free_volume, trade_order.succeed_volume, trade_order.cancel_volume \n                FROM `trade_order`" + whereSql + " order by order_time DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<UserTradeOrderList>(sql).AsList<UserTradeOrderList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeOrderService][FindUserTradeOrderList]" + ex.Message);
        return (List<UserTradeOrderList>) null;
      }
    }

    public static List<TradeStopSearchList> FindTradeOrderSearch(string where = "")
    {
      string sql = "SELECT * FROM `trade_order` " + where + " ORDER BY `cancel_datetime` DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeStopSearchList>(sql).AsList<TradeStopSearchList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeOrderService][FindTradeOrderSearch]" + ex.Message);
        return (List<TradeStopSearchList>) null;
      }
    }

    public static List<TradeEntrustedSearchList> FindEntrustedOrderSearch(string where = "")
    {
      string sql = "SELECT * FROM `trade_order` " + where + " ORDER BY `order_time` DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeEntrustedSearchList>(sql).AsList<TradeEntrustedSearchList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeOrderService][TradeEntrustedSearchList]" + ex.Message);
        return (List<TradeEntrustedSearchList>) null;
      }
    }

    public static int UpdateCancelOrderVolume(int pk)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return writeConntion.Execute("UPDATE `trade_order` SET cancel_volume=free_volume, free_volume=0, status = 2  WHERE pk=@pk;", (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeOrderService][UpdateCancelOrderVolume]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
