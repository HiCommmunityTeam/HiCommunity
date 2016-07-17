using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StackExchange.Redis;

namespace HiCommunityCacheAccessor
{
    public class RedisClientMgr
    {
        public static ConnectionMultiplexer redis = null;

        public static void InitConnection(string host)
        {
            redis = ConnectionMultiplexer.Connect(host);
        }

        public static IDatabase GetRedisClient()
        {
            return redis.GetDatabase();
        }
    }
}
