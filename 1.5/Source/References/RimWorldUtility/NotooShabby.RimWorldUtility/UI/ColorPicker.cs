using System;
using UnityEngine;
using Verse;

namespace RimWorldUtility.UI
{
	// Token: 0x0200001F RID: 31
	public class ColorPicker : RectBase<ColorPickerModel>
	{
		// Token: 0x06000081 RID: 129 RVA: 0x00003400 File Offset: 0x00001600
		public ColorPicker(Texture2D palletMarker, Action<Color> apply)
		{
			this._pallet = new ColorPallet(palletMarker);
			ColorPicker._applyButtonSize.x = ColorPicker._applyButtonSize.x + 16f;
			ColorPicker._applyButtonSize.y = ColorPicker._applyButtonSize.y + 2f;
			this._apply = apply;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003484 File Offset: 0x00001684
		public override Rect Draw(ColorPickerModel model, Vector2 position)
		{
			Rect rect = new Rect(position + this.Offset, this.Size);
			ColorPalletModel colorPalletModel = model.MakeColorPalletModel();
			this._pallet.Draw(colorPalletModel, rect.position);
			Color color;
			this._rgSlider.Draw(model.MakeColorSliderModel(PrimaryColor.Red, PrimaryColor.Green), rect.position, out color);
			Color color2;
			this._brSlider.Draw(model.MakeColorSliderModel(PrimaryColor.Blue, PrimaryColor.Red), rect.position, out color2);
			Color color3;
			this._gbSlider.Draw(model.MakeColorSliderModel(PrimaryColor.Green, PrimaryColor.Blue), rect.position, out color3);
			Color color4;
			this._hexColorRect.Draw(model.ChosenColor, rect.position, out color4);
			Color color5;
			Rect rect2 = this._rgbTextRect.Draw(new ValueTuple<Color, Vector2>(model.ChosenColor, model.RgbTextFieldSize), rect.position, out color5);
			model.ChosenHue = ((color != ColorSlider.UndefinedHue) ? color : ((color3 != ColorSlider.UndefinedHue) ? color3 : ((color2 != ColorSlider.UndefinedHue) ? color2 : model.ChosenHue)));
			if (model.ChosenColor != colorPalletModel.ChosenColor)
			{
				model.ChosenColor = colorPalletModel.ChosenColor;
			}
			else if (model.ChosenColor != color5)
			{
				model.ChosenColor = color5;
				this.Update(model);
			}
			else if (model.ChosenColor != color4)
			{
				model.ChosenColor = color4;
			}
			if (Widgets.ButtonText(new Rect(new Vector2(rect2.x, rect2.yMax), new Vector2(this.Size.x - rect2.x, 28f)), "Apply", true, true, true))
			{
				this._apply(model.ChosenColor);
			}
			return rect;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000364C File Offset: 0x0000184C
		public override Vector2 Build(ColorPickerModel model)
		{
			this._pallet.Offset = Vector2.zero;
			ColorPalletModel colorPalletModel = model.MakeColorPalletModel();
			Vector2 vector = this._pallet.Build(colorPalletModel);
			model.ChosenHue = colorPalletModel.Hue;
			this._brSlider.Offset = new Vector2(vector.x + 26f, 0f);
			Vector2 vector2 = this._brSlider.Build(model.MakeColorSliderModel(PrimaryColor.Blue, PrimaryColor.Red));
			this._gbSlider.Offset = new Vector2(this._brSlider.Offset.x, this._brSlider.Offset.y + vector2.y);
			vector2 = this._gbSlider.Build(model.MakeColorSliderModel(PrimaryColor.Green, PrimaryColor.Blue));
			this._rgSlider.Offset = new Vector2(this._gbSlider.Offset.x, this._gbSlider.Offset.y + vector2.y);
			vector2 = this._rgSlider.Build(model.MakeColorSliderModel(PrimaryColor.Red, PrimaryColor.Green));
			this._hexColorRect.Offset = this._brSlider.Offset + new Vector2(vector2.x + 26f, 0f);
			Vector2 vector3 = this._hexColorRect.Build(model.ChosenColor);
			this._rgbTextRect.Offset = this._hexColorRect.Offset + new Vector2(0f, vector3.y + 17f);
			vector3 = this._rgbTextRect.Build(new ValueTuple<Color, Vector2>(model.ChosenColor, model.RgbTextFieldSize));
			return this.Size = model.Size;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000037F8 File Offset: 0x000019F8
		public override void Update(ColorPickerModel model)
		{
			if (model.Size != this.Size)
			{
				this.Build(model);
				this.Size = model.Size;
			}
			ColorPalletModel colorPalletModel = model.MakeColorPalletModel();
			this._pallet.Update(colorPalletModel);
			model.ChosenColor = colorPalletModel.ChosenColor;
			model.ChosenHue = colorPalletModel.Hue;
			this._rgSlider.Update(model.MakeColorSliderModel(PrimaryColor.Red, PrimaryColor.Green));
			this._gbSlider.Update(model.MakeColorSliderModel(PrimaryColor.Green, PrimaryColor.Blue));
			this._brSlider.Update(model.MakeColorSliderModel(PrimaryColor.Blue, PrimaryColor.Red));
			this._hexColorRect.Update(model.ChosenColor);
		}

		// Token: 0x0400002D RID: 45
		private readonly ColorPallet _pallet;

		// Token: 0x0400002E RID: 46
		private readonly ColorSlider _rgSlider = new ColorSlider();

		// Token: 0x0400002F RID: 47
		private readonly ColorSlider _gbSlider = new ColorSlider();

		// Token: 0x04000030 RID: 48
		private readonly ColorSlider _brSlider = new ColorSlider();

		// Token: 0x04000031 RID: 49
		private readonly RGBTextRect _rgbTextRect = new RGBTextRect();

		// Token: 0x04000032 RID: 50
		private readonly HexColorRect _hexColorRect = new HexColorRect();

		// Token: 0x04000033 RID: 51
		private static Vector2 _applyButtonSize = Text.CalcSize("Apply");

		// Token: 0x04000034 RID: 52
		private Action<Color> _apply;
	}
}
