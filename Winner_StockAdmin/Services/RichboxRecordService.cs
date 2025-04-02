// Decompiled with JetBrains decompiler
// Type: DB.Services.RichboxRecordService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Microsoft.CSharp.RuntimeBinder;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class RichboxRecordService
  {
    public static List<RichboxRecordDto> FindAllByMember(int member_fk)
    {
      string sql = "SELECT * FROM `richbox_record` WHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return readConnection.Query<RichboxRecordDto>(sql, (object) parameters).AsList<RichboxRecordDto>();
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxRecordService][FindByMember]" + ex.Message);
        return (List<RichboxRecordDto>) null;
      }
    }

    public static RichboxRecordDto Find(int pk)
    {
      string sql = "SELECT * FROM `richbox_record` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<RichboxRecordDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxRecordService][Find]" + ex.Message);
        return (RichboxRecordDto) null;
      }
    }

    public static List<RichboxRecordDto> FindAll()
    {
      string sql = "SELECT * FROM `richbox_record`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RichboxRecordDto>(sql).AsList<RichboxRecordDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxRecordService][FindAll]" + ex.Message);
        return (List<RichboxRecordDto>) null;
      }
    }

    public static int FindPkAfterInsert(RichboxRecordDto source)
    {
      string sql = "INSERT INTO `richbox_record` (\n\t\t\t\t`member_fk`, `affect`, `account`, `type`, `info`, `create_time`)\n\t\t\t\tVALUES (@member_fk, @affect, @account, @type, @info, @create_time);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxRecordService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(RichboxRecordDto model)
    {
      string sql = "UPDATE `richbox_record` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`affect` = @affect,\n\t\t\t\t`account` = @account,\n\t\t\t\t`type` = @type,\n\t\t\t\t`info` = @info,\n\t\t\t\t`create_time` = @create_time\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxRecordService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `richbox_record` WHERE `pk` = @pk";
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
        LogLib.Log("[RichboxRecordService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static DateTime MinDate()
    {
      string sql = " SELECT MIN(create_time) FROM `richbox_record` ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.ExecuteScalar<DateTime>(sql);
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static List<(DateTime? datetime, Decimal amount)> GetDepositAmount(
      DateTime begin_report_date,
      DateTime end_report_date)
    {
      string sql = "\n                        SELECT richbox_record.create_time, IFNULL(`affect`,0) as amount\n                        FROM `richbox_record`\n                        INNER JOIN member ON member.pk = richbox_record.member_fk\n                        WHERE `affect` > 0 AND richbox_record.src = 1 AND member.is_del = 0 AND member.is_test_account = 0\n                        AND richbox_record.create_time >= @begin_report_date AND richbox_record.create_time < @end_report_date\n                    ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            begin_report_date = begin_report_date,
            end_report_date = end_report_date
          });
          return readConnection.Query<object>(sql, (object) parameters).Select<object, (DateTime?, Decimal)>((Func<object, (DateTime?, Decimal)>) (item =>
          {
            // ISSUE: reference to a compiler-generated field
            if (RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__1 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, DateTime?>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (DateTime?), typeof (RichboxRecordService)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, DateTime?> target1 = RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__1.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, DateTime?>> p1 = RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__1;
            // ISSUE: reference to a compiler-generated field
            if (RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__0 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "create_time", typeof (RichboxRecordService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj1 = RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__0.Target((CallSite) RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__0, item);
            DateTime? nullable = target1((CallSite) p1, obj1);
            // ISSUE: reference to a compiler-generated field
            if (RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__3 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, Decimal>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (Decimal), typeof (RichboxRecordService)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, Decimal> target2 = RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__3.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, Decimal>> p3 = RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__3;
            // ISSUE: reference to a compiler-generated field
            if (RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "amount", typeof (RichboxRecordService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj2 = RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__2.Target((CallSite) RichboxRecordService.\u003C\u003Eo__7.\u003C\u003Ep__2, item);
            Decimal num = target2((CallSite) p3, obj2);
            return (nullable, num);
          })).ToList<(DateTime?, Decimal)>();
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static Decimal GetDepositAmount()
    {
      string sql = "\n                        SELECT SUM(`affect`) as amount\n                        FROM `richbox_record`\n                        INNER JOIN member ON member.pk = richbox_record.member_fk\n                        WHERE richbox_record.src = 1 AND member.is_del = 0 AND member.is_test_account = 0\n                    ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.ExecuteScalar<Decimal>(sql);
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static List<(DateTime? datetime, Decimal amount)> GetInterest(
      DateTime begin_report_date,
      DateTime end_report_date)
    {
      string sql = "\n                        SELECT richbox_record.create_time, IFNULL(`affect`,0) as amount\n                        FROM `richbox_record`\n                        INNER JOIN member ON member.pk = richbox_record.member_fk\n                        WHERE `affect` > 0 AND richbox_record.src = 2 AND member.is_del = 0 AND member.is_test_account = 0\n                        AND richbox_record.create_time >= @begin_report_date AND richbox_record.create_time < @end_report_date\n                        ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            begin_report_date = begin_report_date,
            end_report_date = end_report_date
          });
          return readConnection.Query<object>(sql, (object) parameters).Select<object, (DateTime?, Decimal)>((Func<object, (DateTime?, Decimal)>) (item =>
          {
            // ISSUE: reference to a compiler-generated field
            if (RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__1 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, DateTime?>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (DateTime?), typeof (RichboxRecordService)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, DateTime?> target1 = RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__1.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, DateTime?>> p1 = RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__1;
            // ISSUE: reference to a compiler-generated field
            if (RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__0 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "create_time", typeof (RichboxRecordService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj1 = RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__0.Target((CallSite) RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__0, item);
            DateTime? nullable = target1((CallSite) p1, obj1);
            // ISSUE: reference to a compiler-generated field
            if (RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__3 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, Decimal>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (Decimal), typeof (RichboxRecordService)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, Decimal> target2 = RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__3.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, Decimal>> p3 = RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__3;
            // ISSUE: reference to a compiler-generated field
            if (RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "amount", typeof (RichboxRecordService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj2 = RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__2.Target((CallSite) RichboxRecordService.\u003C\u003Eo__9.\u003C\u003Ep__2, item);
            Decimal num = target2((CallSite) p3, obj2);
            return (nullable, num);
          })).ToList<(DateTime?, Decimal)>();
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static List<(DateTime? datetime, Decimal amount)> GetWithdrawnAmount(
      DateTime begin_report_date,
      DateTime end_report_date)
    {
      string sql = "\n                        SELECT richbox_record.create_time, IFNULL(`affect`,0) * -1 as amount\n                        FROM `richbox_record`\n                        INNER JOIN member ON member.pk = richbox_record.member_fk\n                        WHERE `affect` < 0 AND richbox_record.src = 1 AND member.is_del = 0 AND member.is_test_account = 0\n                        AND richbox_record.create_time >= @begin_report_date AND richbox_record.create_time < @end_report_date\n                        ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            begin_report_date = begin_report_date,
            end_report_date = end_report_date
          });
          return readConnection.Query<object>(sql, (object) parameters).Select<object, (DateTime?, Decimal)>((Func<object, (DateTime?, Decimal)>) (item =>
          {
            // ISSUE: reference to a compiler-generated field
            if (RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__1 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, DateTime?>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (DateTime?), typeof (RichboxRecordService)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, DateTime?> target1 = RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__1.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, DateTime?>> p1 = RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__1;
            // ISSUE: reference to a compiler-generated field
            if (RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__0 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "create_time", typeof (RichboxRecordService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj1 = RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__0.Target((CallSite) RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__0, item);
            DateTime? nullable = target1((CallSite) p1, obj1);
            // ISSUE: reference to a compiler-generated field
            if (RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__3 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, Decimal>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (Decimal), typeof (RichboxRecordService)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, Decimal> target2 = RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__3.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, Decimal>> p3 = RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__3;
            // ISSUE: reference to a compiler-generated field
            if (RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "amount", typeof (RichboxRecordService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj2 = RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__2.Target((CallSite) RichboxRecordService.\u003C\u003Eo__10.\u003C\u003Ep__2, item);
            Decimal num = target2((CallSite) p3, obj2);
            return (nullable, num);
          })).ToList<(DateTime?, Decimal)>();
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }
  }
}
