using System;

namespace RimWorldUtility
{
	// Token: 0x02000008 RID: 8
	public class CacheableTime<TType> : CacheableBase<TType, DateTime, TimeSpan>
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00002231 File Offset: 0x00000431
		public CacheableTime(TType t, Func<DateTime> now, TimeSpan updateInterval, Func<TType> update, DateTime lastUpdateTime = default(DateTime))
			: base(t, now, updateInterval, update, DateTime.UtcNow)
		{
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002243 File Offset: 0x00000443
		public CacheableTime(TType t, TimeSpan updateInterval, Func<TType> update)
			: this(t, () => DateTime.UtcNow, updateInterval, update, DateTime.UtcNow)
		{
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002274 File Offset: 0x00000474
		public static implicit operator TType(CacheableTime<TType> cache)
		{
			DateTime dateTime;
			if (!cache.ShouldUpdate(out dateTime))
			{
				return cache._backingField;
			}
			cache.LastUpdateTime = dateTime;
			return cache._backingField = ((cache.Update == null) ? cache._backingField : cache.Update());
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000022BD File Offset: 0x000004BD
		public override bool ShouldUpdate(out DateTime now)
		{
			now = base.Now();
			return !(base.LastUpdateTime + base.UpdateInterval > now) || !this.Validate();
		}
	}
}
