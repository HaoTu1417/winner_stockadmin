// Decompiled with JetBrains decompiler
// Type: DB.Services.BorrowDetailService
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
  public class BorrowDetailService
  {
    public static BorrowDetailDto Find(int pk)
    {
      string sql = "SELECT * FROM `borrow_detail` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<BorrowDetailDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowDetailService][Find]" + ex.Message);
        return (BorrowDetailDto) null;
      }
    }

    public static List<BorrowDetailDto> FindAll()
    {
      string sql = "SELECT * FROM `borrow_detail`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<BorrowDetailDto>(sql).AsList<BorrowDetailDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowDetailService][FindAll]" + ex.Message);
        return (List<BorrowDetailDto>) null;
      }
    }

    public static int FindPkAfterInsert(BorrowDetailDto source)
    {
      string sql = "INSERT INTO `borrow_detail` (\n\t\t\t\t`borrow_fk`, `member_fk`, `status`, `interest`, `receive_interest`, `sort_order`, `total`, `deadline`, `repayment_time`)\n\t\t\t\tVALUES (@borrow_fk, @member_fk, @status, @interest, @receive_interest, @sort_order, @total, @deadline, @repayment_time);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowDetailService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(BorrowDetailDto model)
    {
      string sql = "UPDATE `borrow_detail` SET \n\t\t\t\t`borrow_fk` = @borrow_fk,\n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`status` = @status,\n\t\t\t\t`interest` = @interest,\n\t\t\t\t`receive_interest` = @receive_interest,\n\t\t\t\t`sort_order` = @sort_order,\n\t\t\t\t`total` = @total,\n\t\t\t\t`deadline` = @deadline,\n\t\t\t\t`repayment_time` = @repayment_time\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowDetailService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `borrow_detail` WHERE `pk` = @pk";
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
        LogLib.Log("[BorrowDetailService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
