using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestAPI.Data
{
    public static class RedisConnectorHelper
    {
        public static ConnectionMultiplexer RedisInstance { get; set; }

        public static IDatabase GetConnection()
        {
            using(ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379,allowAdmin=true"))
            {
                IDatabase db = redis.GetDatabase();
                return db;
            }
        }       
    }
}
