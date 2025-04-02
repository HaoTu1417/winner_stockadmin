// Decompiled with JetBrains decompiler
// Type: stockadmin.Internal.RedisEntity
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using stockadmin.Libs;
using System;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Internal
{
    public class RedisEntity
    {
        private static IConfiguration _config = (IConfiguration) new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        public static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>((Func<ConnectionMultiplexer>) (() =>
        {
            try
            {
                return ConnectionMultiplexer.Connect(RedisEntity._config["RedisCacheUrl"]);
            }
            catch (RedisConnectionException ex)
            {
                LogLib.Log(ex.Message);
                throw new AppException(1020, "redis_exception");
            }
        }));

        public static IEnumerable<RedisKey> GetKeys(int dbNum = 0)
        {
            string hostAndPort = RedisEntity._config["RedisCacheUrl"];
            return RedisEntity.lazyConnection.Value.GetServer(hostAndPort, (object) null).Keys(dbNum);
        }

        public static IDatabase SelectDb(int dbNum = 0)
        {
            return RedisEntity.lazyConnection.Value.GetDatabase(dbNum, (object) null);
        }
    }
}