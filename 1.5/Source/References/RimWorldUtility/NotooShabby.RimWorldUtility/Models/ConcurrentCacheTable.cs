using System;
using System.Collections.Concurrent;

namespace RimWorldUtility.Models
{
	// Token: 0x02000036 RID: 54
	public class ConcurrentCacheTable<TKey, TValue> : CacheTable<TKey, TValue> where TValue : CacheableBase
	{
		// Token: 0x060000F2 RID: 242 RVA: 0x0000569E File Offset: 0x0000389E
		public ConcurrentCacheTable(CacheMaker<TValue, TKey> maker)
			: base(maker)
		{
			this._cache = new ConcurrentDictionary<TKey, TValue>();
		}
	}
}
