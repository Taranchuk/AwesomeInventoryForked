using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace RimWorldUtility.UI
{
	// Token: 0x02000021 RID: 33
	public class ColorSlider : RectBase<ColorSliderModel>
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00003A9A File Offset: 0x00001C9A
		// (set) Token: 0x06000098 RID: 152 RVA: 0x00003AA2 File Offset: 0x00001CA2
		public Color ChosenHue { get; set; } = ColorSlider.UndefinedHue;

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00003AAB File Offset: 0x00001CAB
		// (set) Token: 0x0600009A RID: 154 RVA: 0x00003AB3 File Offset: 0x00001CB3
		public float MarkerThickNess { get; set; } = 2f;

		// Token: 0x0600009B RID: 155 RVA: 0x00003ABC File Offset: 0x00001CBC
		public Rect Draw(ColorSliderModel model, Vector2 position, out Color chosenHue)
		{
			Rect rect = this.Draw(model, position);
			chosenHue = this.ChosenHue;
			return rect;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003AD4 File Offset: 0x00001CD4
		public override Rect Draw(ColorSliderModel model, Vector2 position)
		{
			Rect rect = new Rect(position + this.Offset, this.Size);
			GUI.DrawTexture(rect, this._hueTexture);
			Color color;
			Vector2 vector;
			Color color2;
			model.Deconstruct(out color, out vector, out color2);
			Vector2 vector2 = vector;
			Color color3 = color2;
			if (this.HueInRange(this._hue, color3))
			{
				GUI.DrawTexture(new Rect(rect.x, rect.position.y + this._chosenHueOffset.y, rect.width, this.MarkerThickNess), BaseContent.WhiteTex);
			}
			if (Event.current.button == 0 && Event.current.isMouse && Mouse.IsOver(rect))
			{
				List<Color> list = ColorSlider.DeconstructHue(this._hue);
				this._chosenHueOffset = Event.current.mousePosition - rect.position;
				float num = vector2.y / 2f;
				if (this._chosenHueOffset.y < num)
				{
					this.ChosenHue = list[0] * Mathf.Clamp01(this._chosenHueOffset.y / num) + list[1];
				}
				else
				{
					this.ChosenHue = list[0] + list[1] * Mathf.Clamp01(2f - this._chosenHueOffset.y / num);
				}
				Event.current.Use();
				return rect;
			}
			this.ChosenHue = ColorSlider.UndefinedHue;
			return rect;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003C58 File Offset: 0x00001E58
		public override Vector2 Build(ColorSliderModel model)
		{
			Color color;
			Vector2 vector;
			Color color2;
			model.Deconstruct(out color, out vector, out color2);
			Color color3 = color;
			Vector2 vector2 = vector;
			this._hueTexture = new Texture2D(Mathf.RoundToInt(vector2.x), Mathf.RoundToInt(vector2.y));
			List<Color> list = ColorSlider.DeconstructHue(color3);
			int num = this._hueTexture.height / 2;
			for (int i = 0; i < this._hueTexture.width; i++)
			{
				for (int j = 0; j < num; j++)
				{
					this._hueTexture.SetPixel(i, j, list[0] + list[1] * (float)j / (float)num);
				}
				for (int k = num; k < this._hueTexture.height; k++)
				{
					this._hueTexture.SetPixel(i, k, list[0] * (1f - (float)(k - num) / (float)num) + list[1]);
				}
			}
			this._hueTexture.Apply();
			this._hue = color3;
			vector = (this.Size = new Vector2((float)this._hueTexture.width, (float)this._hueTexture.height));
			return vector;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003D97 File Offset: 0x00001F97
		public override void Update(ColorSliderModel model)
		{
			if (this._hue != model.Hue || this.Size != model.Size)
			{
				this.Build(model);
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003DC8 File Offset: 0x00001FC8
		private static List<Color> DeconstructHue(Color hue)
		{
			List<ValueTuple<PrimaryColor, float>> list = hue.OrderbyHue();
			float item = list[0].Item2;
			float item2 = list[1].Item2;
			switch (list[0].Item1)
			{
			case PrimaryColor.Red:
				if (list[1].Item1 == PrimaryColor.Green)
				{
					return new List<Color>
					{
						new Color(item, 0f, 0f),
						new Color(0f, item2, 0f)
					};
				}
				if (list[1].Item1 == PrimaryColor.Blue)
				{
					return new List<Color>
					{
						new Color(item, 0f, 0f),
						new Color(0f, 0f, item2)
					};
				}
				break;
			case PrimaryColor.Green:
				if (list[1].Item1 == PrimaryColor.Red)
				{
					return new List<Color>
					{
						new Color(0f, item, 0f),
						new Color(item2, 0f, 0f)
					};
				}
				if (list[1].Item1 == PrimaryColor.Blue)
				{
					return new List<Color>
					{
						new Color(0f, item, 0f),
						new Color(0f, 0f, item2)
					};
				}
				break;
			case PrimaryColor.Blue:
				if (list[1].Item1 == PrimaryColor.Red)
				{
					return new List<Color>
					{
						new Color(0f, 0f, item),
						new Color(item2, 0f, 0f)
					};
				}
				if (list[1].Item1 == PrimaryColor.Green)
				{
					return new List<Color>
					{
						new Color(0f, 0f, item),
						new Color(0f, item2, 0f)
					};
				}
				break;
			}
			return new List<Color>
			{
				new Color(item, 0f, 0f),
				new Color(0f, item2, 0f)
			};
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003FD8 File Offset: 0x000021D8
		private bool HueInRange(Color range, Color target)
		{
			List<ValueTuple<PrimaryColor, float>> list = range.OrderbyHue();
			List<ValueTuple<PrimaryColor, float>> list2 = target.OrderbyHue();
			if (list[2].Item1 != list2[2].Item1)
			{
				return false;
			}
			float num = (float)this._hueTexture.height / 2f;
			if (list[0].Item1 == list2[0].Item1)
			{
				this._chosenHueOffset.y = (1f - list2[1].Item2) * num + num;
			}
			else
			{
				this._chosenHueOffset.y = list2[1].Item2 * num;
			}
			return true;
		}

		// Token: 0x0400003C RID: 60
		private Texture2D _hueTexture;

		// Token: 0x0400003D RID: 61
		private Color _hue;

		// Token: 0x0400003E RID: 62
		private Vector2 _chosenHueOffset;

		// Token: 0x0400003F RID: 63
		public static readonly Color UndefinedHue = new Color(0f, 0f, 0f, -1f);
	}
}
