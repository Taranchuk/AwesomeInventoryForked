using System;
using System.Diagnostics;
using Verse;

namespace RimWorldUtility.Logging
{
	// Token: 0x0200003A RID: 58
	public class DebugLogger
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000FB RID: 251 RVA: 0x000057E8 File Offset: 0x000039E8
		public static DebugLogger Instance { get; } = new DebugLogger();

		// Token: 0x060000FC RID: 252 RVA: 0x000057F0 File Offset: 0x000039F0
		[Conditional("Debug")]
		[Conditional("Benchmark")]
		public virtual void Write(string message, MessageLevel level)
		{
			switch (level)
			{
			case MessageLevel.Message:
				Log.Message(message);
				return;
			case MessageLevel.Warning:
				Log.Warning(message);
				return;
			case MessageLevel.Error:
				Log.Error(message);
				return;
			case MessageLevel.Trace:
				Log.Message(message);
				return;
			case MessageLevel.Detail:
				Log.Message(message);
				return;
			default:
				Log.Message(message);
				return;
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00004540 File Offset: 0x00002740
		[Conditional("Debug")]
		[Conditional("Benchmark")]
		public virtual void Message(string message)
		{
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00004540 File Offset: 0x00002740
		[Conditional("Debug")]
		[Conditional("Benchmark")]
		public virtual void Warning(string message)
		{
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00004540 File Offset: 0x00002740
		[Conditional("Debug")]
		[Conditional("Benchmark")]
		public virtual void Error(string message)
		{
		}
	}
}
