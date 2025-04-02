// Decompiled with JetBrains decompiler
// Type: DB.Services.WalletFreezeService
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
  public class WalletFreezeService
  {
    public static WalletFreezeDto Find(int pk)
    {
      string sql = "SELECT * FROM `wallet_freeze` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<WalletFreezeDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletFreezeService][Find]" + ex.Message);
        return (WalletFreezeDto) null;
      }
    }

    public static List<WalletFreezeDto> FindAll()
    {
      string sql = "SELECT * FROM `wallet_freeze`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WalletFreezeDto>(sql).AsList<WalletFreezeDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletFreezeService][FindAll]" + ex.Message);
        return (List<WalletFreezeDto>) null;
      }
    }

    public static int FindPkAfterInsert(WalletFreezeDto source)
    {
      string sql = "INSERT INTO `wallet_freeze` (\n\t\t\t\t`member_fk`, `sn`, `freeze`, `subtype`, `create_time`)\n\t\t\t\tVALUES (@member_fk, @sn, @freeze, @subtype, @create_time);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletFreezeService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(WalletFreezeDto model)
    {
      string sql = "UPDATE `wallet_freeze` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`sn` = @sn,\n\t\t\t\t`freeze` = @freeze,\n\t\t\t\t`subtype` = @subtype,\n\t\t\t\t`create_time` = @create_time\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletFreezeService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `wallet_freeze` WHERE `pk` = @pk";
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
        LogLib.Log("[WalletFreezeService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static void Insert(WalletFreezeDto walletfreezeDto)
    {
      string sql = "INSERT INTO `wallet_freeze`  (`member_fk`, `sn`, `freeze`, `subtype`, `create_time`) \n                           VALUES (@member_fk, @sn, @freeze, @subtype, @create_time)";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          writeConntion.Execute(sql, (object) walletfreezeDto);
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "write_db_exception");
      }
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM wallet_freeze WHERE pk = @id";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            id = id
          });
          writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletFreezeService][Delete]" + ex.Message);
        throw new AppException(1030, "[1030] M线路忙碌,稍後再试");
      }
    }

    public static WalletFreezeDto FindWalletFreezeBySn(string sn)
    {
      string sql = "SELECT * FROM wallet_freeze WHERE sn = @sn ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            sn = sn
          });
          return readConnection.QuerySingleOrDefault<WalletFreezeDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletFreezeService][FindWalletFreezeBySn]" + ex.Message);
        throw new AppException(1040, "[1040] S线路忙碌,稍後再试");
      }
    }

    public static void DeleteBySN(int member_fk, string sn)
    {
      string sql = "DELETE FROM wallet_freeze WHERE member_fk = @member_fk and sn= @sn";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk,
            sn = sn
          });
          writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletFreezeService][Delete]" + ex.Message);
        throw new AppException(1030, "[1030] M线路忙碌,稍後再试");
      }
    }
  }
}
