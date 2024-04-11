using System;
using UnityEngine;
using Verse;

namespace RimWorldUtility.UI
{
	// Token: 0x0200002E RID: 46
	public class TextSearchRect : RectBase<ValueTuple<string, float>>
	{
		// Token: 0x060000D5 RID: 213 RVA: 0x00005260 File Offset: 0x00003460
		public Rect Draw(ValueTuple<string, float> model, Vector2 position, out ValueTuple<string, float> result)
		{
			Rect rect = new(position + Offset, Size);
			model.Item1 = Widgets.TextField(rect, model.Item1);
			Rect rect2 = new Rect(rect.xMax - 28f, rect.y, 24f, 24f).ContractedBy(4f).CenteredOnYIn(rect);
			bool flag = Mouse.IsOver(rect2);
			GUI.color = flag ? GenUI.MouseoverColor : Color.white;
			GUI.DrawTexture(rect2, TexButton.CloseXSmall);
			GUI.color = Color.white;
			if (flag && Input.GetMouseButtonUp(0))
			{
				model.Item1 = string.Empty;
			}
			result = model;
			return rect;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000531A File Offset: 0x0000351A
		public override Rect Draw(ValueTuple<string, float> model, Vector2 position)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00005324 File Offset: 0x00003524
		public override Vector2 Build(ValueTuple<string, float> model)
		{
			return Size = new Vector2(model.Item2, 28f);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00004540 File Offset: 0x00002740
		public override void Update(ValueTuple<string, float> valueTuple)
		{
		}
	}
}
