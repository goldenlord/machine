using UnityEngine;

namespace machine.Field
{
	public class FieldObjectBase
	{
		public virtual FieldObjectViewBase View { protected set; get; }
		public virtual bool CanBePassThrough { get { return true; }}
		public FieldObjectBase () {}
	}
}
