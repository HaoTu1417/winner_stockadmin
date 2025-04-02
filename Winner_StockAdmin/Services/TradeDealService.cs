// Decompiled with JetBrains decompiler
// Type: DB.Services.TradeDealService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.TradeAccount;
using stockadmin.ViewModels.UserTradeDeal;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class TradeDealService
  {
    public static TradeDealDto Find(int pk)
    {
      string sql = "SELECT * FROM `trade_deal` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<TradeDealDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeDealService][Find]" + ex.Message);
        return (TradeDealDto) null;
      }
    }

    public static List<TradeDealDto> FindAll()
    {
      string sql = "SELECT * FROM `trade_deal`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeDealDto>(sql).AsList<TradeDealDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeDealService][FindAll]" + ex.Message);
        return (List<TradeDealDto>) null;
      }
    }

    public static int FindPkAfterInsert(TradeDealDto source)
    {
      string sql = "INSERT INTO `trade_deal` (\n\t\t\t\t`deal_id`, `sub_account`, `trade_order_sn`, `stock_code`, `stock_name`, `order_type`, `market`, `dir`, `final_price`, `final_volume`, `create_datetime`, `currency`, `total_pay`, `total_amount`, `total_cost`, `handling_fee`, `transfer_fee`, `stamp_fee`, `other_fee`)\n\t\t\t\tVALUES (@deal_id, @sub_account, @trade_order_sn, @stock_code, @stock_name, @order_type, @market, @dir, @final_price, @final_volume, @create_datetime, @currency, @total_pay, @total_amount, @total_cost, @handling_fee, @transfer_fee, @stamp_fee, @other_fee);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeDealService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(TradeDealDto model)
    {
      string sql = "UPDATE `trade_deal` SET \n\t\t\t\t`deal_id` = @deal_id,\n\t\t\t\t`sub_account` = @sub_account,\n\t\t\t\t`trade_order_sn` = @trade_order_sn,\n\t\t\t\t`stock_code` = @stock_code,\n\t\t\t\t`stock_name` = @stock_name,\n\t\t\t\t`order_type` = @order_type,\n\t\t\t\t`market` = @market,\n\t\t\t\t`dir` = @dir,\n\t\t\t\t`final_price` = @final_price,\n\t\t\t\t`final_volume` = @final_volume,\n\t\t\t\t`create_datetime` = @create_datetime,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`total_pay` = @total_pay,\n\t\t\t\t`total_amount` = @total_amount,\n\t\t\t\t`total_cost` = @total_cost,\n\t\t\t\t`handling_fee` = @handling_fee,\n\t\t\t\t`transfer_fee` = @transfer_fee,\n\t\t\t\t`stamp_fee` = @stamp_fee,\n\t\t\t\t`other_fee` = @other_fee\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeDealService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `trade_deal` WHERE `pk` = @pk";
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
        LogLib.Log("[TradeDealService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<UserTradeDealList> FindUserTradeDealList(string whereSql = "")
    {
      string sql = "SELECT trade_deal.pk, trade_deal.sub_account, trade_deal.deal_id, trade_deal.trade_order_sn, trade_deal.stock_code, \n                trade_deal.stock_name, trade_deal.profit, trade_deal.order_type, trade_deal.dir, trade_deal.final_price, trade_deal.final_volume, \n                trade_deal.create_datetime, trade_deal.total_pay, trade_deal.total_cost, trade_deal.coupon\n                FROM `trade_deal` " + whereSql + " order by create_datetime DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<UserTradeDealList>(sql).AsList<UserTradeDealList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeDealService][FindUserTradeDealList]" + ex.Message);
        return (List<UserTradeDealList>) null;
      }
    }

    public static List<DealSearchList> FindTradeDealSearch(string where = "")
    {
      string sql = "SELECT * FROM `trade_deal` " + where;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<DealSearchList>(sql).AsList<DealSearchList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeDealService][FindTradeDealSearch]" + ex.Message);
        return (List<DealSearchList>) null;
      }
    }
  }
}
