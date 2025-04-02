// Decompiled with JetBrains decompiler
// Type: DB.Services.MemberNotifyService
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
  public class MemberNotifyService
  {
    public static MemberNotifyDto Find(int member_fk)
    {
      string sql = "SELECT * FROM `member_notify` WHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return readConnection.QueryFirstOrDefault<MemberNotifyDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberNotifyService][Find]" + ex.Message);
        return (MemberNotifyDto) null;
      }
    }

    public static List<MemberNotifyDto> FindAll()
    {
      string sql = "SELECT * FROM `member_notify`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MemberNotifyDto>(sql).AsList<MemberNotifyDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberNotifyService][FindAll]" + ex.Message);
        return (List<MemberNotifyDto>) null;
      }
    }

    public static int Insert(MemberNotifyDto model)
    {
      string sql = "INSERT INTO `member_notify` (\n\t\t\t\t`member_fk`, `EmailNotify`, `SiteMessageNotify`, `AccountAlertNotify`, `AccountMarginCallNotify`, `StockTransactionNotify`, `AccountExpiryNotify`, `PromotionsNotify`, `DepositApprovedNotify`, `WithdrawalApprovedNotify`, `TradingAccountApprovedNotify`)\n\t\t\t\tVALUES (@member_fk, @EmailNotify, @SiteMessageNotify, @AccountAlertNotify, @AccountMarginCallNotify, @StockTransactionNotify, @AccountExpiryNotify, @PromotionsNotify, @DepositApprovedNotify, @WithdrawalApprovedNotify, @TradingAccountApprovedNotify); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberNotifyService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(MemberNotifyDto model)
    {
      string sql = "UPDATE `member_notify` SET \n\t\t\t\t`EmailNotify` = @EmailNotify,\n\t\t\t\t`SiteMessageNotify` = @SiteMessageNotify,\n\t\t\t\t`AccountAlertNotify` = @AccountAlertNotify,\n\t\t\t\t`AccountMarginCallNotify` = @AccountMarginCallNotify,\n\t\t\t\t`StockTransactionNotify` = @StockTransactionNotify,\n\t\t\t\t`AccountExpiryNotify` = @AccountExpiryNotify,\n\t\t\t\t`PromotionsNotify` = @PromotionsNotify,\n\t\t\t\t`DepositApprovedNotify` = @DepositApprovedNotify,\n\t\t\t\t`WithdrawalApprovedNotify` = @WithdrawalApprovedNotify,\n\t\t\t\t`TradingAccountApprovedNotify` = @TradingAccountApprovedNotify\n\t\t\t\t WHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberNotifyService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int member_fk)
    {
      string sql = "DELETE FROM `member_notify` WHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberNotifyService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
