using System;
using System.Collections.Generic;

namespace RimWorldUtility
{
	// Token: 0x02000010 RID: 16
	public class ListNotifier<T> : CollectionNotifier<T, List<T>>
	{
		// Token: 0x06000054 RID: 84 RVA: 0x000026F4 File Offset: 0x000008F4
		public void AddRange(IEnumerable<T> data)
		{
			ValidateArg.NotNull(data, "data");
			data = data.GetList<T>();
			base.Data.AddRange(data);
			foreach (T t in data)
			{
				foreach (ICollectionNotify<T> collectionNotify in base.Receivers)
				{
					collectionNotify.Add(t);
				}
			}
		}
	}
}
