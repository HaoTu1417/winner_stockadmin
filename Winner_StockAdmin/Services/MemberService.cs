// Decompiled with JetBrains decompiler
// Type: DB.Services.MemberService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.Member;
using stockadmin.ViewModels.ReviewMember;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class MemberService
  {
    public static MemberDto Find(int pk)
    {
      string sql = "SELECT member.*, m.nickname AS recommend_name FROM `member`\n                        LEFT JOIN `recommend_register` ON recommend_register.invitee_fk=member.pk\n                        LEFT JOIN `member` m ON m.pk=recommend_register.member_fk\n                        WHERE member.`pk` = @pk\n                        ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<MemberDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        LogLib.Log("[MemberService][Find]" + ex.Message);
        return (MemberDto) null;
      }
    }

    public static MemberDto FindByAccount(string account)
    {
      string sql = "SELECT * FROM `member` WHERE `account` = @account";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            account = account
          });
          return readConnection.QueryFirstOrDefault<MemberDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][FindByAccount]" + ex.Message);
        return (MemberDto) null;
      }
    }

    public static List<MemberDto> FindAll()
    {
      string sql = "SELECT * FROM `member`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MemberDto>(sql).AsList<MemberDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][FindAll]" + ex.Message);
        return (List<MemberDto>) null;
      }
    }

    public static int FindPkAfterInsert(MemberDto source)
    {
      string sql = "INSERT INTO `member` (\n\t\t\t\t`admin_user_fk`, `id`, `account`, `nickname`, `real_name`, `email`, `mobile_country`, `mobile`, `passwd`, `token`, `sub_account`, `paywd`, `id_card`, `id_card_type`, `id_auth`, `status`, `is_del`, `create_time`, `create_ip`, `last_login_time`, `last_login_ip`, `urgent_name`, `urgent_mobile`, `auth_time`, `auth_result`, `head_img`, `card_pic_front`, `card_pic_back`, `card_pic_hand`, `invitation_code`, `recommend`, `recommend_id`, `card_pic`, `level_id`, `remark`, `country`, `time_zone`, `lang`, `sms_status`, `email_status`)\n\t\t\t\tVALUES (@admin_user_fk, @id, @account, @nickname, @real_name, @email, @mobile_country, @mobile, @passwd, @token, @sub_account, @paywd, @id_card, @id_card_type, @id_auth, @status, @is_del, @create_time, @create_ip, @last_login_time, @last_login_ip, @urgent_name, @urgent_mobile, @auth_time, @auth_result, @head_img, @card_pic_front, @card_pic_back, @card_pic_hand, @invitation_code, @recommend, @recommend_id, @card_pic, @level_id, @remark, @country, @time_zone, @lang, @sms_status, @email_status);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(MemberDto model)
    {
      string sql = "UPDATE `member` SET \n\t\t\t\t`admin_user_fk` = @admin_user_fk,\n\t\t\t\t`id` = @id,\n\t\t\t\t`account` = @account,\n\t\t\t\t`nickname` = @nickname,\n\t\t\t\t`real_name` = @real_name,\n\t\t\t\t`email` = @email,\n\t\t\t\t`mobile_country` = @mobile_country,\n\t\t\t\t`mobile` = @mobile,\n\t\t\t\t`passwd` = @passwd,\n\t\t\t\t`token` = @token,\n\t\t\t\t`sub_account` = @sub_account,\n\t\t\t\t`paywd` = @paywd,\n\t\t\t\t`id_card` = @id_card,\n\t\t\t\t`id_card_type` = @id_card_type,\n\t\t\t\t`id_auth` = @id_auth,\n\t\t\t\t`status` = @status,\n\t\t\t\t`is_del` = @is_del,\n\t\t\t\t`create_time` = @create_time,\n\t\t\t\t`create_ip` = @create_ip,\n\t\t\t\t`last_login_time` = @last_login_time,\n\t\t\t\t`last_login_ip` = @last_login_ip,\n\t\t\t\t`urgent_name` = @urgent_name,\n\t\t\t\t`urgent_mobile` = @urgent_mobile,\n\t\t\t\t`auth_time` = @auth_time,\n\t\t\t\t`auth_result` = @auth_result,\n\t\t\t\t`head_img` = @head_img,\n\t\t\t\t`card_pic_front` = @card_pic_front,\n\t\t\t\t`card_pic_back` = @card_pic_back,\n\t\t\t\t`card_pic_hand` = @card_pic_hand,\n\t\t\t\t`invitation_code` = @invitation_code,\n\t\t\t\t`recommend` = @recommend,\n\t\t\t\t`recommend_id` = @recommend_id,\n\t\t\t\t`card_pic` = @card_pic,\n\t\t\t\t`level_id` = @level_id,\n\t\t\t\t`remark` = @remark,\n\t\t\t\t`country` = @country,\n\t\t\t\t`time_zone` = @time_zone,\n\t\t\t\t`lang` = @lang,\n\t\t\t\t`sms_status` = @sms_status,\n\t\t\t\t`email_status` = @email_status\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdatePart(MemberDto model)
    {
      string sql = "UPDATE `member` SET \n\t\t\t\t`admin_user_fk` = @admin_user_fk,\t\t\t\t\t\t\t\t\n\t\t\t\t`nickname` = @nickname,\n\t\t\t\t`remark` = @remark,\n\t\t\t\t`level_id` = @level_id,\n\t\t\t\t`need_withdraw_selfie` = @need_withdraw_selfie,\n\t\t\t\t`trial_rate` = @trial_rate,\n\t\t\t\t`free_rate` = @free_rate,\n\t\t\t\t`day_rate` = @day_rate,\n\t\t\t\t`week_rate` = @week_rate,\n\t\t\t\t`month_rate` = @month_rate,\n\t\t\t\t`vip_rate` = @vip_rate\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][UpdatePart]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateRichBoxRate(int pk, Decimal richbox_rate)
    {
      string sql = "UPDATE `member` SET \n\t\t\t\t`richbox_rate` = @richbox_rate\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        DynamicParameters parameters = DapperMysql.GetParameters((object) new
        {
          pk = pk,
          richbox_rate = richbox_rate
        });
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) parameters);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][UpdateRichBoxRate]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateNickName(int pk, string nickname)
    {
      string sql = "UPDATE `member` SET \n\t\t\t\t`nickname` = @nickname\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk,
            nickname = nickname
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateSubAccount(int pk, string subAccount)
    {
      string sql = "UPDATE `member` SET \n\t\t\t\t`sub_account` = @subAccount\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            pk = pk,
            subAccount = subAccount
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int SetDelete(int pk)
    {
      string sql = "UPDATE `member` SET \n\t\t\t\t`is_del` = 1\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            pk = pk
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int SetStatus(int pk, int status)
    {
      string sql = "UPDATE `member` SET \n\t\t\t\t`status` = @status\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            pk = pk,
            status = status
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][SetStatus]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int RemoveEmailAndIdCard(int pk)
    {
      string sql = "UPDATE `member` SET \n\t\t\t\t`email` = NULL,\n\t\t\t\t`id_card` = NULL\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            pk = pk
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][RemoveEmail]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `member` WHERE `pk` = @pk";
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
        LogLib.Log("[MemberService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static DataCountBase<ReviewMemberList> FindReviewMemberList(
      int page,
      int pageSize,
      string whereSql = "",
      string lang = "VN")
    {
      string sql = "\n                    SELECT \n                        COUNT(*) AS count\n                    FROM `member`\n                    LEFT JOIN `recommend_register` ON recommend_register.invitee_fk=member.pk\n                    LEFT JOIN `member` m2 ON m2.pk=recommend_register.member_fk\n                    " + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(584, 4);
      interpolatedStringHandler.AppendLiteral("SELECT member.pk, member.auth_time, member.account, member.real_name, member.email, member.id_auth, member.create_time, \n                    member.create_ip, member.auth_result, m2.invitation_code as recommend_code, m2.account as recommend_id, '");
      interpolatedStringHandler.AppendFormatted(lang);
      interpolatedStringHandler.AppendLiteral("' as admin_lang\n                    FROM `member`\n                    LEFT JOIN `recommend_register` ON recommend_register.invitee_fk=member.pk\n                    LEFT JOIN `member` m2 ON m2.pk=recommend_register.member_fk\n                    ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\n\t\t\t\t\tORDER BY member.create_time DESC\n                    LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n                    OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<ReviewMemberList>(readConnection.QuerySingle<int>(sql), (IEnumerable<ReviewMemberList>) readConnection.Query<ReviewMemberList>(stringAndClear).AsList<ReviewMemberList>());
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][FindReviewMemberList]" + ex.Message);
        return new DataCountBase<ReviewMemberList>();
      }
    }

    public static ReviewMemberReview FindReviewMemberReview(int pk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(265, 1);
      interpolatedStringHandler.AppendLiteral("SELECT pk, member.admin_user_fk, member.account, member.nickname, member.real_name, member.email, \n\t\t\t\tmember.id_card, member.id_card_type, member.create_time, member.create_ip, member.auth_result, member.card_pic_front, \n\t\t\t\tmember.remark FROM `member` where pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<ReviewMemberReview>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][FindReviewMemberReview]" + ex.Message);
        return (ReviewMemberReview) null;
      }
    }

    public static DataCountBase<MemberList> FindMemberList(
      string whereSql = "",
      bool getAll = false,
      int page = 1,
      int pageSize = 20,
      string lang = "VN")
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler;
      string str1;
      if (!getAll)
      {
        interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 2);
        interpolatedStringHandler.AppendLiteral("LIMIT ");
        interpolatedStringHandler.AppendFormatted<int>(pageSize);
        interpolatedStringHandler.AppendLiteral(" OFFSET ");
        interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
        str1 = interpolatedStringHandler.ToStringAndClear();
      }
      else
        str1 = string.Empty;
      string str2 = str1;
      string sql = "SELECT \n                        COUNT(0) AS count\n                        FROM `member` \n                        LEFT JOIN `admin_user` ON admin_user.pk=member.admin_user_fk\n                        LEFT JOIN `recommend_register` ON recommend_register.invitee_fk=member.pk\n                        LEFT JOIN `member` m2 ON m2.pk=recommend_register.member_fk\n                        " + whereSql + ";";
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(1045, 3);
      interpolatedStringHandler.AppendLiteral("SELECT member.admin_user_fk, admin_user.nickname AS admin_user_name, member.pk, member.account, \n                        member.nickname, member.real_name, member.lang, member.create_time, m2.invitation_code as recommend_code, m2.account AS recommend_id, \n                        member.invitation_code, member.last_login_time, member.last_login_ip, member.level_id, member.remark, \n                        member.is_del, member.status, member.is_test_account, member.email, member.mobile as mobile_number, wallet.richbox_balance, wallet.richbox_interest, '");
      interpolatedStringHandler.AppendFormatted(lang);
      interpolatedStringHandler.AppendLiteral("' as admin_lang\n                        FROM `member` \n                        LEFT JOIN `wallet` ON wallet.member_fk=member.pk\n                        LEFT JOIN `admin_user` ON admin_user.pk=member.admin_user_fk\n                        LEFT JOIN `recommend_register` ON recommend_register.invitee_fk=member.pk\n                        LEFT JOIN `member` m2 ON m2.pk=recommend_register.member_fk\n                        ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\n\t\t\t\t\t\tORDER BY member.last_login_time DESC\n                        ");
      interpolatedStringHandler.AppendFormatted(str2);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<MemberList>(readConnection.QuerySingle<int>(sql), (IEnumerable<MemberList>) readConnection.Query<MemberList>(stringAndClear).AsList<MemberList>());
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][FindMemberList]" + ex.Message);
        return new DataCountBase<MemberList>();
      }
    }

    public static int UpdateTestAccount(int pk)
    {
      string sql = "UPDATE `member` SET \n\t\t\t\t`is_test_account` = true,\n                 nickname = `account`,\n                 real_name = `account`\n\t\t\t\t WHERE `pk` = @pk";
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
        LogLib.Log("[MemberService][UpdateTestAccount]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateStatus(int pk, int status)
    {
      string sql = "UPDATE `member` SET \n\t\t\t\t`id_auth` = @status\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            pk = pk,
            status = status
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateAuthTimeAndResult(int pk, DateTime auth_time, string auth_result)
    {
      string sql = "UPDATE `member` SET \n\t\t\t\t`auth_time` = @auth_time,\n\t\t\t\t`auth_result` = @auth_result\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            pk = pk,
            auth_time = auth_time,
            auth_result = auth_result
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateAdminUserFk(int pk, int admin_user_fk)
    {
      string sql = "UPDATE `member` SET \n\t\t\t\t`admin_user_fk` = @admin_user_fk\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            pk = pk,
            admin_user_fk = admin_user_fk
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][UpdateAdminUserFk]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateDel(int pk, bool status)
    {
      string sql = "UPDATE `member` SET \n\t\t\t\t`is_del` = @status\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            pk = pk,
            status = status
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static MemberDto GetMemberByInvitationCode(string invitation_code)
    {
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          string sql = "SELECT * FROM `member` WHERE `invitation_code` = @invitation_code";
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            invitation_code = invitation_code
          });
          return readConnection.QueryFirstOrDefault<MemberDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    internal static void UpdateRecommend(int memberId, string invitation_code, int recommend)
    {
      string sql = "UPDATE `member` SET \n                `recommend` = @invitation_code,\n                `recommend_id` = @recommend\n                 WHERE `pk` = @memberId";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            invitation_code = invitation_code,
            recommend = recommend,
            memberId = memberId
          });
          writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][UpdateRecommend]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int GetMemberCount(string whereSql)
    {
      string sql = "SELECT COUNT(*) from member\n                    LEFT JOIN `recommend_register` ON recommend_register.invitee_fk=member.pk\n                    LEFT JOIN `member` m2 ON m2.pk=recommend_register.member_fk\n                    " + whereSql + "\n\t\t\t\t\tORDER BY member.create_time DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.ExecuteScalar<int>(sql);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][GetMemberCount]" + ex.Message);
        return 0;
      }
    }

    internal static MemberDto FindParent(int man)
    {
      try
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(88, 1);
        interpolatedStringHandler.AppendLiteral("SELECT * FROM `member` WHERE pk = (SELECT m.recommend_id FROM `member` m WHERE m.pk = ");
        interpolatedStringHandler.AppendFormatted<int>(man);
        interpolatedStringHandler.AppendLiteral(" )");
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QuerySingleOrDefault<MemberDto>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][FindParent]" + ex.Message);
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static int GetReviewMemberCount()
    {
      string sql = "SELECT COUNT(*) FROM `member` where id_auth = 3 AND is_del = 0 AND is_test_account = 0";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.ExecuteScalar<int>(sql);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberService][GetReviewMemberCount]" + ex.Message);
        return 0;
      }
    }

    public static Decimal GetRichBoxRate(int member_fk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 1);
      interpolatedStringHandler.AppendLiteral("SELECT richbox_rate FROM `member` where pk = ");
      interpolatedStringHandler.AppendFormatted<int>(member_fk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.ExecuteScalar<Decimal>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberServices][GetRichBoxRate]" + ex.Message);
        return 0M;
      }
    }
  }
}
