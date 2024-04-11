using System.Text.RegularExpressions;
using UnityEngine;
using Verse;

namespace RimWorldUtility.UI
{
	// Token: 0x02000023 RID: 35
	public class HexColorRect : RectBase<Color>
	{
		// Token: 0x060000AB RID: 171 RVA: 0x0000412D File Offset: 0x0000232D
		public Rect Draw(Color model, Vector2 position, out Color result)
		{
			Rect rect = Draw(model, position);
			result = HexColorRect.HexToColor(_cache);
			return rect;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00004148 File Offset: 0x00002348
		public override Rect Draw(Color model, Vector2 position)
		{
			Rect rect = new(position + Offset, Size);
			Text.Anchor = TextAnchor.MiddleLeft;
			Widgets.Label(rect, "Hex: ");
			Text.Anchor = TextAnchor.UpperLeft;
			_buffer = Widgets.TextField(new Rect(rect.x + HexColorRect._labelWidth, rect.y, rect.width - HexColorRect._labelWidth, rect.height), _buffer);
			if (HexColorRect._pattern.IsMatch(_buffer))
			{
				_cache = _buffer;
			}
			return rect;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000041E4 File Offset: 0x000023E4
		public override Vector2 Build(Color model)
		{
			_color = model;
			_buffer = _cache = HexColorRect.ColorToHex(model);
			return Size = new Vector2(HexColorRect._width + HexColorRect._labelWidth, 28f);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000422C File Offset: 0x0000242C
		public override void Update(Color model)
		{
			if (model == _color)
			{
				return;
			}
			_buffer = _cache = HexColorRect.ColorToHex(model);
			_color = model;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00004264 File Offset: 0x00002464
		private static string ColorToHex(Color color)
		{
			return "#" + UnityEngine.ColorUtility.ToHtmlStringRGBA(color);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00004278 File Offset: 0x00002478
		private static Color HexToColor(string hex)
		{
			UnityEngine.ColorUtility.TryParseHtmlString(hex, out Color color);
			return color;
		}

		// Token: 0x04000045 RID: 69
		private const string _label = "Hex: ";

		// Token: 0x04000046 RID: 70
		private static readonly float _labelWidth = Text.CalcSize("Hex: ").x;

		// Token: 0x04000047 RID: 71
		private static readonly Regex _pattern = new("\\b#?([A-Z0-9]{8}|[A-Z0-9]{6})\\b");

		// Token: 0x04000048 RID: 72
		private static readonly float _width = Text.CalcSize("#1234567890").x;

		// Token: 0x04000049 RID: 73
		private string _cache;

		// Token: 0x0400004A RID: 74
		private string _buffer;

		// Token: 0x0400004B RID: 75
		private Color _color;
	}
}
