// Decompiled with JetBrains decompiler
// Type: DB.Services.TradeFrozenService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class TradeFrozenService
  {
    public static TradeFrozenDto Find(int pk)
    {
      string sql = "SELECT * FROM `trade_frozen` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<TradeFrozenDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeFrozenService][Find]" + ex.Message);
        return (TradeFrozenDto) null;
      }
    }

    public static List<TradeFrozenDto> FindAll()
    {
      string sql = "SELECT * FROM `trade_frozen`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeFrozenDto>(sql).AsList<TradeFrozenDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeFrozenService][FindAll]" + ex.Message);
        return (List<TradeFrozenDto>) null;
      }
    }

    public static int FindPkAfterInsert(TradeFrozenDto source)
    {
      string sql = "INSERT INTO `trade_frozen` (\n\t\t\t\t`sub_account`, `trade_order_fk`, `info`, `type`, `frozen_volume`, `frozen_money`, `frozen_datetime`)\n\t\t\t\tVALUES (@sub_account, @trade_order_fk, @info, @type, @frozen_volume, @frozen_money, @frozen_datetime);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeFrozenService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(TradeFrozenDto model)
    {
      string sql = "UPDATE `trade_frozen` SET \n\t\t\t\t`sub_account` = @sub_account,\n\t\t\t\t`trade_order_fk` = @trade_order_fk,\n\t\t\t\t`info` = @info,\n\t\t\t\t`type` = @type,\n\t\t\t\t`frozen_volume` = @frozen_volume,\n\t\t\t\t`frozen_money` = @frozen_money,\n\t\t\t\t`frozen_datetime` = @frozen_datetime\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeFrozenService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `trade_frozen` WHERE `pk` = @pk";
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
        LogLib.Log("[TradeFrozenService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int CancelFrozenMoney(TradeOrderDto order)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            trade_order_fk = order.pk,
            free_volume = order.free_volume,
            price = order.price
          });
          return writeConntion.Execute("UPDATE trade_frozen SET frozen_money = CASE\n    WHEN (frozen_money - @free_volume * @price) <= 0 THEN NULL\n    ELSE frozen_money - @free_volume * @price\nEND\nWHERE trade_order_fk=@trade_order_fk;\n\nDELETE FROM trade_frozen\nWHERE frozen_money IS NULL \nAND  trade_order_fk=@trade_order_fk;", (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeFrozenService][CancelFrozenMoney]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int CancelFrozenVolume(TradeOrderDto order)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            trade_order_fk = order.pk,
            free_volume = order.free_volume
          });
          return writeConntion.Execute("UPDATE trade_frozen\nSET frozen_volume = CASE\n    WHEN (frozen_volume - @free_volume) <= 0 THEN NULL\n    ELSE frozen_volume - @free_volume\nEND\nWHERE trade_order_fk = @trade_order_fk;\n\nDELETE FROM trade_frozen\nWHERE frozen_volume IS NULL \nAND  trade_order_fk = @trade_order_fk;", (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeFrozenService][CancelFrozenVolume]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int DelTradeFrozen(int tradeOrderFk)
    {
      string sql = "DELETE FROM trade_frozen WHERE type = 1 AND trade_order_fk = @tradeOrderFk;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) new
          {
            tradeOrderFk = tradeOrderFk
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeFrozenService][DelTradeFrozen]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
