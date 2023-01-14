using System;
using System.Reflection;

namespace RimWorldUtility.Logging
{
	// Token: 0x02000037 RID: 55
	public abstract class Benchmark : IBenchmark
	{
		// Token: 0x060000F3 RID: 243 RVA: 0x000056B2 File Offset: 0x000038B2
		public Benchmark(DebugLogger logger)
		{
			this._logger = logger;
		}

		// Token: 0x060000F4 RID: 244
		public abstract void End(MethodBase methodBase);

		// Token: 0x060000F5 RID: 245
		public abstract void Start(MethodBase methodBase);

		// Token: 0x040000BE RID: 190
		protected DebugLogger _logger;
	}
}
