// Decompiled with JetBrains decompiler
// Type: stockadmin.Internal.DapperMysql
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using Dapper;
using MySqlConnector;
using System.Reflection;
using MySql.Data.MySqlClient;
using MySqlConnection = MySqlConnector.MySqlConnection;

#nullable enable
namespace stockadmin.Internal
{
    public class DapperMysql
    {
        private static string? _writeConn;
        private static string? _readConn;

        public static void Init(string? writeConn, string? readConn)
        {
            DapperMysql._writeConn = writeConn;
            DapperMysql._readConn = readConn;
        }

        public static MySqlConnection? GetReadConnection()
        {
            MySqlConnection readConnection = new MySqlConnection(DapperMysql._readConn);
            readConnection.Open();
            return readConnection;
        }

        public static MySqlConnection? GetWriteConntion()
        {
            MySqlConnection writeConntion = new MySqlConnection(DapperMysql._writeConn);
            writeConntion.Open();
            return writeConntion;
        }

        public static DynamicParameters GetParameters(object obj)
        {
            DynamicParameters parameters = new DynamicParameters();
            foreach (PropertyInfo property in obj.GetType().GetProperties())
                parameters.Add("@" + property.Name, property.GetValue(obj));
            parameters.RemoveUnused = true;
            return parameters;
        }
    }
}