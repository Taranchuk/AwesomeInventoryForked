using System;

namespace RimWorldUtility
{
	// Token: 0x02000009 RID: 9
	public class CacheableTick<TType> : CacheableBase<TType, int, int>
	{
		// Token: 0x06000020 RID: 32 RVA: 0x000022F9 File Offset: 0x000004F9
		public CacheableTick(TType t, Func<int> now, int updateInterval, Func<TType> update, int lastUpdateTime = 0)
			: base(t, now, updateInterval, update, lastUpdateTime)
		{
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002308 File Offset: 0x00000508
		public static implicit operator TType(CacheableTick<TType> cache)
		{
			int num;
			if (!cache.ShouldUpdate(out num))
			{
				return cache._backingField;
			}
			cache.LastUpdateTime = num;
			return cache._backingField = ((cache.Update == null) ? cache._backingField : cache.Update());
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002351 File Offset: 0x00000551
		public override bool ShouldUpdate(out int now)
		{
			now = base.Now();
			return base.LastUpdateTime + base.UpdateInterval <= now && this.Validate();
		}
	}
}
