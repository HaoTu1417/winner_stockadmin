// Decompiled with JetBrains decompiler
// Type: DB.Services.WalletPaymentService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.WalletPayment;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class WalletPaymentService
  {
    public static WalletPaymentDto Find(int pk)
    {
      string sql = "SELECT * FROM `wallet_payment` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<WalletPaymentDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletPaymentService][Find]" + ex.Message);
        return (WalletPaymentDto) null;
      }
    }

    public static List<WalletPaymentDto> FindAll()
    {
      string sql = "SELECT * FROM `wallet_payment`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WalletPaymentDto>(sql).AsList<WalletPaymentDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletPaymentService][FindAll]" + ex.Message);
        return (List<WalletPaymentDto>) null;
      }
    }

    public static int FindPkAfterInsert(WalletPaymentDto source)
    {
      string sql = "INSERT INTO `wallet_payment` (\n\t\t\t\t`pay_name`, `pay_code`, `pay_type`, `pay_url`, `pay_account`, `min_recharge`, `pay_tokenkey`, `pay_Notice_url`, `pay_Return_url`, `pay_sort`, `status`, `create_time`, `notes`, `fastbtn`, `viplists`, `currency`)\n\t\t\t\tVALUES (@pay_name, @pay_code, @pay_type, @pay_url, @pay_account, @min_recharge, @pay_tokenkey, @pay_Notice_url, @pay_Return_url, @pay_sort, @status, @create_time, @notes, @fastbtn, @viplists, @currency);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletPaymentService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(WalletPaymentDto model)
    {
      string sql = "UPDATE `wallet_payment` SET \n\t\t\t\t`pay_name` = @pay_name,\n\t\t\t\t`pay_code` = @pay_code,\n\t\t\t\t`pay_type` = @pay_type,\n\t\t\t\t`pay_url` = @pay_url,\n\t\t\t\t`pay_account` = @pay_account,\n\t\t\t\t`min_recharge` = @min_recharge,\n\t\t\t\t`pay_tokenkey` = @pay_tokenkey,\n\t\t\t\t`pay_Notice_url` = @pay_Notice_url,\n\t\t\t\t`pay_Return_url` = @pay_Return_url,\n\t\t\t\t`pay_sort` = @pay_sort,\n\t\t\t\t`status` = @status,\n\t\t\t\t`create_time` = @create_time,\n\t\t\t\t`notes` = @notes,\n\t\t\t\t`fastbtn` = @fastbtn,\n\t\t\t\t`viplists` = @viplists\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletPaymentService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `wallet_payment` WHERE `pk` = @pk";
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
        LogLib.Log("[WalletPaymentService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<WalletPaymentList> FindWalletPaymentList(string whereSql = "")
    {
      string sql = "SELECT wallet_payment.pk, wallet_payment.status, wallet_payment.pay_name, wallet_payment.pay_code, wallet_payment.viplists FROM `wallet_payment`" + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WalletPaymentList>(sql).AsList<WalletPaymentList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletPaymentService][FindWalletPaymentList]" + ex.Message);
        return (List<WalletPaymentList>) null;
      }
    }
  }
}
