using System;
using UnityEngine;

namespace RimWorldUtility
{
	// Token: 0x02000019 RID: 25
	public static class RectUtility
	{
		// Token: 0x06000064 RID: 100 RVA: 0x00002B89 File Offset: 0x00000D89
		public static Rect ReplaceX(this Rect rect, float x)
		{
			return new Rect(x, rect.y, rect.width, rect.height);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002BA6 File Offset: 0x00000DA6
		public static Rect ReplaceY(this Rect rect, float y)
		{
			return new Rect(rect.x, y, rect.width, rect.height);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00002BC3 File Offset: 0x00000DC3
		public static Rect ReplaceWidth(this Rect rect, float width)
		{
			return new Rect(rect.x, rect.y, width, rect.height);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002BE0 File Offset: 0x00000DE0
		public static Rect ReplaceHeight(this Rect rect, float height)
		{
			return new Rect(rect.x, rect.y, rect.width, height);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002C00 File Offset: 0x00000E00
		public static Rect ReplacexMin(this Rect rect, float xMin)
		{
			return new Rect(rect)
			{
				xMin = xMin
			};
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002C20 File Offset: 0x00000E20
		public static Rect ReplaceyMin(this Rect rect, float yMin)
		{
			return new Rect(rect)
			{
				yMin = yMin
			};
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002C40 File Offset: 0x00000E40
		public static Rect ReplacexMax(this Rect rect, float xMax)
		{
			return new Rect(rect)
			{
				xMax = xMax
			};
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002C60 File Offset: 0x00000E60
		public static Rect ReplaceyMax(this Rect rect, float yMax)
		{
			return new Rect(rect)
			{
				yMax = yMax
			};
		}
	}
}
