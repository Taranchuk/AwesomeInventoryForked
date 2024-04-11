using System;
using System.Reflection;

namespace RimWorldUtility.Logging
{
	// Token: 0x02000039 RID: 57
	public interface IBenchmark
	{
		// Token: 0x060000F9 RID: 249
		void Start(MethodBase methodBase);

		// Token: 0x060000FA RID: 250
		void End(MethodBase methodBase);
	}
}
