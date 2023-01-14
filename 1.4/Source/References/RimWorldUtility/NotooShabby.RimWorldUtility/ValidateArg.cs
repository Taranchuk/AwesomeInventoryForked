using System;
using System.Collections;

namespace RimWorldUtility
{
	// Token: 0x0200001A RID: 26
	public static class ValidateArg
	{
		// Token: 0x0600006C RID: 108 RVA: 0x00002C7E File Offset: 0x00000E7E
		public static void NotNull(object arg, string argName)
		{
			if (arg == null)
			{
				throw new ArgumentNullException(argName);
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002C8C File Offset: 0x00000E8C
		public static void NotNullOrEmpty(object arg, string argName)
		{
			ValidateArg.NotNull(arg, argName);
			string text = arg as string;
			if (text == null)
			{
				IEnumerable enumerable = arg as IEnumerable;
				if (enumerable == null)
				{
					return;
				}
				if (enumerable.GetEnumerator().MoveNext())
				{
					throw new ArgumentEmtpyException(argName);
				}
			}
			else if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentEmtpyException(argName);
			}
		}
	}
}
