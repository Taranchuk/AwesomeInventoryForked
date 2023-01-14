using System;

namespace RimWorldUtility
{
	// Token: 0x02000012 RID: 18
	public interface ICollectionNotify<in T>
	{
		// Token: 0x06000056 RID: 86
		void Add(T data);

		// Token: 0x06000057 RID: 87
		void Remove(T data);
	}
}
