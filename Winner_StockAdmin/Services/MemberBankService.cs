// Decompiled with JetBrains decompiler
// Type: DB.Services.MemberBankService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.MemberBank;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class MemberBankService
  {
    public static MemberBankDto Find(string card_pk)
    {
      string sql = "SELECT * FROM `member_bank` WHERE `card_pk` = @card_pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            card_pk = card_pk
          });
          return readConnection.QueryFirstOrDefault<MemberBankDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberBankService][Find]" + ex.Message);
        return (MemberBankDto) null;
      }
    }

    public static List<MemberBankDto> FindAll()
    {
      string sql = "SELECT * FROM `member_bank`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MemberBankDto>(sql).AsList<MemberBankDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberBankService][FindAll]" + ex.Message);
        return (List<MemberBankDto>) null;
      }
    }

    public static int Insert(MemberBankDto model)
    {
      string sql = "INSERT INTO `member_bank` (\n\t\t\t\t`member_fk`, `card_pk`, `card_type`, `currency`, `country`, `bank`, `branch`, `card`, `account`, `cms_files_fk`, `is_confirm`, `is_delete`, `create_ip`, `create_time`)\n\t\t\t\tVALUES (@member_fk, @card_pk, @card_type, @currency, @country, @bank, @branch, @card, @account, @cms_files_fk, @is_confirm, @is_delete, @create_ip, @create_time); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberBankService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(MemberBankDto model)
    {
      string sql = "UPDATE `member_bank` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`card_type` = @card_type,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`country` = @country,\n\t\t\t\t`bank` = @bank,\n\t\t\t\t`branch` = @branch,\n\t\t\t\t`card` = @card,\n\t\t\t\t`account` = @account,\n\t\t\t\t`cms_files_fk` = @cms_files_fk,\n\t\t\t\t`is_confirm` = @is_confirm,\n\t\t\t\t`is_delete` = @is_delete,\n\t\t\t\t`create_ip` = @create_ip,\n\t\t\t\t`create_time` = @create_time\n\t\t\t\t WHERE `card_pk` = @card_pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberBankService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateStatus(string card_pk, bool is_confirm)
    {
      string sql = "UPDATE `member_bank` SET \n\t\t\t\t`is_confirm` = @is_confirm\n\t\t\t\t WHERE `card_pk` = @card_pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            card_pk = card_pk,
            is_confirm = is_confirm
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberBankService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(string card_pk)
    {
      string sql = "DELETE FROM `member_bank` WHERE `card_pk` = @card_pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            card_pk = card_pk
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberBankService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<MemberBankList> FindMemberBankList(string whereSql)
    {
      string sql = "SELECT member_bank.card_pk, member_bank.card_type, member_bank.currency, member_bank.bank, member_bank.branch, \n                member_bank.card, member_bank.account as bank_account, member_bank.is_confirm, member.account, member.nickname, member.real_name\n                FROM `member_bank`\n                INNER JOIN member on member.pk = member_bank.member_fk \n                " + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MemberBankList>(sql).AsList<MemberBankList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberBankService][FindMemberBankList]" + ex.Message);
        return (List<MemberBankList>) null;
      }
    }

    public static MemberBankReview FindMemberBankReview(string card_pk)
    {
      string sql = "SELECT member_bank.member_fk, member_bank.card_pk, member_bank.card_type, member_bank.currency, member_bank.bank, \n                member_bank.branch, member_bank.card, member_bank.account as bank_account, member_bank.is_confirm, member_bank.create_ip, \n                member_bank.create_time, member.account, member.nickname, member.real_name, member.id_auth\n                FROM `member_bank`\n                LEFT JOIN member on member.pk = member_bank.member_fk \n                WHERE member_bank.card_pk = '" + card_pk + "'";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<MemberBankReview>(sql);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberBankService][FindMemberBankReview]" + ex.Message);
        return (MemberBankReview) null;
      }
    }

    public static int UpdateIsConfirm(string card_pk, bool is_confirm)
    {
      string sql = "UPDATE `member_bank` SET \n        `is_confirm` = @is_confirm\n        WHERE `card_pk` = @card_pk";
      var data = new
      {
        is_confirm = is_confirm,
        card_pk = card_pk
      };
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) data);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberBankService][UpdateIsConfirm]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateIsDelete(string card_pk, bool is_delete)
    {
      string sql = "UPDATE `member_bank` SET \n        `is_delete` = @is_delete\n        WHERE `card_pk` = @card_pk";
      var data = new
      {
        is_delete = is_delete,
        card_pk = card_pk
      };
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) data);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberBankService][UpdateIsDelete]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
