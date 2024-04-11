using System;
using System.Collections.Generic;

namespace RimWorldUtility.UI
{
	// Token: 0x0200002A RID: 42
	public abstract class RectCollection<T, TItem, TRect> : RectBase<T> where T : IEnumerable<TItem> where TRect : RectBase<TItem>
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00004C88 File Offset: 0x00002E88
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x00004C90 File Offset: 0x00002E90
		public virtual List<TRect> ChildrenRects { get; protected set; } = new List<TRect>();
	}
}
