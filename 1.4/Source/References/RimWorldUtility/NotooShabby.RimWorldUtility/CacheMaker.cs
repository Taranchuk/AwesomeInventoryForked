using System;

namespace RimWorldUtility
{
	// Token: 0x0200000A RID: 10
	public abstract class CacheMaker<T, TKey> where T : CacheableBase
	{
		// Token: 0x06000023 RID: 35
		public abstract T Make(TKey key);
	}
}
