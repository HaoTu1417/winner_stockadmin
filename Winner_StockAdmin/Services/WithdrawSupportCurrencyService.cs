// Decompiled with JetBrains decompiler
// Type: DB.Services.WithdrawSupportCurrencyService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.WithdrawCurrency;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class WithdrawSupportCurrencyService
  {
    public static int FindPkAfterInsert(WithdrawSupportCurrencyDto source)
    {
      string sql = "INSERT INTO `withdraw_support_currency` (`code`, `currency`, `type`, `enable`)\n\t\t\t\tVALUES (@code, @currency, @type, @enable);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WithdrawSupportCurrencyService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static WithdrawSupportCurrencyDto Find(int pk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(51, 1);
      interpolatedStringHandler.AppendLiteral("SELECT * From withdraw_support_currency where pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QuerySingleOrDefault<WithdrawSupportCurrencyDto>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WithdrawSupportCurrencyService][Find]" + ex.Message);
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static int UpdateFull(WithdrawSupportCurrencyDto model)
    {
      string sql = "UPDATE `withdraw_support_currency` SET \n\t\t\t\t`code` = @code,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`type` = @type,\n\t\t\t\t`enable` = @enable\n                 where `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WithdrawSupportCurrencyService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<string> FindSupportCurrency(int type)
    {
      string sql = "SELECT code From withdraw_support_currency where enable = 1 and type = @type";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            type = type
          });
          return readConnection.Query<string>(sql, (object) parameters).AsList<string>();
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WithdrawSupportCurrencyService][FindSupportCurrency]" + ex.Message);
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static List<WithdrawCurrencyList> FindWithdrawSupportCurrency(
      string whereSql = "",
      string lang = "VN")
    {
      string sql = "SELECT *, '" + lang + "' as admin_lang From withdraw_support_currency $" + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WithdrawCurrencyList>(sql).AsList<WithdrawCurrencyList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WithdrawSupportCurrencyService][FindWithdrawSupportCurrency]" + ex.Message);
        throw new AppException(1040, "read_db_exception");
      }
    }
  }
}
