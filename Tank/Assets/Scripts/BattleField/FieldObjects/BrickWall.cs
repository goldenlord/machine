using UnityEngine;

namespace machine.Field
{
	public class BrickWall : FieldObjectBase
	{
		public BrickWall (GameObject brickWallPrefab) : base ()
		{
			View = new BrickWallView (brickWallPrefab);
		}
	}
}