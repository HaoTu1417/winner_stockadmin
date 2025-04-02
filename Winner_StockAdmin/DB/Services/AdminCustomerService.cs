// Decompiled with JetBrains decompiler
// Type: DB.Services.AdminCustomerService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

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
  public class AdminCustomerService
  {
    public static AdminCustomerDto Find(int pk)
    {
      string sql = "SELECT * FROM `admin_customer` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<AdminCustomerDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminCustomerService][Find]" + ex.Message);
        return (AdminCustomerDto) null;
      }
    }

    public static List<AdminCustomerDto> FindAll()
    {
      string sql = "SELECT * FROM `admin_customer`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminCustomerDto>(sql).AsList<AdminCustomerDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminCustomerService][FindAll]" + ex.Message);
        return (List<AdminCustomerDto>) null;
      }
    }

    public static int FindPkAfterInsert(AdminCustomerDto source)
    {
      string sql = "INSERT INTO `admin_customer` (\n\t\t\t\t`customer_name`, `enable`, `appkey`, `business_code`, `lang`, `app_url`, `contract_start_time`, `contract_end_time`, `exange`)\n\t\t\t\tVALUES (@customer_name, @enable, @appkey, @business_code, @lang, @app_url, @contract_start_time, @contract_end_time, @exange);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminCustomerService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(AdminCustomerDto model)
    {
      string sql = "UPDATE `admin_customer` SET \n\t\t\t\t`customer_name` = @customer_name,\n\t\t\t\t`enable` = @enable,\n\t\t\t\t`appkey` = @appkey,\n\t\t\t\t`business_code` = @business_code,\n\t\t\t\t`lang` = @lang,\n\t\t\t\t`app_url` = @app_url,\n\t\t\t\t`contract_start_time` = @contract_start_time,\n\t\t\t\t`contract_end_time` = @contract_end_time,\n\t\t\t\t`exange` = @exange\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminCustomerService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `admin_customer` WHERE `pk` = @pk";
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
        LogLib.Log("[AdminCustomerService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
