using System;

namespace RimWorldUtility
{
	// Token: 0x02000006 RID: 6
	public abstract class CacheableBase
	{
		// Token: 0x0600000A RID: 10
		public abstract bool Validate();

		// Token: 0x0600000B RID: 11
		public abstract void TriggerUpdate();
	}
}
