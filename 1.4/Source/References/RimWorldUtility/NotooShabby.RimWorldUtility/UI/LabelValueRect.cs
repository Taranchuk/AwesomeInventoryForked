using System;
using UnityEngine;
using Verse;

namespace RimWorldUtility.UI
{
	// Token: 0x02000028 RID: 40
	public abstract class LabelValueRect<T> : RectBase<T>
	{
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000BA RID: 186 RVA: 0x0000476D File Offset: 0x0000296D
		protected string _print
		{
			get
			{
				return this._label + ": " + this._value + this._unit;
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000478B File Offset: 0x0000298B
		public override Rect Draw(T model, Vector2 position)
		{
			Rect rect = new Rect(position + this.Offset, this.Size);
			Widgets.Label(rect, this._print);
			return rect;
		}

		// Token: 0x04000062 RID: 98
		protected string _label;

		// Token: 0x04000063 RID: 99
		protected string _value;

		// Token: 0x04000064 RID: 100
		protected string _unit = string.Empty;
	}
}
