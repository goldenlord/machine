using UnityEngine;

namespace machine.Field
{
	public class Headquarters : FieldObjectBase
	{
		public bool IsDead;
		public override bool CanBePassThrough { get { return false; } }
		public Headquarters (GameObject headquartersPrefab) : base ()
		{
			View = new HeadquartersView (headquartersPrefab);
			IsDead = false;
		}
	}
}
