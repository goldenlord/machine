using UnityEngine;
using machine.Field;

namespace machine.Tank
{
	/// <summary>
	/// tank
	/// </summary>
	public class TankBase : FieldObjectBase
	{
		public static float UP_DIRECTION_EULER_Z = 0f;
		public static float DOWN_DIRECTION_EULER_Z = -180f;
		public static float LEFT_DIRECTION_EULER_Z = 90f;
		public static float RIGHT_DIRECTION_EULER_Z = -90f;

		public static float DEFAULT_SPEED = 10f;

		public BattleField Field { private set; get; } 

		public float Speed { private set; get; }
		public MoveDirection Direction { private set; get; }
		public bool IsPlayer { private set; get; }

		private Cannon _cannon;

		public TankBase (GameObject tankPrefab, GameObject bulletPrefab, BattleField field, bool isPlayer)
		{
			Field = field;
			IsPlayer = isPlayer;
			//view生成
			View = new TankViewBase (tankPrefab);
			//cannon
			Direction = isPlayer ? MoveDirection.RIGHT : MoveDirection.LEFT;
			_cannon = new Cannon (this, bulletPrefab);

			Speed = DEFAULT_SPEED;
		}

		public void MoveTank (MoveDirection direction)
		{
			Direction = direction;
			Vector3 newPosition = View.Position;
			Quaternion newRotation = Quaternion.Euler (0f, 0f, 0f);
			switch (direction)
			{
			case MoveDirection.UP:
				newPosition += new Vector3 (0f, Speed, 0f);
				newRotation = Quaternion.Euler (0f, 0f, UP_DIRECTION_EULER_Z);
				break;
			case MoveDirection.DOWN:
				newPosition += new Vector3 (0f, -Speed, 0f);
				newRotation = Quaternion.Euler (0f, 0f, DOWN_DIRECTION_EULER_Z);
				break;
			case MoveDirection.LEFT:
				newPosition += new Vector3 (-Speed, 0f, 0f);
				newRotation = Quaternion.Euler (0f, 0f, LEFT_DIRECTION_EULER_Z);
				break;
			case MoveDirection.RIGHT:
				newPosition += new Vector3 (Speed, 0f, 0f);
				newRotation = Quaternion.Euler (0f, 0f, RIGHT_DIRECTION_EULER_Z);
				break;
			default:
				return;
			}
			//check movability
			if (Field.CheckTankMovable (this, newPosition))
			{
				View.Move (newPosition, newRotation);
			}
			else
			{
				View.Move (View.Position, newRotation);
			}
		}
	}
}
