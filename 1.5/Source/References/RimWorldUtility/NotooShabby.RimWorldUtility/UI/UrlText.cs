using System;
using UnityEngine;
using Verse;

namespace RimWorldUtility.UI
{
	// Token: 0x02000035 RID: 53
	public class UrlText : UrlObject
	{
		// Token: 0x060000ED RID: 237 RVA: 0x000055DC File Offset: 0x000037DC
		public UrlText(string text, string url)
		{
			this.Text = text;
			this.Url = url;
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000EE RID: 238 RVA: 0x000055F2 File Offset: 0x000037F2
		// (set) Token: 0x060000EF RID: 239 RVA: 0x000055FA File Offset: 0x000037FA
		public string Text { get; set; }

		// Token: 0x060000F0 RID: 240 RVA: 0x00005603 File Offset: 0x00003803
		public override Rect Draw(Rect rect)
		{
			UrlText.DrawUrl(rect, this.Text, this.Url);
			return rect;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00005618 File Offset: 0x00003818
		public static void DrawUrl(Rect labelRect, string text, string url)
		{
			Widgets.Label(labelRect, text.Colorize(ColorLibrary.SkyBlue));
			if (Mouse.IsOver(labelRect))
			{
				Vector2 vector = Verse.Text.CalcSize(text);
				Widgets.DrawLine(new Vector2(labelRect.x, labelRect.y + vector.y), new Vector2(labelRect.x + vector.x, labelRect.y + vector.y), ColorLibrary.SkyBlue, 1f);
			}
			if (Widgets.ButtonInvisible(labelRect, true))
			{
				Application.OpenURL(url);
			}
		}
	}
}
