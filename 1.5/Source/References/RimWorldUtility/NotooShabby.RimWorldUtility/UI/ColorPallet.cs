using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace RimWorldUtility.UI
{
	// Token: 0x0200001D RID: 29
	public class ColorPallet : RectBase<ColorPalletModel>
	{
		// Token: 0x06000072 RID: 114 RVA: 0x00002D50 File Offset: 0x00000F50
		public ColorPallet(Texture2D marker)
		{
			_marker = marker;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00002D74 File Offset: 0x00000F74
		public override Rect Draw(ColorPalletModel model, Vector2 position)
		{
			Rect rect = new(Offset + position, new Vector2(Size.x, Size.y / 2f));
			GUI.DrawTexture(rect, _palletTex);
			GUI.DrawTexture(new Rect(_chosenColorOffset + rect.position - (_markerSize / 2f), _markerSize), _marker);
			if (Mouse.IsOver(rect) && Event.current.button == 0 && Event.current.isMouse)
			{
				Vector2 vector = Event.current.mousePosition - rect.position;
				Color colorFromOffset = GetColorFromOffset(rect, vector, model);
				_previewTex = SolidColorMaterials.NewSolidColorTexture(colorFromOffset);
				_chosenColor = model.ChosenColor = colorFromOffset;
				_chosenColorOffset = vector;
				Event.current.Use();
			}
			Rect rect2 = new(rect.x, rect.yMax, rect.width, rect.height);
			GUI.DrawTexture(rect2, BaseContent.BlackTex);
			GUI.DrawTexture(rect2, _previewTex);
			return rect;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002EA4 File Offset: 0x000010A4
		public override Vector2 Build(ColorPalletModel model)
		{
			if (!_init)
			{
				Size = model.Size;
				_chosenColor = model.ChosenColor;
				_hue = model.Hue;
				UpdateHueAndOffset(_chosenColor);
				model.Hue = _hue;
				_init = true;
			}
			BuildPallet(model);
			return Size;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002F0C File Offset: 0x0000110C
		public override void Update(ColorPalletModel model)
		{
			if (model.Size != Size)
			{
				Size = model.Size;
				BuildPallet(model);
				return;
			}
			if (model.Hue != _hue)
			{
				_hue = model.Hue;
				_chosenColor = model.ChosenColor = GetColorFromOffset(new Rect(Vector2.zero, model.Size), _chosenColorOffset, model);
				BuildPallet(model);
				return;
			}
			if (!model.ChosenColor.SameAs(_chosenColor, out bool flag))
			{
				_chosenColor = model.ChosenColor;
				if (flag)
				{
					_previewTex = SolidColorMaterials.NewSolidColorTexture(model.ChosenColor);
					return;
				}
				UpdateHueAndOffset(_chosenColor);
				model.Hue = _hue;
				BuildPallet(model);
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002FE8 File Offset: 0x000011E8
		private void BuildPallet(ColorPalletModel model)
		{
			_palletTex = new Texture2D(Mathf.RoundToInt(model.Size.x), Mathf.RoundToInt(model.Size.y / 2f));
			for (int i = 0; i < _palletTex.width; i++)
			{
				float num = i / (float)_palletTex.width;
				for (int j = 0; j < _palletTex.height; j++)
				{
					Color color = j / (float)_palletTex.height * (Color.white - (model.Complementary * num));
					color = color.Sanitize();
					color.a = 1f;
					_palletTex.SetPixel(i, j, color);
				}
			}
			_palletTex.Apply();
			_previewTex = SolidColorMaterials.NewSolidColorTexture(model.ChosenColor);
			List<ValueTuple<PrimaryColor, float>> list = model.Hue.OrderbyHue();
			_huePrimaryColor = list[0].Item1;
			_hueSecondaryColor = list[1].Item1;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003104 File Offset: 0x00001304
		private Color GetColorFromOffset(Rect container, Vector2 offset, ColorPalletModel model)
		{
			float num = 1f - (offset.y / container.size.y);
			Color color = (num * Color.white) - (offset.x / container.size.x * model.Complementary * num);
			color = color.Sanitize();
			color.a = 1f;
			return color;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003174 File Offset: 0x00001374
		private void UpdateHueAndOffset(Color selectedColor)
		{
			List<ValueTuple<PrimaryColor, float>> list = selectedColor.OrderbyHue();
			if (list[0].Item2 < 0.0039f)
			{
				_chosenColorOffset = new Vector2(0f, Size.y / 2f);
			}
			else
			{
				_chosenColorOffset.x = (1f - (list[2].Item2 / list[0].Item2)) * Size.x;
				_chosenColorOffset.y = (1f - list[0].Item2) * Size.y / 2f;
			}
			if (_hue.HueContains(selectedColor, _huePrimaryColor, _hueSecondaryColor))
			{
				return;
			}
			AdjustHue(list);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003248 File Offset: 0x00001448
		private void AdjustHue(List<(PrimaryColor PrimaryColor, float Value)> primaryColors)
		{
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			PrimaryColor item = primaryColors[0].PrimaryColor;
			PrimaryColor item2 = primaryColors[1].PrimaryColor;
			float num = (!(primaryColors[0].Value - primaryColors[2].Value < 0.0039f)) ? ((primaryColors[1].Value - primaryColors[2].Value) / (primaryColors[0].Value - primaryColors[2].Value)) : 0f;
			switch (item)
			{
				case PrimaryColor.Red:
					switch (item2)
					{
						case PrimaryColor.Green:
							_hue = new Color(1f, num, 0f);
							return;
						case PrimaryColor.Blue:
							_hue = new Color(1f, 0f, num);
							return;
					}
					break;
				case PrimaryColor.Green:
					switch (item2)
					{
						case PrimaryColor.Red:
							_hue = new Color(num, 1f, 0f);
							return;
						case PrimaryColor.Blue:
							_hue = new Color(0f, 1f, num);
							return;
					}
					break;
				case PrimaryColor.Blue:
					switch (item2)
					{
						case PrimaryColor.Red:
							_hue = new Color(num, 0f, 1f);
							return;
						case PrimaryColor.Green:
							_hue = new Color(0f, num, 1f);
							return;
					}
					break;
			}
			_hue = new Color(1f, 1f, 0f);
		}

		// Token: 0x0400001F RID: 31
		private readonly Texture2D _marker;

		// Token: 0x04000020 RID: 32
		private readonly Vector2 _markerSize = new(20f, 20f);

		// Token: 0x04000021 RID: 33
		private Texture2D _palletTex;

		// Token: 0x04000022 RID: 34
		private Color _chosenColor;

		// Token: 0x04000023 RID: 35
		private Vector2 _chosenColorOffset;

		// Token: 0x04000024 RID: 36
		private Texture2D _previewTex;

		// Token: 0x04000025 RID: 37
		private Color _hue;

		// Token: 0x04000026 RID: 38
		private PrimaryColor _huePrimaryColor;

		// Token: 0x04000027 RID: 39
		private PrimaryColor _hueSecondaryColor;

		// Token: 0x04000028 RID: 40
		private bool _init;
	}
}
