using RimWorldUtility.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RimWorldUtility
{
	// Token: 0x02000016 RID: 22
	public static class ColorUtility
	{
		// Token: 0x0600005B RID: 91 RVA: 0x0000279C File Offset: 0x0000099C
		public static List<(PrimaryColor PrimaryColor, float Value)> OrderbyHue(this Color color)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			return new List<(PrimaryColor, float)>
			{
				(PrimaryColor.Red, color.r),
				(PrimaryColor.Green, color.g),
				(PrimaryColor.Blue, color.b)
			}.OrderByDescending<(PrimaryColor, float), float>(((PrimaryColor PrimaryColor, float Value) t) => t.Value).ToList();
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002810 File Offset: 0x00000A10
		public static Color Sanitize(this Color color)
		{
			color.r = (color.r < 0f) ? 0f : color.r;
			color.g = (color.g < 0f) ? 0f : color.g;
			color.b = (color.b < 0f) ? 0f : color.b;
			color.a = (color.a < 0f) ? 0f : color.a;
			return color;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000028A4 File Offset: 0x00000AA4
		public static bool HueContains(this Color hue, Color color, PrimaryColor primaryColor, PrimaryColor secondaryColor)
		{
			switch (primaryColor)
			{
				case PrimaryColor.Red:
					if (secondaryColor == PrimaryColor.Green)
					{
						return ColorUtility.HueContains(color.r, color.g, color.b, hue.g);
					}
					if (secondaryColor == PrimaryColor.Blue)
					{
						return ColorUtility.HueContains(color.r, color.b, color.g, hue.b);
					}
					break;
				case PrimaryColor.Green:
					if (secondaryColor == PrimaryColor.Red)
					{
						return ColorUtility.HueContains(color.g, color.r, color.b, hue.r);
					}
					if (secondaryColor == PrimaryColor.Blue)
					{
						return ColorUtility.HueContains(color.g, color.b, color.r, hue.b);
					}
					break;
				case PrimaryColor.Blue:
					if (secondaryColor == PrimaryColor.Red)
					{
						return ColorUtility.HueContains(color.b, color.r, color.g, hue.r);
					}
					if (secondaryColor == PrimaryColor.Green)
					{
						return ColorUtility.HueContains(color.b, color.g, color.r, hue.g);
					}
					break;
			}
			return false;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000029B0 File Offset: 0x00000BB0
		public static bool SameAs(this Color color, Color other, out bool diffByAlpha)
		{
			Color color2 = color - other;
			diffByAlpha = false;
			if (Mathf.Max(new float[]
			{
				Mathf.Abs(color2.r),
				Mathf.Abs(color2.g),
				Mathf.Abs(color2.b)
			}) >= 0.0039f)
			{
				return false;
			}
			if (Mathf.Abs(color2.a) < 0.0039f)
			{
				return true;
			}
			diffByAlpha = true;
			return false;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002A20 File Offset: 0x00000C20
		private static bool HueContains(double y, double secondY, double thridY, double maxSeondY)
		{
			if (y < secondY || y < thridY || secondY < thridY)
			{
				return false;
			}
			if (Math.Abs(y - secondY) < 0.0038999998942017555 && Math.Abs(y - thridY) < 0.0038999998942017555)
			{
				return true;
			}
			double num = y * maxSeondY;
			if (Math.Abs(secondY - num) < 0.0038999998942017555)
			{
				return true;
			}
			if (secondY > num)
			{
				return false;
			}
			double num2 = (secondY - num) / (y - num);
			if (num2 is > 1.0 or < 0.0)
			{
				return false;
			}
			double num3 = thridY / y;
			return num3 <= 1.0 && num3 >= 0.0 && Math.Abs(num3 - num2) < 0.0038999998942017555;
		}

		// Token: 0x04000016 RID: 22
		public const float Tolerance = 0.0039f;

		// Token: 0x04000017 RID: 23
		public const float MaxRgbValue = 255f;
	}
}
