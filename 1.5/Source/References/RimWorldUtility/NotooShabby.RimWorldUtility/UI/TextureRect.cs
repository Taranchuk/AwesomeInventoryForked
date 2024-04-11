using System;
using UnityEngine;

namespace RimWorldUtility.UI
{
	// Token: 0x02000033 RID: 51
	public abstract class TextureRect<T> : RectBase<T>
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x000055BC File Offset: 0x000037BC
		protected TextureRect(Texture2D texture2D)
		{
			this.Texture2D = texture2D;
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x000055CB File Offset: 0x000037CB
		// (set) Token: 0x060000EA RID: 234 RVA: 0x000055D3 File Offset: 0x000037D3
		public Texture2D Texture2D { get; set; }
	}
}
