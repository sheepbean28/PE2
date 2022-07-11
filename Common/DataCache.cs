using System;
using System.Web;

namespace Maticsoft.Common
{
	/// <summary>
	/// 遣湔眈壽腔紱釬濬
    /// Copyright (C) Maticsoft
	/// </summary>
	public class DataCache
	{
		/// <summary>
		/// 鳳絞茼蚚最唗硌隅CacheKey腔Cache硉
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <returns></returns>
		public static object GetCache(string CacheKey)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			return objCache[CacheKey];
		}

		/// <summary>
		/// 扢离絞茼蚚最唗硌隅CacheKey腔Cache硉
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public static void SetCache(string CacheKey, object objObject)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			objCache.Insert(CacheKey, objObject);
		}

		/// <summary>
		/// 扢离絞茼蚚最唗硌隅CacheKey腔Cache硉
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration,TimeSpan slidingExpiration )
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			objCache.Insert(CacheKey, objObject,null,absoluteExpiration,slidingExpiration);
		}
	}
}
