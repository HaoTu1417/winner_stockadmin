// Decompiled with JetBrains decompiler
// Type: DB.Services.PacketWechatAreaService
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
  public class PacketWechatAreaService
  {
    public static PacketWechatAreaDto Find(int pk)
    {
      string sql = "SELECT * FROM `packet_wechat_area` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<PacketWechatAreaDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[PacketWechatAreaService][Find]" + ex.Message);
        return (PacketWechatAreaDto) null;
      }
    }

    public static List<PacketWechatAreaDto> FindAll()
    {
      string sql = "SELECT * FROM `packet_wechat_area`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<PacketWechatAreaDto>(sql).AsList<PacketWechatAreaDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[PacketWechatAreaService][FindAll]" + ex.Message);
        return (List<PacketWechatAreaDto>) null;
      }
    }

    public static int FindPkAfterInsert(PacketWechatAreaDto source)
    {
      string sql = "INSERT INTO `packet_wechat_area` (\n\t\t\t\t`country`, `province`, `city`)\n\t\t\t\tVALUES (@country, @province, @city);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[PacketWechatAreaService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(PacketWechatAreaDto model)
    {
      string sql = "UPDATE `packet_wechat_area` SET \n\t\t\t\t`country` = @country,\n\t\t\t\t`province` = @province,\n\t\t\t\t`city` = @city\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[PacketWechatAreaService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `packet_wechat_area` WHERE `pk` = @pk";
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
        LogLib.Log("[PacketWechatAreaService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
