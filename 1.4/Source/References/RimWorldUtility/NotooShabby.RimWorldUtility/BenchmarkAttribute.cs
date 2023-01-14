using System;
using RimWorldUtility.Logging;

namespace RimWorldUtility
{
	// Token: 0x02000002 RID: 2
	public abstract class BenchmarkAttribute : Attribute
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1
		public abstract Type BenchMarkType { get; }

		// Token: 0x06000002 RID: 2 RVA: 0x00002050 File Offset: 0x00000250
		public virtual Benchmark MakeBenchmark(DebugLogger logger)
		{
			Type benchMarkType = this.BenchMarkType;
			object[] array = new DebugLogger[] { logger };
			return (Benchmark)Activator.CreateInstance(benchMarkType, array);
		}
	}
}
