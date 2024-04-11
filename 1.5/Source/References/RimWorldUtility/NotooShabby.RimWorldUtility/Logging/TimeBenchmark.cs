using System;
using System.Diagnostics;
using System.Reflection;

namespace RimWorldUtility.Logging
{
	// Token: 0x0200003C RID: 60
	public class TimeBenchmark : Benchmark
	{
		// Token: 0x06000102 RID: 258 RVA: 0x00005854 File Offset: 0x00003A54
		public TimeBenchmark(DebugLogger logger)
			: base(logger)
		{
			this._stopwatch.Start();
			this._stopwatch.Stop();
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000587E File Offset: 0x00003A7E
		public override void End(MethodBase methodBase)
		{
			this._stopwatch.Stop();
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000588B File Offset: 0x00003A8B
		public override void Start(MethodBase methodBase)
		{
			this._stopwatch.Restart();
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00005898 File Offset: 0x00003A98
		public static string BuildReportString(MethodBase methodBase, Stopwatch stopwatch)
		{
			return string.Format("[{0}] {1} -- Elapsed Time: {2}ms", DateTime.UtcNow, methodBase.Name, stopwatch.Elapsed.TotalMilliseconds);
		}

		// Token: 0x040000C8 RID: 200
		private Stopwatch _stopwatch = new Stopwatch();
	}
}
