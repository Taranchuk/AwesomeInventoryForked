using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace RimWorldUtility.UI
{
	// Token: 0x02000029 RID: 41
	public class ListRect<T, TItem, TRect> : RectCollection<T, TItem, TRect> where T : IEnumerable<TItem> where TRect : RectBase<TItem>
	{
		// Token: 0x060000BD RID: 189 RVA: 0x000047C3 File Offset: 0x000029C3
		public ListRect()
		{
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000047DD File Offset: 0x000029DD
		public ListRect(DrawDirection direction)
		{
			this._direction = direction;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00004800 File Offset: 0x00002A00
		public Rect Draw(T model, Vector2 position, Texture2D bgTexture2D, Texture2D alterBgTexture2D = null)
		{
			if (bgTexture2D == null)
			{
				return this.Draw(model, position);
			}
			IList<TItem> list = model.GetList<TItem>();
			if (list.Count != this._modelCount)
			{
				Log.Error(string.Format("Count of model - {0} in draw is different from what used in build - {1}.", list.Count, this._modelCount), false);
				return Rect.zero;
			}
			for (int i = 0; i < list.Count; i++)
			{
				Texture2D texture2D = ((i % 2 == 0) ? bgTexture2D : alterBgTexture2D);
				if (texture2D != null)
				{
					TRect trect = this.ChildrenRects[i];
					GUI.DrawTexture(new Rect(trect.Offset + position + this.Offset, trect.Size), texture2D);
				}
			}
			return this.Draw(model, position);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000048C8 File Offset: 0x00002AC8
		public override Rect Draw(T model, Vector2 position)
		{
			IList<TItem> list = model.GetList<TItem>();
			if (list.Count != this._modelCount)
			{
				Log.Error(string.Format("Count of model - {0} in draw is different from what used in build - {1}.", list.Count, this._modelCount), false);
				return Rect.zero;
			}
			Vector2 vector = position + this.Offset;
			for (int i = 0; i < list.Count; i++)
			{
				this.ChildrenRects[i].Draw(list[i], vector);
			}
			return new Rect(vector, this.Size);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004964 File Offset: 0x00002B64
		public override Vector2 Build(T model)
		{
			Vector2 zero = Vector2.zero;
			Vector2 zero2 = Vector2.zero;
			this.ChildrenRects.Clear();
			this.Size = Vector2.zero;
			IList<TItem> list = model.GetList<TItem>();
			foreach (TItem titem in list)
			{
				TRect trect = Activator.CreateInstance<TRect>();
				Vector2 vector = trect.Build(titem);
				DrawDirection direction = this._direction;
				if (direction != DrawDirection.Down)
				{
					if (direction != DrawDirection.Right)
					{
						float num;
						ListRect<T, TItem, TRect>.CalculatePos(ref zero2.y, vector.y, this._maxSize.y, 0f, ref zero.x, vector.x, ref zero2.x, out num);
						trect.Offset = new Vector2(zero2.x, num);
					}
					else
					{
						float num;
						ListRect<T, TItem, TRect>.CalculatePos(ref zero2.x, vector.x, this._maxSize.x, 0f, ref zero.y, vector.y, ref zero2.y, out num);
						trect.Offset = new Vector2(num, zero2.y);
					}
				}
				else
				{
					float num;
					ListRect<T, TItem, TRect>.CalculatePos(ref zero2.y, vector.y, this._maxSize.y, 0f, ref zero.x, vector.x, ref zero2.x, out num);
					trect.Offset = new Vector2(zero2.x, num);
				}
				this.Size.x = Mathf.Max(trect.Offset.x + vector.x, this.Size.x);
				this.Size.y = Mathf.Max(zero2.y, this.Size.y);
				this.ChildrenRects.Add(trect);
			}
			this._modelCount = list.Count;
			return this.Size;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004B88 File Offset: 0x00002D88
		public virtual Vector2 Build(T model, Vector2 maxSize)
		{
			this._maxSize = maxSize;
			return this.Build(model);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004B98 File Offset: 0x00002D98
		public override void Update(T model)
		{
			IList<TItem> list = model.GetList<TItem>();
			int num = this.ChildrenRects.Count - list.Count;
			if (num > 0)
			{
				if (this.ChildrenRects.Count - num > 0)
				{
					this.ChildrenRects.RemoveRange(this.ChildrenRects.Count - num - 1, num);
				}
				else
				{
					this.ChildrenRects.Clear();
				}
			}
			for (int i = 0; i < this.ChildrenRects.Count; i++)
			{
				this.ChildrenRects[i].Update(list[i]);
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004C34 File Offset: 0x00002E34
		private static void CalculatePos(ref float incrementOperand, float increments, float limiter, float referencePoint, ref float stepFactor, float stepFactorNew, ref float stepReference, out float validatedOffset)
		{
			float num = incrementOperand + increments;
			if (num < limiter || limiter <= 0f)
			{
				stepFactor = Mathf.Max(stepFactor, stepFactorNew);
				validatedOffset = incrementOperand;
				incrementOperand = num;
				return;
			}
			validatedOffset = referencePoint;
			incrementOperand = referencePoint + increments;
			stepReference += stepFactor;
			stepFactor = Mathf.Max(stepFactor, stepFactorNew);
		}

		// Token: 0x04000065 RID: 101
		private readonly DrawDirection _direction = DrawDirection.Down;

		// Token: 0x04000066 RID: 102
		private int _modelCount;

		// Token: 0x04000067 RID: 103
		private Vector2 _maxSize = Vector2.zero;
	}
}
