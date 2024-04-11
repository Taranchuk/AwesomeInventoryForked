using System;
using Verse;

namespace RimWorldUtility
{
	// Token: 0x02000003 RID: 3
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public abstract class RegisterServiceAttribute : StaticConstructorOnStartup
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002084 File Offset: 0x00000284
		public RegisterServiceAttribute(Type @base, Type service)
		{
			ValidateArg.NotNull(@base, "base");
			ValidateArg.NotNull(service, "service");
			if (!@base.IsAssignableFrom(service))
			{
				return;
			}
			object obj;
			if (this.ServiceProvider.TryGetService(@base, out obj) && !service.IsSubclassOf(obj.GetType()))
			{
				return;
			}
			this.ServiceProvider.AddService(@base, Activator.CreateInstance(service));
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5
		public abstract ServiceProvider ServiceProvider { get; }
	}
}
