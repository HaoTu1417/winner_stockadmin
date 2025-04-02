// Decompiled with JetBrains decompiler
// Type: DB.Services.StockFavoriteService
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
  public class StockFavoriteService
  {
    public static StockFavoriteDto Find(int pk)
    {
      string sql = "SELECT * FROM `stock_favorite` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<StockFavoriteDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockFavoriteService][Find]" + ex.Message);
        return (StockFavoriteDto) null;
      }
    }

    public static List<StockFavoriteDto> FindAll()
    {
      string sql = "SELECT * FROM `stock_favorite`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StockFavoriteDto>(sql).AsList<StockFavoriteDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockFavoriteService][FindAll]" + ex.Message);
        return (List<StockFavoriteDto>) null;
      }
    }

    public static int FindPkAfterInsert(StockFavoriteDto source)
    {
      string sql = "INSERT INTO `stock_favorite` (\n\t\t\t\t`member_fk`, `stock_code`, `market`)\n\t\t\t\tVALUES (@member_fk, @stock_code, @market);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockFavoriteService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(StockFavoriteDto model)
    {
      string sql = "UPDATE `stock_favorite` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`stock_code` = @stock_code,\n\t\t\t\t`market` = @market\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockFavoriteService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `stock_favorite` WHERE `pk` = @pk";
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
        LogLib.Log("[StockFavoriteService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
