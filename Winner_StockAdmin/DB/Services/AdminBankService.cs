// Decompiled with JetBrains decompiler
// Type: DB.Services.AdminBankService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.AdminBank;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class AdminBankService
  {
    public static AdminBankDto Find(int pk)
    {
      string sql = "SELECT * FROM `admin_bank` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<AdminBankDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminBankService][Find]" + ex.Message);
        return (AdminBankDto) null;
      }
    }

    public static List<AdminBankDto> FindAll()
    {
      string sql = "SELECT * FROM `admin_bank`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminBankDto>(sql).AsList<AdminBankDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminBankService][FindAll]" + ex.Message);
        return (List<AdminBankDto>) null;
      }
    }

    public static int FindPkAfterInsert(AdminBankDto source)
    {
      string sql = "INSERT INTO `admin_bank` (\n                `type`, `country`, `currency`, `card`, `SWIFT`, `bank_name`, `open_bank`, `payee`, `notes`, `status`, `image`, `viplists`, `bankimgid`, `min_recharge`, `fastbtn`)\n                VALUES (@type, @country, @currency, @card, @SWIFT, @bank_name, @open_bank, @payee, @notes, @status, @image, @viplists, @bankimgid, @min_recharge, @fastbtn);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminBankService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(AdminBankDto model)
    {
      string sql = "UPDATE `admin_bank` SET \n                `type` = @type,\n                `country` = @country,\n                `currency` = @currency,\n                `card` = @card,\n                `SWIFT` = @SWIFT,\n                `bank_name` = @bank_name,\n                `open_bank` = @open_bank,\n                `payee` = @payee,\n                `notes` = @notes,\n                `status` = @status,\n                `image` = @image,\n                `viplists` = @viplists,\n                `bankimgid` = @bankimgid,\n                `fastbtn` = @fastbtn,\n                `min_recharge` = @min_recharge\n                 WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminBankService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `admin_bank` WHERE `pk` = @pk";
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
        LogLib.Log("[AdminBankService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<AdminBankList> FindAdminBankList(string whereSql = "", string lang = "EN")
    {
      string sql = "SELECT admin_bank.pk, admin_bank.type, admin_bank.currency, admin_bank.card, admin_bank.bank_name, admin_bank.open_bank, admin_bank.payee, admin_bank.notes, admin_bank.status, admin_bank.viplists, if(admin_bank.type = 1, '銀行卡', '虛擬貨幣') as type_string\n                            FROM `admin_bank`\n                            " + whereSql;
      if (lang.ToUpper() == "EN")
        sql = "SELECT admin_bank.pk, admin_bank.type, admin_bank.currency, admin_bank.card, admin_bank.bank_name, admin_bank.open_bank, admin_bank.payee, admin_bank.notes, admin_bank.status, admin_bank.viplists, if(admin_bank.type = 1, 'Bank card', 'Crypto') as type_string\n                         FROM `admin_bank`\n                         " + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminBankList>(sql).AsList<AdminBankList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminBankService][FindAdminBankList]" + ex.Message);
        return (List<AdminBankList>) null;
      }
    }
  }
}
