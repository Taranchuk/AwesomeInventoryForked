using System;
using UnityEngine;

namespace RimWorldUtility.UI
{
	// Token: 0x02000032 RID: 50
	public abstract class RectBase<T>
	{
		// Token: 0x060000E4 RID: 228
		public abstract Rect Draw(T model, Vector2 position);

		// Token: 0x060000E5 RID: 229
		public abstract Vector2 Build(T model);

		// Token: 0x060000E6 RID: 230
		public abstract void Update(T model);

		// Token: 0x040000B8 RID: 184
		public Vector2 Size = Vector2.zero;

		// Token: 0x040000B9 RID: 185
		public Vector2 Offset = Vector2.zero;

		// Token: 0x040000BA RID: 186
		public bool NeedBuild = true;
	}
}
