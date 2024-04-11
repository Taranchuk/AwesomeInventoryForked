using System;
using System.Globalization;
using UnityEngine;
using Verse;

namespace RimWorldUtility.UI
{
	// Token: 0x0200002C RID: 44
	public class NumberFieldRect : RectBase<ValueTuple<float, Vector2>>
	{
		// Token: 0x060000CA RID: 202 RVA: 0x0000514A File Offset: 0x0000334A
		public NumberFieldRect(string label, float min, float max)
		{
			_label = label;
			_min = min;
			_max = max;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00005167 File Offset: 0x00003367
		public Rect Draw(ValueTuple<float, Vector2> model, Vector2 position, out float result)
		{
			Rect rect = Draw(model, position);
			result = _result;
			return rect;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000517C File Offset: 0x0000337C
		public override Rect Draw(ValueTuple<float, Vector2> model, Vector2 position)
		{
			Rect rect = new(position + Offset, Size);
			string text = model.Item1.ToString(CultureInfo.InvariantCulture);
			Widgets.TextFieldNumericLabeled<float>(rect, _label, ref model.Item1, ref text, _min, _max);
			_result = model.Item1;
			return rect;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000051E0 File Offset: 0x000033E0
		public override Vector2 Build(ValueTuple<float, Vector2> model)
		{
			return Size = model.Item2;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00004540 File Offset: 0x00002740
		public override void Update(ValueTuple<float, Vector2> model)
		{
		}

		// Token: 0x040000AE RID: 174
		private float _result;

		// Token: 0x040000AF RID: 175
		private readonly string _label;

		// Token: 0x040000B0 RID: 176
		private readonly float _min;

		// Token: 0x040000B1 RID: 177
		private readonly float _max;
	}
}
