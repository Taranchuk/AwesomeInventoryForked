using System;
using UnityEngine;
using Verse;

namespace RimWorldUtility.UI
{
	// Token: 0x02000030 RID: 48
	public class Dialog_Feature : Window
	{
		// Token: 0x060000DE RID: 222 RVA: 0x00005478 File Offset: 0x00003678
		public Dialog_Feature(FeatureNews news)
		{
			this.doCloseX = true;
			this.closeOnClickedOutside = true;
			this._news = news;
			this._urlText = new UrlText(news.UrlText, news.Url);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000054AC File Offset: 0x000036AC
		public override void DoWindowContents(Rect inRect)
		{
			Listing_Standard listing_Standard = new Listing_Standard();
			listing_Standard.ColumnWidth = inRect.width;
			listing_Standard.Begin(inRect);
			listing_Standard.Label(this._news.Description, -1f, null);
			listing_Standard.Gap(12f);
			this._urlText.Draw(listing_Standard.GetRect(28f));
			listing_Standard.End();
		}

		// Token: 0x040000B5 RID: 181
		private FeatureNews _news;

		// Token: 0x040000B6 RID: 182
		private UrlText _urlText;
	}
}
