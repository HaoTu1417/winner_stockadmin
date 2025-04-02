// Decompiled with JetBrains decompiler
// Type: stockadmin.Filter.TranslatorUIFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using stockadmin.Business;
using stockadmin.Controllers;
using stockadmin.Libs;
using stockadmin.Tool;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Filter
{
  public class TranslatorUIFilter : ActionFilterAttribute
  {
    private string _key;

    public TranslatorUIFilter(string key) => this._key = key;

    public virtual void OnResultExecuting(ResultExecutingContext context)
    {
      Dictionary<string, string> dictionary1 = new Dictionary<string, string>()
      {
        {
          "public:search",
          "搜尋"
        },
        {
          "public:fuzzy_search",
          "模糊搜尋"
        },
        {
          "public:option",
          "管理"
        },
        {
          "public:append",
          "新增"
        },
        {
          "public:update_cache",
          "生效配置"
        },
        {
          "public:detail",
          "详情"
        },
        {
          "public:edit",
          "編輯"
        },
        {
          "public:copy",
          "複製"
        },
        {
          "public:delete",
          "刪除"
        },
        {
          "public:setup",
          "设置"
        },
        {
          "public:total_count",
          "總筆數"
        },
        {
          "public:title_create",
          "新增"
        },
        {
          "public:title_edit",
          "編輯"
        },
        {
          "public:title_copy",
          "複製"
        },
        {
          "public:back_list",
          "返回列表"
        },
        {
          "public:save",
          "儲存"
        },
        {
          "public:review",
          "审核"
        },
        {
          "public:member_fk",
          "会员编号"
        },
        {
          "public:mem_account",
          "会员帐号"
        },
        {
          "public:mem_nickname",
          "会员姓名"
        },
        {
          "public:approve",
          "同意"
        },
        {
          "public:reject",
          "不同意"
        },
        {
          "public:confirm_delete",
          "确定要删除？"
        },
        {
          "public:required",
          "必填"
        },
        {
          "public:reset",
          "清空"
        },
        {
          "public:default_time",
          "預設時間"
        },
        {
          "public:default_lang",
          "預設語言"
        },
        {
          "public:cn_lang",
          "中文版"
        },
        {
          "public:pageSize",
          "顯示筆數"
        },
        {
          "public:download",
          "下载"
        },
        {
          "public:lang",
          "語系"
        },
        {
          "public:translate",
          "翻譯"
        },
        {
          "public:lang_sync",
          "多國語言同步"
        },
        {
          "public:filter_out_test_account",
          "過濾測試帳號"
        },
        {
          "sound_on",
          "提示音开启"
        },
        {
          "sound_off",
          "提示音关闭"
        },
        {
          "notice_on",
          "提示框开启"
        },
        {
          "notice_off",
          "提示框关闭"
        },
        {
          "recharge_verify",
          " 个待确认充值"
        },
        {
          "withdraw_verify",
          " 个待确认提现"
        },
        {
          "id_auth_verify",
          " 个实名认证"
        },
        {
          "message_record_unread",
          " 个未读站内信"
        },
        {
          "recharge_notice",
          "有新的充值审核"
        },
        {
          "withdraw_notice",
          "有新的提现审核"
        },
        {
          "id_auth_notice",
          "有新的实名认证"
        },
        {
          "unread_msg_notice",
          "有新的未读站内信"
        },
        {
          "long_position",
          "多單"
        },
        {
          "short_position",
          "空單"
        },
        {
          "trial",
          "免費操盤"
        },
        {
          "free",
          "免息操盤"
        },
        {
          "day",
          "按天融資"
        },
        {
          "week",
          "按周融資"
        },
        {
          "month",
          "按月融資"
        },
        {
          "public:principal",
          "本金"
        },
        {
          "public:interest",
          "利息"
        },
        {
          "public:withdraw",
          "提取"
        },
        {
          "public:deposit",
          "存入"
        },
        {
          "public:system_title",
          "股票交易所管理系统"
        },
        {
          "public:system_name",
          "管理系统"
        },
        {
          "public:username",
          "帳號"
        },
        {
          "public:password",
          "密碼"
        },
        {
          "public:login",
          "登錄"
        },
        {
          "public:buy",
          "買入"
        },
        {
          "public:sell",
          "賣出"
        },
        {
          "public:to_be_confirmed",
          "待確認"
        },
        {
          "public:success",
          "成功"
        },
        {
          "public:failed",
          "失敗"
        }
      };
      Dictionary<string, string> dictionary2 = new Dictionary<string, string>()
      {
        {
          "public:search",
          "tìm kiếm"
        },
        {
          "public:fuzzy_search",
          "tìm kiếm mờ"
        },
        {
          "public:option",
          "quản lý"
        },
        {
          "public:append",
          "Mới"
        },
        {
          "public:update_cache",
          "Cấu hình hiệu quả"
        },
        {
          "public:detail",
          "Chi tiết"
        },
        {
          "public:edit",
          "biên tập"
        },
        {
          "public:copy",
          "dòng vô tính"
        },
        {
          "public:delete",
          "xóa bỏ"
        },
        {
          "public:setup",
          "cài đặt"
        },
        {
          "public:total_count",
          "Tổng số giao dịch"
        },
        {
          "public:title_create",
          "Mới"
        },
        {
          "public:title_edit",
          "biên tập"
        },
        {
          "public:title_copy",
          "dòng vô tính"
        },
        {
          "public:back_list",
          "Trở lại danh sách"
        },
        {
          "public:save",
          "cửa hàng"
        },
        {
          "public:review",
          "Ôn tập"
        },
        {
          "public:member_fk",
          "Số thành viên"
        },
        {
          "public:mem_account",
          "Tài khoản thành viên"
        },
        {
          "public:mem_nickname",
          "Tên thành viên"
        },
        {
          "public:approve",
          "đồng ý"
        },
        {
          "public:reject",
          "không đồng ý"
        },
        {
          "public:confirm_delete",
          "Bạn có chắc chắn muốn xóa?"
        },
        {
          "public:required",
          "Yêu cầu"
        },
        {
          "public:reset",
          "Thông thoáng"
        },
        {
          "public:default_time",
          "Thời gian mặc định"
        },
        {
          "public:default_lang",
          "Ngôn ngữ mặc định"
        },
        {
          "public:cn_lang",
          "Phiên bản Trung Quốc"
        },
        {
          "public:pageSize",
          "Hiển thị số lượng bút"
        },
        {
          "public:download",
          "Tải xuống"
        },
        {
          "public:lang",
          "họ ngôn ngữ"
        },
        {
          "public:translate",
          "dịch"
        },
        {
          "public:lang_sync",
          "Đồng bộ hóa đa ngôn ngữ"
        },
        {
          "public:filter_out_test_account",
          "Lọc tài khoản thử nghiệm"
        }
      };
      Dictionary<string, string> dictionary3 = new Dictionary<string, string>()
      {
        {
          "public:search",
          "Search"
        },
        {
          "public:fuzzy_search",
          "Fuzzy search"
        },
        {
          "public:option",
          "Option"
        },
        {
          "public:append",
          "Append"
        },
        {
          "public:update_cache",
          "Update cache"
        },
        {
          "public:detail",
          "Details"
        },
        {
          "public:edit",
          "Edit"
        },
        {
          "public:copy",
          "Copy"
        },
        {
          "public:delete",
          "Delete"
        },
        {
          "public:setup",
          "Setup"
        },
        {
          "public:total_count",
          "Total"
        },
        {
          "public:title_create",
          "Create"
        },
        {
          "public:title_edit",
          "Edit"
        },
        {
          "public:title_copy",
          "Copy"
        },
        {
          "public:back_list",
          "Back"
        },
        {
          "public:save",
          "Save"
        },
        {
          "public:review",
          "Review"
        },
        {
          "public:member_fk",
          "Member number"
        },
        {
          "public:mem_account",
          "Member account"
        },
        {
          "public:mem_nickname",
          "Member nickname"
        },
        {
          "public:approve",
          "Approve"
        },
        {
          "public:reject",
          "Reject"
        },
        {
          "public:confirm_delete",
          "Confirm to delete?"
        },
        {
          "public:required",
          "Required"
        },
        {
          "public:reset",
          "Reset"
        },
        {
          "public:default_time",
          "Default time"
        },
        {
          "public:default_lang",
          "Default language"
        },
        {
          "public:cn_lang",
          "Chinese"
        },
        {
          "public:pageSize",
          "Page size"
        },
        {
          "public:download",
          "Download"
        },
        {
          "public:lang",
          "Language"
        },
        {
          "public:translate",
          "Translate"
        },
        {
          "public:lang_sync",
          "Multi-language synchronization"
        },
        {
          "public:filter_out_test_account",
          "Filter out test accounts"
        },
        {
          "sound_on",
          "Sound on"
        },
        {
          "sound_off",
          "Sound off"
        },
        {
          "notice_on",
          "Notice on"
        },
        {
          "notice_off",
          "Notice off"
        },
        {
          "recharge_verify",
          " recharge(s)"
        },
        {
          "withdraw_verify",
          " withdraw(s)"
        },
        {
          "id_auth_verify",
          " id auth(s)"
        },
        {
          "message_record_unread",
          " message(s)"
        },
        {
          "recharge_notice",
          "There is a new recharge review"
        },
        {
          "withdraw_notice",
          "There is a new withdrawal review"
        },
        {
          "id_auth_notice",
          "There is a new real-name authentication"
        },
        {
          "unread_msg_notice",
          "There are new unread messages"
        },
        {
          "long_position",
          "Long"
        },
        {
          "short_position",
          "Short"
        },
        {
          "trial",
          "Free trading"
        },
        {
          "free",
          "Interest-free"
        },
        {
          "day",
          "By the day"
        },
        {
          "week",
          "By the week"
        },
        {
          "month",
          "By the month"
        },
        {
          "vip",
          "VIP"
        },
        {
          "public:principal",
          "Principal"
        },
        {
          "public:interest",
          "Interest"
        },
        {
          "public:withdraw",
          "Withdraw"
        },
        {
          "public:deposit",
          "Deposit"
        },
        {
          "public:system_title",
          "Stock exchange management system"
        },
        {
          "public:system_name",
          "management system"
        },
        {
          "public:username",
          "Username"
        },
        {
          "public:password",
          "Password"
        },
        {
          "public:login",
          "Login"
        },
        {
          "public:buy",
          "Buy"
        },
        {
          "public:sell",
          "Sell"
        },
        {
          "public:to_be_confirmed",
          "To be confirmed"
        },
        {
          "public:success",
          "Success"
        },
        {
          "public:failed",
          "Failed"
        }
      };
      BaseController controller = context.Controller as BaseController;
      string lang = !(this._key == "Login") ? controller.GetLanguage() : MutilangSubjectService.FindAdminDefault().lang;
      Dictionary<string, string> dictionary4;
      switch (lang.ToLower())
      {
        case "cn":
          dictionary4 = dictionary1;
          break;
        case "vn":
          dictionary4 = dictionary2;
          break;
        case "en":
          dictionary4 = dictionary3;
          break;
        default:
          dictionary4 = dictionary1;
          break;
      }
      Dictionary<string, string> second = dictionary4;
      LogLib.Debug("[TranslatorUIFilter] key: " + this._key + " lang: " + lang);
      string json = MutilangCacheService.FindJson(this._key, lang) ?? MutilangService.FindJson(this._key);
      LogLib.Debug("[TranslatorUIFilter] json: " + json);
      Dictionary<string, string> dictionary5 = PublicTool.FromJson<Dictionary<string, string>>(json).Concat<KeyValuePair<string, string>>((IEnumerable<KeyValuePair<string, string>>) second).ToDictionary<KeyValuePair<string, string>, string, string>((Func<KeyValuePair<string, string>, string>) (k => k.Key), (Func<KeyValuePair<string, string>, string>) (v => v.Value));
      controller.ViewData["Lang"] = (object) dictionary5;
      controller.ViewData["menu_logo_url"] = (object) AppLogoBiz.GetAppLogoUrl(4);
    }
  }
}
