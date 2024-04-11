using System;
using System.Collections.Generic;

namespace RimWorldUtility
{
	// Token: 0x0200000F RID: 15
	public class CollectionNotifier<T, TCollection> : ICollectionNotifier<T>, ICollectionNotify<T>, INotifier<ICollectionNotify<T>> where TCollection : ICollection<T>, new()
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00002598 File Offset: 0x00000798
		// (set) Token: 0x0600004C RID: 76 RVA: 0x000025A0 File Offset: 0x000007A0
		public TCollection Data { get; protected set; } = new TCollection();

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000025A9 File Offset: 0x000007A9
		// (set) Token: 0x0600004E RID: 78 RVA: 0x000025B1 File Offset: 0x000007B1
		public HashSet<ICollectionNotify<T>> Receivers { get; protected set; } = new HashSet<ICollectionNotify<T>>();

		// Token: 0x0600004F RID: 79 RVA: 0x000025BC File Offset: 0x000007BC
		public void Add(T data)
		{
			ValidateArg.NotNull(data, "data");
			TCollection data2 = this.Data;
			data2.Add(data);
			foreach (ICollectionNotify<T> collectionNotify in this.Receivers)
			{
				collectionNotify.Add(data);
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002634 File Offset: 0x00000834
		public void Remove(T data)
		{
			ValidateArg.NotNull(data, "data");
			TCollection data2 = this.Data;
			data2.Remove(data);
			foreach (ICollectionNotify<T> collectionNotify in this.Receivers)
			{
				collectionNotify.Remove(data);
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000026AC File Offset: 0x000008AC
		public void Register(ICollectionNotify<T> receiver)
		{
			ValidateArg.NotNull(receiver, "receiver");
			this.Receivers.Add(receiver);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000026C6 File Offset: 0x000008C6
		public void Unregister(ICollectionNotify<T> receiver)
		{
			this.Receivers.Remove(receiver);
		}
	}
}
