using System;

namespace RimWorldUtility
{
	// Token: 0x02000015 RID: 21
	public interface IValueNotify<in T> where T : struct
	{
		// Token: 0x0600005A RID: 90
		void Update(T oldValue, T newValue);
	}
}
