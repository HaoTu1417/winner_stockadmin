// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsAdvertTypeService
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
  public class CmsAdvertTypeService
  {
    public static CmsAdvertTypeDto Find(int pk)
    {
      string sql = "SELECT * FROM `cms_advert_type` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<CmsAdvertTypeDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsAdvertTypeService][Find]" + ex.Message);
        return (CmsAdvertTypeDto) null;
      }
    }

    public static List<CmsAdvertTypeDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_advert_type`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsAdvertTypeDto>(sql).AsList<CmsAdvertTypeDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsAdvertTypeService][FindAll]" + ex.Message);
        return (List<CmsAdvertTypeDto>) null;
      }
    }

    public static int FindPkAfterInsert(CmsAdvertTypeDto source)
    {
      string sql = "INSERT INTO `cms_advert_type` (\n\t\t\t\t`name`, `status`)\n\t\t\t\tVALUES (@name, @status);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsAdvertTypeService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(CmsAdvertTypeDto model)
    {
      string sql = "UPDATE `cms_advert_type` SET \n\t\t\t\t`name` = @name,\n\t\t\t\t`status` = @status\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsAdvertTypeService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `cms_advert_type` WHERE `pk` = @pk";
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
        LogLib.Log("[CmsAdvertTypeService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
