using System;
using System.Globalization;
using UnityEngine;
using Verse;

namespace RimWorldUtility
{
	// Token: 0x02000017 RID: 23
	public class Draw
	{
		// Token: 0x06000060 RID: 96 RVA: 0x00002AD8 File Offset: 0x00000CD8
		public static void IntegerSetting(string label, Rect rect, ref int value, Action<int> action = null, string tooltip = null)
		{
			Rect rect2 = rect.ReplaceHeight(rect.height / 2f);
			Text.Anchor = TextAnchor.MiddleCenter;
			Widgets.Label(rect2, label);
			Text.Anchor = TextAnchor.UpperLeft;
			if (!tooltip.NullOrEmpty())
			{
				Widgets.DrawHighlightIfMouseover(rect2);
				TooltipHandler.TipRegion(rect2, tooltip);
			}
			string text = value.ToString(CultureInfo.InvariantCulture);
			int num = value;
			Widgets.IntEntry(rect2.ReplaceY(rect2.yMax), ref value, ref text, 1);
			if (num != value && action != null)
			{
				action(value);
			}
		}

		// Token: 0x04000018 RID: 24
		public static Draw That = new Draw();
	}
}
