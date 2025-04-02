// Decompiled with JetBrains decompiler
// Type: stockadmin.Services.ViewExchangeRateService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using Dapper;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.ExchangeRate;
using System;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Services
{
    public class ViewExchangeRateService
    {
        public static List<ExchangeRateList> FindExchangeRateList(string whereSql = "")
        {
            string sql = "SELECT `date`, `currency_symbol`, `base_symbol`, `inward_rate`, `outward_rate`, `create_time` FROM `vw_exchange_rate`\n\t\t\t\t\t\t\t" + whereSql + " order by create_time DESC";
            try
            {
                using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
                    return readConnection.Query<ExchangeRateList>(sql).AsList<ExchangeRateList>();
            }
            catch (Exception ex)
            {
                LogLib.Log("[ViewExchangeRateService][FindExchangeRateList]" + ex.Message);
                return (List<ExchangeRateList>) null;
            }
        }

        public static VwExchangeRateDto GetViewExchangeRate(string currency_symbol, string base_symbol)
        {
            string sql = "SELECT * FROM `vw_exchange_rate` WHERE currency_symbol = @currency_symbol AND base_symbol = @base_symbol ORDER BY create_time DESC";
            var data = new
            {
                currency_symbol = currency_symbol,
                base_symbol = base_symbol
            };
            try
            {
                using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
                    return readConnection.QueryFirst<VwExchangeRateDto>(sql, (object) data);
            }
            catch (Exception ex)
            {
                throw new AppException(1040, "read_db_exception");
            }
        }
    }
}