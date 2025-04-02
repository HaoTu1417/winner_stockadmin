// Decompiled with JetBrains decompiler
// Type: DB.Services.WalletTransferService
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
  public class WalletTransferService
  {
    public static WalletTransferDto Find(int pk)
    {
      string sql = "SELECT * FROM `wallet_transfer` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<WalletTransferDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletTransferService][Find]" + ex.Message);
        return (WalletTransferDto) null;
      }
    }

    public static List<WalletTransferDto> FindAll()
    {
      string sql = "SELECT * FROM `wallet_transfer`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WalletTransferDto>(sql).AsList<WalletTransferDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletTransferService][FindAll]" + ex.Message);
        return (List<WalletTransferDto>) null;
      }
    }

    public static int FindPkAfterInsert(WalletTransferDto source)
    {
      string sql = "INSERT INTO `wallet_transfer` (\n\t\t\t\t`admin_user_fk`, `member_fk`, `order_no`, `money`, `create_time`, `create_ip`, `info`, `currency`)\n\t\t\t\tVALUES (@admin_user_fk, @member_fk, @order_no, @money, @create_time, @create_ip, @info, @currency);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletTransferService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(WalletTransferDto model)
    {
      string sql = "UPDATE `wallet_transfer` SET \n\t\t\t\t`admin_user_fk` = @admin_user_fk,\n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`order_no` = @order_no,\n\t\t\t\t`money` = @money,\n\t\t\t\t`create_time` = @create_time,\n\t\t\t\t`create_ip` = @create_ip,\n\t\t\t\t`info` = @info,\n\t\t\t\t`currency` = @currency\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletTransferService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `wallet_transfer` WHERE `pk` = @pk";
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
        LogLib.Log("[WalletTransferService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
