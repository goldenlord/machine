using UnityEngine;

namespace machine.Field
{
	public class BrickWall : FieldObjectBase
	{
		public override bool CanBePassThrough { get { return false; } }
		public BrickWall (GameObject brickWallPrefab) : base ()
		{
			View = new BrickWallView (brickWallPrefab);
		}
	}
}