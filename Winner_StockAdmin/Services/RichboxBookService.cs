// Decompiled with JetBrains decompiler
// Type: DB.Services.RichboxBookService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.RichboxBook;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class RichboxBookService
  {
    public static RichboxBookDto Find(int member_fk)
    {
      string sql = "SELECT * FROM `richbox_book` WHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return readConnection.QueryFirstOrDefault<RichboxBookDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxBookService][Find]" + ex.Message);
        return (RichboxBookDto) null;
      }
    }

    public static List<RichboxBookDto> FindAll()
    {
      string sql = "SELECT * FROM `richbox_book`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RichboxBookDto>(sql).AsList<RichboxBookDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxBookService][FindAll]" + ex.Message);
        return (List<RichboxBookDto>) null;
      }
    }

    public static int Insert(RichboxBookDto model)
    {
      string sql = "INSERT INTO `richbox_book` (\n\t\t\t\t`member_fk`, `total_assets`, `profit`, `day_earning`, `total_earing`, `max_assets`)\n\t\t\t\tVALUES (@member_fk, @total_assets, @profit, @day_earning, @total_earing, @max_assets); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxBookService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(RichboxBookDto model)
    {
      string sql = "UPDATE `richbox_book` SET \n\t\t\t\t`total_assets` = @total_assets,\n\t\t\t\t`profit` = @profit,\n\t\t\t\t`day_earning` = @day_earning,\n\t\t\t\t`total_earing` = @total_earing,\n\t\t\t\t`max_assets` = @max_assets\n\t\t\t\t WHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxBookService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int member_fk)
    {
      string sql = "DELETE FROM `richbox_book` WHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxBookService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<RichboxBookList> FindRichboxBookList(string whereSql = "")
    {
      string sql = "SELECT member.account, member.real_name, richbox_book.total_assets, richbox_book.profit, \n                    richbox_book.total_earing, richbox_book.max_assets \n                    FROM `richbox_book`\n                    INNER JOIN `member` where member.pk = richbox_book.member_fk\n                    " + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RichboxBookList>(sql).AsList<RichboxBookList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxBookService][FindRichboxBookList]" + ex.Message);
        return (List<RichboxBookList>) null;
      }
    }
  }
}
