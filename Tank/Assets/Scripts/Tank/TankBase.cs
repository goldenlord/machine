using UnityEngine;

namespace Tank
{
	/// <summary>
	/// 坦克
	/// </summary>
	public class TankBase
	{
		public static float DEFAULT_SPEED = 10f;

		public TankViewBase View { private set; get; }
		public float Speed { private set; get; }

		public TankBase (GameObject tankPrefab)
		{
			//view生成
			View = new TankViewBase (tankPrefab);
			Speed = DEFAULT_SPEED;
		}

		public void MoveTank (MoveDirection direction)
		{
			View.Move (direction, Speed);
		}
	}
}
