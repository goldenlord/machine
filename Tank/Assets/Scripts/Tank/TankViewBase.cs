using UnityEngine;

namespace Tank
{
	public class TankViewBase
	{
		public const float UP_DIRECTION_EULER_Z = 0f;
		public const float DOWN_DIRECTION_EULER_Z = -180f;
		public const float LEFT_DIRECTION_EULER_Z = 90f;
		public const float RIGHT_DIRECTION_EULER_Z = -90f;

		private GameObject _object;

		public TankViewBase(GameObject tankPrefab)
		{
			_object = UnityEngine.Object.Instantiate (tankPrefab);
		}

		public void SetPosition (float x, float y)
		{
			_object.transform.position = new Vector3 (x, y, 0f);
		}

		public void Move (MoveDirection direction, float speed)
		{
			Vector3 newPosition = _object.transform.position;
			Quaternion newRotation = Quaternion.Euler (0f, 0f, 0f);
			switch (direction)
			{
			case MoveDirection.UP:
				newPosition += new Vector3 (0f, speed, 0f);
				newRotation = Quaternion.Euler (0f, 0f, UP_DIRECTION_EULER_Z);
				break;
			case MoveDirection.DOWN:
				newPosition += new Vector3 (0f, -speed, 0f);
				newRotation = Quaternion.Euler (0f, 0f, DOWN_DIRECTION_EULER_Z);
				break;
			case MoveDirection.LEFT:
				newPosition += new Vector3 (-speed, 0f, 0f);
				newRotation = Quaternion.Euler (0f, 0f, LEFT_DIRECTION_EULER_Z);
				break;
			case MoveDirection.RIGHT:
				newPosition += new Vector3 (speed, 0f, 0f);
				newRotation = Quaternion.Euler (0f, 0f, RIGHT_DIRECTION_EULER_Z);
				break;
			default:
				return;
			}
			_object.transform.position = newPosition;
			_object.transform.rotation = newRotation;
		}
	}
}
