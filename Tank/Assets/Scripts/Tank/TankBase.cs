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

		public TankBase (GameObject tankPrefab, BattleField field)
		{
			Field = field;
			//view生成
			View = new TankViewBase (tankPrefab);
			Speed = DEFAULT_SPEED;
		}

		public void MoveTank (MoveDirection direction)
		{
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
			if (Field.CheckTankMovable (newPosition, View.Size))
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
