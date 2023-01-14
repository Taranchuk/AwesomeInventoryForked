using System;
using UnityEngine;

namespace RimWorldUtility.UI
{
	// Token: 0x02000020 RID: 32
	public class ColorPickerModel
	{
		// Token: 0x06000086 RID: 134 RVA: 0x000038B2 File Offset: 0x00001AB2
		public ColorPickerModel(Color chosenColor)
		{
			this.ChosenColor = chosenColor;
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000087 RID: 135 RVA: 0x000038C1 File Offset: 0x00001AC1
		// (set) Token: 0x06000088 RID: 136 RVA: 0x000038C9 File Offset: 0x00001AC9
		public Color ChosenHue { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000089 RID: 137 RVA: 0x000038D2 File Offset: 0x00001AD2
		// (set) Token: 0x0600008A RID: 138 RVA: 0x000038DA File Offset: 0x00001ADA
		public Color ChosenColor { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600008B RID: 139 RVA: 0x000038E3 File Offset: 0x00001AE3
		// (set) Token: 0x0600008C RID: 140 RVA: 0x000038EB File Offset: 0x00001AEB
		public Vector2 Size { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600008D RID: 141 RVA: 0x000038F4 File Offset: 0x00001AF4
		// (set) Token: 0x0600008E RID: 142 RVA: 0x000038FC File Offset: 0x00001AFC
		public Vector2 PalletSize { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00003905 File Offset: 0x00001B05
		// (set) Token: 0x06000090 RID: 144 RVA: 0x0000390D File Offset: 0x00001B0D
		public Vector2 SliderSize { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00003916 File Offset: 0x00001B16
		// (set) Token: 0x06000092 RID: 146 RVA: 0x0000391E File Offset: 0x00001B1E
		public Vector2 RgbTextFieldSize { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00003927 File Offset: 0x00001B27
		// (set) Token: 0x06000094 RID: 148 RVA: 0x0000392F File Offset: 0x00001B2F
		public bool Apply { get; set; }

		// Token: 0x06000095 RID: 149 RVA: 0x00003938 File Offset: 0x00001B38
		public ColorPalletModel MakeColorPalletModel()
		{
			return new ColorPalletModel(this.ChosenHue, this.ChosenColor, this.PalletSize);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003954 File Offset: 0x00001B54
		public ColorSliderModel MakeColorSliderModel(PrimaryColor color1, PrimaryColor color2)
		{
			switch (color1)
			{
			case PrimaryColor.Red:
				if (color2 == PrimaryColor.Green)
				{
					return new ColorSliderModel(new Color(1f, 0.999f, 0f), this.SliderSize, this.ChosenHue);
				}
				if (color2 == PrimaryColor.Blue)
				{
					return new ColorSliderModel(new Color(1f, 0f, 0.999f), this.SliderSize, this.ChosenHue);
				}
				break;
			case PrimaryColor.Green:
				if (color2 == PrimaryColor.Red)
				{
					return new ColorSliderModel(new Color(0.999f, 1f, 0f), this.SliderSize, this.ChosenHue);
				}
				if (color2 == PrimaryColor.Blue)
				{
					return new ColorSliderModel(new Color(0f, 1f, 0.999f), this.SliderSize, this.ChosenHue);
				}
				break;
			case PrimaryColor.Blue:
				if (color2 == PrimaryColor.Red)
				{
					return new ColorSliderModel(new Color(0.999f, 0f, 1f), this.SliderSize, this.ChosenHue);
				}
				if (color2 == PrimaryColor.Green)
				{
					return new ColorSliderModel(new Color(0f, 0.999f, 1f), this.SliderSize, this.ChosenHue);
				}
				break;
			}
			return new ColorSliderModel(new Color(1f, 0.999f, 0f), this.SliderSize, this.ChosenHue);
		}
	}
}
