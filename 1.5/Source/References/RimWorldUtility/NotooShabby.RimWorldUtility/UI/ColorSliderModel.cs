using System;
using UnityEngine;

namespace RimWorldUtility.UI
{
	// Token: 0x02000022 RID: 34
	public class ColorSliderModel
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x000040B7 File Offset: 0x000022B7
		public ColorSliderModel(Color hue, Vector2 size, Color huePick)
		{
			this.Hue = hue;
			this.Size = size;
			this.HuePick = huePick;
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x000040D4 File Offset: 0x000022D4
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x000040DC File Offset: 0x000022DC
		public Color Hue { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x000040E5 File Offset: 0x000022E5
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x000040ED File Offset: 0x000022ED
		public Vector2 Size { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x000040F6 File Offset: 0x000022F6
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x000040FE File Offset: 0x000022FE
		public Color HuePick { get; set; }

		// Token: 0x060000AA RID: 170 RVA: 0x00004107 File Offset: 0x00002307
		public void Deconstruct(out Color hue, out Vector2 size, out Color huePick)
		{
			hue = this.Hue;
			size = this.Size;
			huePick = this.HuePick;
		}
	}
}
