using System;
using UnityEngine;

namespace RimWorldUtility.UI
{
	// Token: 0x0200001E RID: 30
	public class ColorPalletModel
	{
		// Token: 0x0600007A RID: 122 RVA: 0x0000339F File Offset: 0x0000159F
		public ColorPalletModel(Color hue, Color chosenColor, Vector2 size)
		{
			this.Hue = hue;
			this.ChosenColor = chosenColor;
			this.Size = size;
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600007B RID: 123 RVA: 0x000033BC File Offset: 0x000015BC
		// (set) Token: 0x0600007C RID: 124 RVA: 0x000033C4 File Offset: 0x000015C4
		public Color ChosenColor { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600007D RID: 125 RVA: 0x000033CD File Offset: 0x000015CD
		// (set) Token: 0x0600007E RID: 126 RVA: 0x000033D5 File Offset: 0x000015D5
		public Color Hue
		{
			get
			{
				return this._hue;
			}
			set
			{
				this._hue = value;
				this.Complementary = Color.white - value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600007F RID: 127 RVA: 0x000033EF File Offset: 0x000015EF
		// (set) Token: 0x06000080 RID: 128 RVA: 0x000033F7 File Offset: 0x000015F7
		public Color Complementary { get; private set; }

		// Token: 0x04000029 RID: 41
		private Color _hue;

		// Token: 0x0400002C RID: 44
		public Vector2 Size;
	}
}
