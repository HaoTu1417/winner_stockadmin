// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsBnrService
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
  public class CmsBnrService
  {
    public static CmsBnrDto Find(int pk)
    {
      string sql = "SELECT * FROM `cms_bnr` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<CmsBnrDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsBnrService][Find]" + ex.Message);
        return (CmsBnrDto) null;
      }
    }

    public static List<CmsBnrDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_bnr`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsBnrDto>(sql).AsList<CmsBnrDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsBnrService][FindAll]" + ex.Message);
        return (List<CmsBnrDto>) null;
      }
    }

    public static int Insert(CmsBnrDto model)
    {
      string sql = "INSERT INTO `cms_bnr` (\n\t\t\t\t`pk`, `bnrid`, `msg`)\n\t\t\t\tVALUES (@pk, @bnrid, @msg); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsBnrService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(CmsBnrDto model)
    {
      string sql = "UPDATE `cms_bnr` SET \n\t\t\t\t`bnrid` = @bnrid,\n\t\t\t\t`msg` = @msg\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsBnrService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `cms_bnr` WHERE `pk` = @pk";
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
        LogLib.Log("[CmsBnrService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
