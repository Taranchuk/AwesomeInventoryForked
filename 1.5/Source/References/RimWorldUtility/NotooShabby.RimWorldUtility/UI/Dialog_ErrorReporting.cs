using UnityEngine;
using Verse;

namespace RimWorldUtility.UI
{
	// Token: 0x02000026 RID: 38
	public class Dialog_ErrorReporting : Window
	{
		// Token: 0x060000B8 RID: 184 RVA: 0x000045C0 File Offset: 0x000027C0
		public Dialog_ErrorReporting(string errorMsg, string title, string url)
		{
			_errorMsg = errorMsg;
			_title = title;
			_bugReportUrl = url;
			closeOnClickedOutside = true;
			doCloseX = true;
			absorbInputAroundWindow = true;
			forcePause = true;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000463C File Offset: 0x0000283C
		public override void DoWindowContents(Rect inRect)
		{
			if (!_built)
			{
				_textHeight = Text.CalcHeight(_errorMsg, inRect.width);
				_built = true;
			}
			Listing_Standard listing_Standard = new()
			{
				ColumnWidth = inRect.width - 26f
			};
			listing_Standard.Begin(inRect);
			Text.Anchor = TextAnchor.MiddleCenter;
			listing_Standard.Label(_title, -1f, null);
			Text.Anchor = TextAnchor.UpperLeft;
			Rect rect = new(inRect.x, listing_Standard.CurHeight, inRect.width, 280f);
			Widgets.BeginScrollView(rect, ref _scrollPosition, _viewRect);
			listing_Standard.TextEntry(_errorMsg, Mathf.CeilToInt(_textHeight / Text.LineHeight));
			Widgets.EndScrollView();
			WidgetRow widgetRow = new(rect.xMax, rect.yMax + 17f, UIDirection.LeftThenDown, rect.width, 4f);
			if (widgetRow.ButtonText("Report to author!", null, true, true))
			{
				Application.OpenURL(_bugReportUrl);
			}
			if (widgetRow.ButtonText("Copy", null, true, true))
			{
				GUIUtility.systemCopyBuffer = _errorMsg;
			}
			listing_Standard.End();
		}

		// Token: 0x04000055 RID: 85
		private const int _textAreaLineCount = 10;

		// Token: 0x04000056 RID: 86
		private readonly string _bugReportUrl = "https://steamcommunity.com/workshop/filedetails/discussion/2162016781/4078523564596332172/";

		// Token: 0x04000057 RID: 87
		private readonly string _errorMsg;

		// Token: 0x04000058 RID: 88
		private readonly string _title = "Smart Colonist Bar has encountered an exception, reverting back to vanilla bar.";

		// Token: 0x04000059 RID: 89
		private bool _built;

		// Token: 0x0400005A RID: 90
		private float _textHeight = -1f;

		// Token: 0x0400005B RID: 91
		private Vector2 _scrollPosition = Vector2.zero;

		// Token: 0x0400005C RID: 92
		private Rect _viewRect = Rect.zero;
	}
}
