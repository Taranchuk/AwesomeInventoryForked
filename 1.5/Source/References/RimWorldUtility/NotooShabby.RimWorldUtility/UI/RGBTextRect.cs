using System;
using UnityEngine;

namespace RimWorldUtility.UI
{
	// Token: 0x02000025 RID: 37
	public class RGBTextRect : RectBase<(Color, Vector2)>
	{
		// Token: 0x060000B3 RID: 179 RVA: 0x000042D0 File Offset: 0x000024D0
		public Rect Draw((Color Color, Vector2 Size) model, Vector2 position, out Color resultColor)
		{
			Rect rect = Draw(model, position);
			resultColor = _resultColor;
			return rect;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000042E8 File Offset: 0x000024E8
		public override Rect Draw(ValueTuple<Color, Vector2> model, Vector2 position)
		{
			Color item = model.Item1;
			Vector2 vector = model.Item2 / 4f;
			Rect rect = new(position + Offset, Size);
			_rRect.Draw(new ValueTuple<float, Vector2>(Mathf.RoundToInt(item.r * 255f), vector), rect.position, out float num);
			_gRect.Draw(new ValueTuple<float, Vector2>(Mathf.RoundToInt(item.g * 255f), vector), rect.position, out float num2);
			_bRect.Draw(new ValueTuple<float, Vector2>(Mathf.RoundToInt(item.b * 255f), vector), rect.position, out float num3);
			_aRect.Draw(new ValueTuple<float, Vector2>(Mathf.RoundToInt(item.a * 255f), vector), rect.position, out float num4);
			_resultColor = new Color(num / 255f, num2 / 255f, num3 / 255f, num4 / 255f);
			return rect;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004408 File Offset: 0x00002608
		public override Vector2 Build(ValueTuple<Color, Vector2> model)
		{
			Vector2 vector = model.Item2 / 4f;
			_rRect.Offset = Vector2.zero;
			Vector2 vector2 = _rRect.Build(new ValueTuple<float, Vector2>(model.Item1.r, vector));
			_gRect.Offset = _rRect.Offset + new Vector2(vector2.x, 0f);
			vector2 = _gRect.Build(new ValueTuple<float, Vector2>(model.Item1.g, vector));
			_bRect.Offset = _rRect.Offset + new Vector2(0f, vector2.y + 10f);
			vector2 = _bRect.Build(new ValueTuple<float, Vector2>(model.Item1.b, vector));
			_aRect.Offset = _bRect.Offset + new Vector2(vector2.x, 0f);
			_ = _aRect.Build(new ValueTuple<float, Vector2>(model.Item1.a, vector));
			return Size = model.Item2;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00004540 File Offset: 0x00002740
		public override void Update(ValueTuple<Color, Vector2> model)
		{
		}

		// Token: 0x04000050 RID: 80
		private readonly NumberFieldRect _rRect = new("R: ", 0f, 255f);

		// Token: 0x04000051 RID: 81
		private readonly NumberFieldRect _gRect = new("G: ", 0f, 255f);

		// Token: 0x04000052 RID: 82
		private readonly NumberFieldRect _bRect = new("B: ", 0f, 255f);

		// Token: 0x04000053 RID: 83
		private readonly NumberFieldRect _aRect = new("A: ", 0f, 255f);

		// Token: 0x04000054 RID: 84
		private Color _resultColor;
	}
}
