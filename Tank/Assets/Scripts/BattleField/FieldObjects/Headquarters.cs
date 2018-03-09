using UnityEngine;

namespace machine.Field
{
	public class Headquarters : FieldObjectBase
	{
		public bool IsDead;
		public bool IsPlayer { private set; get; }
		public override bool CanBePassThrough { get { return false; } }
		public Headquarters (GameObject headquartersPrefab, bool isPlayer) : base ()
		{
			View = new HeadquartersView (headquartersPrefab, isPlayer);
			IsDead = false;
			IsPlayer = isPlayer;
		}
	}
}
