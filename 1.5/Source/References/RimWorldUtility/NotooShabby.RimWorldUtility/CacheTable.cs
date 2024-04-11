using System;
using System.Collections;
using System.Collections.Generic;

namespace RimWorldUtility
{
	// Token: 0x0200000B RID: 11
	public class CacheTable<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable where TValue : CacheableBase
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00002379 File Offset: 0x00000579
		public CacheTable(CacheMaker<TValue, TKey> maker)
		{
			this.CacheMaker = maker;
		}

		// Token: 0x17000009 RID: 9
		public TValue this[TKey key]
		{
			get
			{
				if (!this._cache.ContainsKey(key))
				{
					return this.MakeCache(key);
				}
				return this._cache[key];
			}
			set
			{
				this._cache[key] = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000023C6 File Offset: 0x000005C6
		// (set) Token: 0x06000029 RID: 41 RVA: 0x000023CE File Offset: 0x000005CE
		public CacheMaker<TValue, TKey> CacheMaker { get; private set; }

		// Token: 0x0600002A RID: 42 RVA: 0x000023D8 File Offset: 0x000005D8
		public TValue MakeCache(TKey key)
		{
			TValue tvalue = this.CacheMaker.Make(key);
			this.Add(key, tvalue);
			return tvalue;
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000023FB File Offset: 0x000005FB
		public ICollection<TKey> Keys
		{
			get
			{
				return this._cache.Keys;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002408 File Offset: 0x00000608
		public ICollection<TValue> Values
		{
			get
			{
				return this._cache.Values;
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002415 File Offset: 0x00000615
		public bool ContainsKey(TKey key)
		{
			return this._cache.ContainsKey(key);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002423 File Offset: 0x00000623
		public void Add(TKey key, TValue value)
		{
			this._cache.Add(key, value);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002432 File Offset: 0x00000632
		public bool Remove(TKey key)
		{
			return this._cache.Remove(key);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002440 File Offset: 0x00000640
		public bool TryGetValue(TKey key, out TValue value)
		{
			return this._cache.TryGetValue(key, out value);
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000031 RID: 49 RVA: 0x0000244F File Offset: 0x0000064F
		public int Count
		{
			get
			{
				return this._cache.Count;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000032 RID: 50 RVA: 0x0000245C File Offset: 0x0000065C
		public bool IsReadOnly { get; }

		// Token: 0x06000033 RID: 51 RVA: 0x00002464 File Offset: 0x00000664
		public void Add(KeyValuePair<TKey, TValue> item)
		{
			this._cache.Add(item);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002472 File Offset: 0x00000672
		public void Clear()
		{
			this._cache.Clear();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000247F File Offset: 0x0000067F
		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return this._cache.Contains(item);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000248D File Offset: 0x0000068D
		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			this._cache.CopyTo(array, arrayIndex);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000249C File Offset: 0x0000069C
		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return this._cache.Remove(item);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000024AA File Offset: 0x000006AA
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000024B2 File Offset: 0x000006B2
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return this._cache.GetEnumerator();
		}

		// Token: 0x04000007 RID: 7
		protected IDictionary<TKey, TValue> _cache = new Dictionary<TKey, TValue>();
	}
}
