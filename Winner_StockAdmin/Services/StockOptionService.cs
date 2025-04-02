// Decompiled with JetBrains decompiler
// Type: DB.Services.StockOptionService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.StockOption;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class StockOptionService
  {
    public static List<StockOptionList> FindStockOptionList(string whereSql = "")
    {
      string sql = "SELECT *\n                FROM `stock_option`" + whereSql + "\n                order by create_time desc";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StockOptionList>(sql).AsList<StockOptionList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionRecordService][FindStockOptionList]" + ex.Message);
        return (List<StockOptionList>) null;
      }
    }

    public static StockOptionDto Find(int pk)
    {
      string sql = "SELECT * FROM `stock_option` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<StockOptionDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionService][Find]" + ex.Message);
        return (StockOptionDto) null;
      }
    }

    public static List<StockOptionDto> FindAll()
    {
      string sql = "SELECT * FROM `stock_option`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StockOptionDto>(sql).AsList<StockOptionDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionService][FindAll]" + ex.Message);
        return (List<StockOptionDto>) null;
      }
    }

    public static int FindPkAfterInsert(StockOptionDto source)
    {
      string sql = "INSERT INTO `stock_option` (\n\t\t\t\t`stock_name`, `stock_code`, `currency`, `market`, `spot`, `remain_spot`, `price`, `quantity`, `enable`, `create_time`)\n\t\t\t\tVALUES (@stock_name, @stock_code, @currency, @market, @spot, @spot, @price, @quantity, @enable, UTC_TIMESTAMP);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        LogLib.Log("[StockOptionService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static string FindStockName(string market, string stock_code)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(79, 2);
      interpolatedStringHandler.AppendLiteral("SELECT stock_name FROM stock_");
      interpolatedStringHandler.AppendFormatted(market.ToLower());
      interpolatedStringHandler.AppendLiteral("\n                            WHERE stock_code = '");
      interpolatedStringHandler.AppendFormatted(stock_code);
      interpolatedStringHandler.AppendLiteral("'");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      Console.WriteLine(stringAndClear);
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<string>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionService][FindStockName]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(StockOptionDto model)
    {
      string sql = "UPDATE `stock_option` SET \n\t\t\t\t`spot` = @spot,\n\t\t\t\t`price` = @price,\n\t\t\t\t`quantity` = @quantity,\n\t\t\t\t`enable` = @enable\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateRemainSpot(int pk, int diff)
    {
      string sql = "UPDATE `stock_option` SET \n\t\t\t\t`remain_spot` = remain_spot + @diff\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        DynamicParameters parameters = DapperMysql.GetParameters((object) new
        {
          pk = pk,
          diff = diff
        });
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) parameters);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionService][UpdateStatus]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `stock_option` WHERE `pk` = @pk";
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
        LogLib.Log("[StockOptionService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
