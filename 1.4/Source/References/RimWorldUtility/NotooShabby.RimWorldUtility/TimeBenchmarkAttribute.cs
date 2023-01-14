using System;
using RimWorldUtility.Logging;

namespace RimWorldUtility
{
	// Token: 0x02000004 RID: 4
	public class TimeBenchmarkAttribute : BenchmarkAttribute
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020E8 File Offset: 0x000002E8
		public override Type BenchMarkType
		{
			get
			{
				return typeof(TimeBenchmark);
			}
		}
	}
}
