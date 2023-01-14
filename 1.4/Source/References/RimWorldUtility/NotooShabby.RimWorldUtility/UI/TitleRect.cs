using System;
using UnityEngine;
using Verse;

namespace RimWorldUtility.UI
{
	// Token: 0x0200002F RID: 47
	public class TitleRect : RectBase<ValueTuple<string, float>>
	{
		// Token: 0x060000DA RID: 218 RVA: 0x00005352 File Offset: 0x00003552
		public TitleRect(GameFont gameFont)
		{
			this._gameFont = gameFont;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00005364 File Offset: 0x00003564
		public override Rect Draw(ValueTuple<string, float> valueTuple, Vector2 position)
		{
			Rect rect = new Rect(position + this.Offset, this.Size);
			GameFont font = Text.Font;
			Color color = GUI.color;
			Text.Font = this._gameFont;
			GUI.color = Color.grey;
			Widgets.Label(rect, valueTuple.Item1);
			Widgets.DrawLineHorizontal(rect.x, rect.yMax, valueTuple.Item2);
			Text.Font = font;
			GUI.color = color;
			return rect;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000053DC File Offset: 0x000035DC
		public override Vector2 Build(ValueTuple<string, float> valueTuple)
		{
			if (!this.NeedBuild)
			{
				return this.Size;
			}
			GameFont font = Text.Font;
			Text.Font = this._gameFont;
			Text.WordWrap = false;
			float num = Mathf.Max(Text.CalcSize(valueTuple.Item1).x, valueTuple.Item2);
			Text.Font = font;
			Text.WordWrap = true;
			this._lastModel = valueTuple.Item1;
			this.NeedBuild = false;
			return this.Size = new Vector2(num, 28f);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000545C File Offset: 0x0000365C
		public override void Update(ValueTuple<string, float> valueTuple)
		{
			if (valueTuple.Item1 != this._lastModel)
			{
				this.NeedBuild = true;
			}
		}

		// Token: 0x040000B3 RID: 179
		private readonly GameFont _gameFont;

		// Token: 0x040000B4 RID: 180
		private string _lastModel;
	}
}
