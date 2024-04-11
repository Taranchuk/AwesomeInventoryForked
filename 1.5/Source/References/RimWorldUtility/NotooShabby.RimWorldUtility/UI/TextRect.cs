using System;
using UnityEngine;
using Verse;

namespace RimWorldUtility.UI
{
	// Token: 0x0200002D RID: 45
	public class TextRect : RectBase<string>
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000CF RID: 207 RVA: 0x000051FC File Offset: 0x000033FC
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00005204 File Offset: 0x00003404
		public string Text { get; protected set; }

		// Token: 0x060000D1 RID: 209 RVA: 0x0000520D File Offset: 0x0000340D
		public override Rect Draw(string model, Vector2 position)
		{
			Rect rect = new Rect(position + this.Offset, this.Size);
			Widgets.Label(rect, model);
			return rect;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00005230 File Offset: 0x00003430
		public override Vector2 Build(string model)
		{
			return this.Size = Verse.Text.CalcSize(model);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000524C File Offset: 0x0000344C
		public override void Update(string model)
		{
			this.Build(model);
		}
	}
}
