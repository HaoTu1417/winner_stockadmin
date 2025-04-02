// Decompiled with JetBrains decompiler
// Type: DB.Services.StockOptionPositionService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.StockOptionPosition;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace DB.Services
{
  public class StockOptionPositionService
  {
    public static List<StockOptionPositionList> FindStockOptionPositionList(string whereSql)
    {
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          string sql = "SELECT *, member.account FROM stock_option_position\n                                LEFT JOIN member ON stock_option_position.member_fk = member.pk\n                                " + whereSql;
          return readConnection.Query<StockOptionPositionList>(sql).AsList<StockOptionPositionList>();
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionPositionService][Find]" + ex.Message);
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static StockOptionPositionDto? Find(int member_fk, string code, string market)
    {
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          string sql = "SELECT * FROM stock_option_position WHERE member_fk = @member_fk AND stock_code = @stock_code AND market = @market";
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk,
            stock_code = code,
            market = market
          });
          return readConnection.QuerySingleOrDefault<StockOptionPositionDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionPositionService][Find]" + ex.Message);
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static List<StockOptionPositionDto> FindByMember(int member_fk)
    {
      string sql = "\nSELECT * FROM `stock_option_position` \nWHERE `member_fk` = @member_fk \n;";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return readConnection.Query<StockOptionPositionDto>(sql, (object) parameters).ToList<StockOptionPositionDto>();
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionPositionService][FindByMember]" + ex.Message);
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static void Insert(StockOptionPositionDto model)
    {
      string sql = "\nINSERT INTO `stock_option_position`\n(`member_fk`, `market`, `stock_code`, `stock_name`, `quantity`, `freeze`, `last_price`, `total_cost`\nVALUES\n(@member_fk, @market, @stock_code, @stock_name, @quantity, @last_price, @total_cost\n";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionPositionService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int SellUpdate(StockOptionPositionDto model)
    {
      string sql = "\nUPDATE `stock_option_position`\nSET `quantity` = @quantity ,`freeze` = @freeze \nWHERE `member_fk` = @member_fk AND `stock_code` = @stock_code AND `market` = @market\n;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionPositionService][SellUpdate]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
