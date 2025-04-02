// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.StatWalletRecordDetailBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.StatWalletRecordDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Business
{
  public class StatWalletRecordDetailBiz
  {
    public static DataCountBase<StatWalletRecordDetailList> GetStatWalletRecordDetailList(
      StatWalletRecordDetailFilter? filter,
      string lang,
      int page,
      int pageSize)
    {
      string str = SqlTool.Build<StatWalletRecordDetailFilter>(filter).Must("wallet_template.lang = '" + lang + "' and member.is_del = 0");
      if (filter.filter_out_test_account)
        str = str.Must("member.is_test_account = 0");
      DataCountBase<StatWalletRecordDetailList> recordDetailList = WalletRecordService.FindStatWalletRecordDetailList(page, pageSize, str);
      return new DataCountBase<StatWalletRecordDetailList>(recordDetailList.count, recordDetailList.data.Select<StatWalletRecordDetailList, StatWalletRecordDetailList>((Func<StatWalletRecordDetailList, StatWalletRecordDetailList>) (statWalletRecord => PublicTool.convertUtcToLocalTime<StatWalletRecordDetailList>(statWalletRecord))));
    }

    public static DataCountBase<StatWalletRecordDetailList> GetStatWalletRecordDetailListByAdminDefaultLang(
      StatWalletRecordDetailFilter? filter,
      int page,
      int pageSize)
    {
      string lang = MutilangSubjectBiz.GetAdminDefault().lang;
      string whereSql = SqlTool.Build<StatWalletRecordDetailFilter>(filter).Must("wallet_template.lang = '" + lang + "'");
      DataCountBase<StatWalletRecordDetailList> recordDetailList1 = WalletRecordService.FindStatWalletRecordDetailList(page, pageSize, whereSql, lang);
      return new DataCountBase<StatWalletRecordDetailList>(recordDetailList1.count, (IEnumerable<StatWalletRecordDetailList>) recordDetailList1.data.Select<StatWalletRecordDetailList, StatWalletRecordDetailList>((Func<StatWalletRecordDetailList, StatWalletRecordDetailList>) (statWalletRecord =>
      {
        PublicTool.convertUtcToLocalTime<StatWalletRecordDetailList>(statWalletRecord);
        string[] strArray = statWalletRecord.param?.Split('|', StringSplitOptions.None);
        if (strArray != null)
        {
          for (int index = 0; index < strArray.Length; ++index)
          {
            StatWalletRecordDetailList recordDetailList2 = statWalletRecord;
            string template = statWalletRecord.template;
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
            interpolatedStringHandler.AppendLiteral("#");
            interpolatedStringHandler.AppendFormatted<int>(index);
            interpolatedStringHandler.AppendLiteral("#");
            string stringAndClear = interpolatedStringHandler.ToStringAndClear();
            string newValue = strArray[index]?.ToString();
            string str = template.Replace(stringAndClear, newValue);
            recordDetailList2.template = str;
          }
          statWalletRecord.info = statWalletRecord.template;
        }
        return statWalletRecord;
      })).ToList<StatWalletRecordDetailList>());
    }

    public static WalletRecordDto Get(int pk) => WalletRecordService.Find(pk);

    public static void PostCreate(WalletRecordDto req)
    {
      if (WalletRecordService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(WalletRecordDto req)
    {
      if (WalletRecordService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => WalletRecordService.Remove(pk);

    public static byte[]? DownloadStatWalletRecordDetailList(
      StatWalletRecordDetailFilter? filter,
      string language,
      bool download_cn = false)
    {
      return Exportlib.ExportExcel<StatWalletRecordDetailList>((!download_cn ? StatWalletRecordDetailBiz.GetStatWalletRecordDetailList(filter, language, 1, int.MaxValue) : StatWalletRecordDetailBiz.GetStatWalletRecordDetailListByAdminDefaultLang(filter, 1, int.MaxValue)).data);
    }
  }
}
