using System;

namespace RimWorldUtility
{
	// Token: 0x02000014 RID: 20
	public interface IValueNotifier<T> : IValueNotify<T>, INotifier<IValueNotify<T>> where T : struct
	{
	}
}
