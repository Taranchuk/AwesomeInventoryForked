using System;
using System.Collections.Generic;
using UnityEngine;

namespace RimWorldUtility.UI
{
	// Token: 0x02000031 RID: 49
	public abstract class LayeredSquare<T> : RectBase<T>
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00005513 File Offset: 0x00003713
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x0000551B File Offset: 0x0000371B
		public List<RectBase<T>> Layers { get; protected set; } = new List<RectBase<T>>();

		// Token: 0x060000E2 RID: 226 RVA: 0x00005524 File Offset: 0x00003724
		public override Rect Draw(T model, Vector2 position)
		{
			foreach (RectBase<T> rectBase in this.Layers)
			{
				rectBase.Draw(model, position);
			}
			return new Rect(position, this.Size);
		}
	}
}
