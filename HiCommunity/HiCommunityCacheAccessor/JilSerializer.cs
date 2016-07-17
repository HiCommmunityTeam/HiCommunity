using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StackExchange.Redis;

namespace HiCommunityCacheAccessor
{
   public static class JilSerializer
    {
       /// <summary>
       /// 序列化Object
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="obj"></param>
       /// <returns></returns>
       public static string ToJSON<T>(this T obj)
       {
           return Jil.JSON.Serialize<T>(obj);
       }

       /// <summary>
       /// 反序列化RedisValue[json]
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="json"></param>
       /// <returns></returns>
       public static T FromJSON<T>(this RedisValue json)
       {
           return Jil.JSON.Deserialize<T>(json);
       }

       /// <summary>
       /// 反序列化string[json]
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="json"></param>
       /// <returns></returns>
       public static T FromJSON_Outer<T>(this string json)
       {
           return Jil.JSON.Deserialize<T>(json);
       }
    }
}
