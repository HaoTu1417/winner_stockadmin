// Decompiled with JetBrains decompiler
// Type: DB.Services.RichboxPrincipalService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Microsoft.CSharp.RuntimeBinder;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class RichboxPrincipalService
  {
    public static Decimal TotalAmount(int member_fk)
    {
      string sql = "\nSELECT IFNULL(SUM(`amount`),0)\nFROM `richbox_principal`\nWHERE `member_fk` = @member_fk\n";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return readConnection.ExecuteScalar<Decimal>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static Decimal TotalAmount()
    {
      string sql = "\nSELECT IFNULL(SUM(`amount`),0)\nFROM `richbox_principal`\n";
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

    public static Decimal GetTotalAmount()
    {
      string sql = "\n                        SELECT IFNULL(SUM(`total_amount`),0)\n                        FROM `vw_richbox_principal_summary`\n                    ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          // ISSUE: reference to a compiler-generated field
          if (RichboxPrincipalService.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            RichboxPrincipalService.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, Decimal>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Decimal), typeof (RichboxPrincipalService)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          return RichboxPrincipalService.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) RichboxPrincipalService.\u003C\u003Eo__2.\u003C\u003Ep__0, readConnection.ExecuteScalar<object>(sql));
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static List<VwRichboxPrincipalDto> FindAllVwRichBoxPrincipal()
    {
      string sql = "\n                        SELECT *\n                        FROM `vw_richbox_principal_summary`\n                    ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<VwRichboxPrincipalDto>(sql).AsList<VwRichboxPrincipalDto>();
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static VwRichboxPrincipalDto FindLastVwRichBoxPrincipal(DateTime date)
    {
      string sql = "\n                      SELECT *\n                            FROM `vw_richbox_principal_summary`\n                            WHERE `create_time` < @date\n                            ORDER BY `create_time` DESC\n                            LIMIT 1;\n                     ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            date = date
          });
          return readConnection.QueryFirstOrDefault<VwRichboxPrincipalDto>(sql, (object) parameters);
        }
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
      string sql = "\n                        SELECT date, IFNULL(`amount`,0) as amount\n                        FROM `richbox_principal`\n                        INNER JOIN member ON member.pk = richbox_principal.member_fk\n                        WHERE `amount` > 0 AND member.is_del = 0 AND member.is_test_account = 0\n                        AND date >= @begin_report_date AND date < @end_report_date\n                    ";
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
            if (RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__1 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, DateTime?>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (DateTime?), typeof (RichboxPrincipalService)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, DateTime?> target1 = RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__1.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, DateTime?>> p1 = RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__1;
            // ISSUE: reference to a compiler-generated field
            if (RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__0 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "date", typeof (RichboxPrincipalService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj1 = RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__0.Target((CallSite) RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__0, item);
            DateTime? nullable = target1((CallSite) p1, obj1);
            // ISSUE: reference to a compiler-generated field
            if (RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__3 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, Decimal>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (Decimal), typeof (RichboxPrincipalService)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, Decimal> target2 = RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__3.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, Decimal>> p3 = RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__3;
            // ISSUE: reference to a compiler-generated field
            if (RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "amount", typeof (RichboxPrincipalService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj2 = RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__2.Target((CallSite) RichboxPrincipalService.\u003C\u003Eo__5.\u003C\u003Ep__2, item);
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
      string sql = "\n                        SELECT date, IFNULL(`amount`,0) as amount\n                        FROM `richbox_principal`\n                        INNER JOIN member ON member.pk = richbox_principal.member_fk\n                        WHERE `amount` < 0 AND member.is_del = 0 AND member.is_test_account = 0\n                        AND date >= @begin_report_date AND date < @end_report_date\n                        ";
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
            if (RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__1 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, DateTime?>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (DateTime?), typeof (RichboxPrincipalService)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, DateTime?> target1 = RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__1.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, DateTime?>> p1 = RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__1;
            // ISSUE: reference to a compiler-generated field
            if (RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__0 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "date", typeof (RichboxPrincipalService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj1 = RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__0.Target((CallSite) RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__0, item);
            DateTime? nullable = target1((CallSite) p1, obj1);
            // ISSUE: reference to a compiler-generated field
            if (RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__3 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, Decimal>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (Decimal), typeof (RichboxPrincipalService)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, Decimal> target2 = RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__3.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, Decimal>> p3 = RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__3;
            // ISSUE: reference to a compiler-generated field
            if (RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "amount", typeof (RichboxPrincipalService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj2 = RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__2.Target((CallSite) RichboxPrincipalService.\u003C\u003Eo__6.\u003C\u003Ep__2, item);
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

    public static DateTime? FirstDate(int member_fk)
    {
      string sql = "\nSELECT MIN(`date`)\nFROM `richbox_principal`\nWHERE `member_fk` = @member_fk\n";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return readConnection != null ? readConnection.ExecuteScalar<DateTime?>(sql, (object) parameters) : new DateTime?();
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static DateTime? LastDate(int member_fk)
    {
      string sql = "\nSELECT MAX(`date`)\nFROM `richbox_principal`\nWHERE `member_fk` = @member_fk\n";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return readConnection != null ? readConnection.ExecuteScalar<DateTime?>(sql, (object) parameters) : new DateTime?();
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static uint Insert(RichBoxPrincipalDto model)
    {
      string sql = "\nINSERT INTO `richbox_principal`\n(`member_fk`, `pk`, `amount`, `date`, `remarks`)\nVALUES\n(@member_fk, @pk, @amount, @date, @remarks);\n\nSELECT LAST_INSERT_ID();\n";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<uint>(sql, (object) model);
      }
      catch (Exception ex)
      {
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<RichBoxPrincipalDto> FindAllByMember(int member_fk)
    {
      string sql = "\nSELECT `member_fk`, `pk`, `amount`, `date`, `remarks`\nFROM `richbox_principal`\nWHERE `member_fk` = @member_fk\nORDER BY `date`,`pk`\n";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return (readConnection != null ? readConnection.Query<RichBoxPrincipalDto>(sql, (object) parameters) : (IEnumerable<RichBoxPrincipalDto>) null).AsList<RichBoxPrincipalDto>();
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static List<RichBoxPrincipalDto> FindAllByMembers(int[] member_fk_array)
    {
      string sql = "\nSELECT `member_fk`, `pk`, `amount`, `date`, `remarks`\nFROM `richbox_principal`\nWHERE `member_fk` IN ({member_fk_array})\nORDER BY `date`,`pk`\n".Replace("{member_fk_array}", string.Join<int>(",", (IEnumerable<int>) member_fk_array));
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return (readConnection != null ? readConnection.Query<RichBoxPrincipalDto>(sql) : (IEnumerable<RichBoxPrincipalDto>) null).AsList<RichBoxPrincipalDto>();
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static DateTime MinDate()
    {
      string sql = " SELECT MIN(date) FROM `richbox_principal` ";
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
  }
}
