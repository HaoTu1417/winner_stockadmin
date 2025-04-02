// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsMarqService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.Marquee;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class CmsMarqService
  {
    public static CmsMarqDto Find(int pk)
    {
      string sql = "SELECT * FROM `cms_marq` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<CmsMarqDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsMarqService][Find]" + ex.Message);
        return (CmsMarqDto) null;
      }
    }

    public static List<CmsMarqDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_marq`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsMarqDto>(sql).AsList<CmsMarqDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsMarqService][FindAll]" + ex.Message);
        return (List<CmsMarqDto>) null;
      }
    }

    public static int FindPkAfterInsert(CmsMarqDto source)
    {
      string sql = "INSERT INTO `cms_marq` (\n\t\t\t\t`lang`, `enable`, `msg`)\n\t\t\t\tVALUES (@lang, @enable, @msg);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsMarqService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(CmsMarqDto model)
    {
      string sql = "UPDATE `cms_marq` SET \n\t\t\t\t`lang` = @lang,\n\t\t\t\t`enable` = @enable,\n\t\t\t\t`msg` = @msg\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsMarqService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `cms_marq` WHERE `pk` = @pk";
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
        LogLib.Log("[CmsMarqService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<MarqueeList> FindMarqueeList(string whereSql = "")
    {
      string sql = "SELECT cms_marq.pk, cms_marq.lang, cms_marq.enable, cms_marq.msg FROM `cms_marq`" + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MarqueeList>(sql).AsList<MarqueeList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsMarqService][FindMarqueeList]" + ex.Message);
        return (List<MarqueeList>) null;
      }
    }
  }
}
