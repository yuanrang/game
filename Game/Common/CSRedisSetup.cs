using Game.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Common
{
    public static class CSRedisSetup
    {
        public static void AddCSRedisSetup(this IServiceCollection services, IConfiguration configuration, string dbName = "RedisString")
        {
            //注册为本地服务 redis-server.exe --service-install redis.windows.conf
            //卸载服务：​​redis-server --service-uninstall​​
            //开启服务：​​redis-server --service-start​​
            //停止服务：​​redis-server --service-stop​​
            //设置密码
            //config set requirepass sa123456!
            var RedisCaching = ((ConfigurationSection)configuration.GetSection(dbName)).Value;
            // 注册Redis
            var csredis = new CSRedis.CSRedisClient(RedisCaching);
            RedisHelper.Initialization(csredis);
            services.AddSingleton<ICsRedisCache, CsRedisCache>();
        }
    }

    public interface ICsRedisCache
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Field"></param>
        /// <returns></returns>
        public long HDel(string Key, string Field);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Field"></param>
        /// <returns></returns>
        public bool HExists(string Key, string Field);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HSet(string key, string field, object value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public string HGet(string key, string field);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Dictionary<string, string> HGetAll(string key);

        /// <summary>
        /// 获取哈希表中字段的数量
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <returns></returns>
        public long HLen(string key);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireSeconds">expireSeconds</param>
        /// <returns></returns>
        public bool Set(string key, string value,int expireSeconds = -1);
        public bool Set(string key, string value,TimeSpan expireSeconds );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set(string key, DataTable value, int expireSeconds = -1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set(string key, AdminUser value, int expireSeconds = -1);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, int expireSeconds = -1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long Del(string key);
    }

    public class CsRedisCache : ICsRedisCache
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Field"></param>
        /// <returns></returns>
        public long HDel(string Key, string Field)
        {

            return RedisHelper.HDel(Key, Field);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Field"></param>
        /// <returns></returns>
        public bool HExists(string Key, string Field)
        {

            return RedisHelper.HExists(Key, Field);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HSet(string key, string field, object value)
        {
            return RedisHelper.HSet(key, field, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public string HGet(string key, string field)
        {
            return RedisHelper.HGet(key, field);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Dictionary<string, string> HGetAll(string key)
        {
            return RedisHelper.HGetAll(key);
        }

        /// <summary>
        /// 获取哈希表中字段的数量
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <returns></returns>
        public long HLen(string key)
        {
            return RedisHelper.HLen(key);
        }

        public string Get(string key)
        {
            return RedisHelper.Get(key);
        }

        public T Get<T>(string key)
        {
            return RedisHelper.Get<T>(key);
        }

        public bool Set(string key, string value, int expireSeconds = -1)
        {
            return RedisHelper.Set(key, value, expireSeconds);
        }
        public bool Set(string key, string value, TimeSpan expireSeconds )
        {
            return RedisHelper.Set(key, value, expireSeconds);
        }

        public bool Exists(string key)
        {
            return RedisHelper.Exists(key);
        }

        public long Del(string key)
        {
            return RedisHelper.Del(key);
        }

        public bool Set(string key, DataTable value, int expireSeconds = -1)
        {
            return RedisHelper.Set(key,value);
        }

        public bool Set(string key, AdminUser value, int expireSeconds = -1)
        {
            return RedisHelper.Set(key, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, int expireSeconds = -1)
        {
            return RedisHelper.Set(key, value);
        }
    }
}
