using System;
using Verse;

namespace RimWorldUtility
{
	// Token: 0x0200000D RID: 13
	public class FeatureNews : IExposable
	{
		// Token: 0x0600003E RID: 62 RVA: 0x0000211E File Offset: 0x0000031E
		public FeatureNews()
		{
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002502 File Offset: 0x00000702
		public FeatureNews(string label, string description, string url, string urlText, DateTime releaseDate)
		{
			this.Label = label;
			this.Description = description;
			this.Url = url;
			this.UrlText = urlText;
			this.ReleaseDate = releaseDate;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000040 RID: 64 RVA: 0x0000252F File Offset: 0x0000072F
		// (set) Token: 0x06000041 RID: 65 RVA: 0x00002537 File Offset: 0x00000737
		public string Label { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002540 File Offset: 0x00000740
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00002548 File Offset: 0x00000748
		public DateTime ReleaseDate { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002551 File Offset: 0x00000751
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00002559 File Offset: 0x00000759
		public string Description { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00002562 File Offset: 0x00000762
		// (set) Token: 0x06000047 RID: 71 RVA: 0x0000256A File Offset: 0x0000076A
		public string Url { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002573 File Offset: 0x00000773
		// (set) Token: 0x06000049 RID: 73 RVA: 0x0000257B File Offset: 0x0000077B
		public string UrlText { get; set; }

		// Token: 0x0600004A RID: 74 RVA: 0x00002584 File Offset: 0x00000784
		public void ExposeData()
		{
			Scribe_Values.Look<bool>(ref this.Received, "Received", false, false);
		}

		// Token: 0x04000011 RID: 17
		public bool Received;
	}
}
