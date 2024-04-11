using System;

namespace RimWorldUtility
{
	// Token: 0x02000011 RID: 17
	public interface ICollectionNotifier<T> : ICollectionNotify<T>, INotifier<ICollectionNotify<T>>
	{
	}
}
