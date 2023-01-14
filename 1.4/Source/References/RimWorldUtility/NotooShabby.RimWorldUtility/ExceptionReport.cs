using System;
using System.Collections.Generic;

namespace RimWorldUtility
{
	// Token: 0x0200000C RID: 12
	public class ExceptionReport
	{
		// Token: 0x0600003A RID: 58 RVA: 0x000024BF File Offset: 0x000006BF
		public ExceptionReport(Exception exception)
		{
			this.Exceptions.Add(exception);
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000024E9 File Offset: 0x000006E9
		public List<Exception> Exceptions { get; } = new List<Exception>();

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600003C RID: 60 RVA: 0x000024F1 File Offset: 0x000006F1
		// (set) Token: 0x0600003D RID: 61 RVA: 0x000024F9 File Offset: 0x000006F9
		public string ExtraString { get; set; } = string.Empty;
	}
}
