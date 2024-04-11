using System;

namespace RimWorldUtility
{
	// Token: 0x02000007 RID: 7
	public abstract class CacheableBase<TType, TTime, TInterval> : CacheableBase where TInterval : new()
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002126 File Offset: 0x00000326
		public CacheableBase(TType t, Func<TTime> now, TInterval interval, Func<TType> update, TTime lastUpdateTime = default(TTime))
		{
			this._backingField = t;
			this.UpdateInterval = interval;
			this.Update = update;
			this.Now = now;
			this.LastUpdateTime = lastUpdateTime;
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002153 File Offset: 0x00000353
		// (set) Token: 0x0600000F RID: 15 RVA: 0x0000215B File Offset: 0x0000035B
		public TInterval UpdateInterval { get; protected set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002164 File Offset: 0x00000364
		// (set) Token: 0x06000011 RID: 17 RVA: 0x0000216C File Offset: 0x0000036C
		public TTime LastUpdateTime { get; protected set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002175 File Offset: 0x00000375
		// (set) Token: 0x06000013 RID: 19 RVA: 0x0000217D File Offset: 0x0000037D
		public Func<TType> Update { get; protected set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002186 File Offset: 0x00000386
		// (set) Token: 0x06000015 RID: 21 RVA: 0x0000218E File Offset: 0x0000038E
		public Func<TTime> Now { get; set; }

		// Token: 0x06000016 RID: 22
		public abstract bool ShouldUpdate(out TTime now);

		// Token: 0x06000017 RID: 23 RVA: 0x00002198 File Offset: 0x00000398
		public override void TriggerUpdate()
		{
			TTime ttime;
			if (!this.ShouldUpdate(out ttime))
			{
				return;
			}
			this._backingField = ((this.Update != null) ? this.Update() : this._backingField);
			this.LastUpdateTime = ttime;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000021D8 File Offset: 0x000003D8
		public virtual void ForceUpdate()
		{
			this.LastUpdateTime = this.Now();
			this._backingField = ((this.Update != null) ? this.Update() : this._backingField);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000220C File Offset: 0x0000040C
		public override bool Validate()
		{
			return true;
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001A RID: 26 RVA: 0x0000220F File Offset: 0x0000040F
		// (set) Token: 0x0600001B RID: 27 RVA: 0x00002217 File Offset: 0x00000417
		public virtual TType Value
		{
			get
			{
				return this._backingField;
			}
			set
			{
				this.LastUpdateTime = this.Now();
				this._backingField = value;
			}
		}

		// Token: 0x04000002 RID: 2
		protected TType _backingField;
	}
}
