using System;
using System.Collections.Generic;

namespace RimWorldUtility
{
	// Token: 0x02000018 RID: 24
	public static class IEnumerableUtility
	{
		// Token: 0x06000063 RID: 99 RVA: 0x00002B68 File Offset: 0x00000D68
		public static IList<T> GetList<T>(this IEnumerable<T> items)
		{
			IList<T> list = items as IList<T>;
			if (list == null)
			{
				return new List<T>(items);
			}
			return list;
		}
	}
}
