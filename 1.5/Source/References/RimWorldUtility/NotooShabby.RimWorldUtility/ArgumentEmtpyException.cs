using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace RimWorldUtility
{
	// Token: 0x02000005 RID: 5
	[Serializable]
	public sealed class ArgumentEmtpyException : Exception
	{
		// Token: 0x06000008 RID: 8 RVA: 0x000020FC File Offset: 0x000002FC
		public ArgumentEmtpyException(string argName)
			: base(string.Format(CultureInfo.InvariantCulture, "Argument {0} is empty.", argName))
		{
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002114 File Offset: 0x00000314
		private ArgumentEmtpyException(SerializationInfo serializationInfo, StreamingContext streamingContext)
			: base(serializationInfo, streamingContext)
		{
		}

		// Token: 0x04000001 RID: 1
		private const string _message = "Argument {0} is empty.";
	}
}
