using System;
using System.Collections.Generic;

namespace RimWorldUtility
{
	// Token: 0x0200001B RID: 27
	public class ServiceProvider
	{
		// Token: 0x0600006E RID: 110 RVA: 0x00002CD8 File Offset: 0x00000ED8
		public T GetService<T>()
		{
			return (T)((object)this._services[typeof(T)]);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002CF4 File Offset: 0x00000EF4
		public void AddService(Type type, object servie)
		{
			ValidateArg.NotNull(type, "type");
			ValidateArg.NotNull(servie, "servie");
			this._services[type] = servie;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00002D19 File Offset: 0x00000F19
		public bool TryGetService(Type type, out object service)
		{
			if (this._services.ContainsKey(type))
			{
				service = this._services[type];
				return true;
			}
			service = null;
			return false;
		}

		// Token: 0x04000019 RID: 25
		private Dictionary<Type, object> _services = new Dictionary<Type, object>();
	}
}
