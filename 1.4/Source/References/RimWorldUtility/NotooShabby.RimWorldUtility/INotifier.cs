using System;

namespace RimWorldUtility
{
	// Token: 0x02000013 RID: 19
	public interface INotifier<in T>
	{
		// Token: 0x06000058 RID: 88
		void Register(T receiver);

		// Token: 0x06000059 RID: 89
		void Unregister(T receiver);
	}
}
