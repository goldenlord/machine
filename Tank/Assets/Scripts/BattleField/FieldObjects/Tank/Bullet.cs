using UnityEngine;

namespace machine.Tank
{
	public class Bullet : MonoBehaviour
	{
		public float Speed;
		public MoveDirection Direction;

		private void Update ()
		{
			if (Speed > 0f)
			{
				Move ();
			}
		}

		private void Move ()
		{
			Vector3 displacement = Vector3.zero;
			switch (Direction)
			{
			case MoveDirection.DOWN:
				displacement = new Vector3 (0f, -Speed, 0f);
				break;
			case MoveDirection.LEFT:
				displacement = new Vector3 (-Speed, 0f, 0f);
				break;
			case MoveDirection.RIGHT:
				displacement = new Vector3 (Speed, 0f, 0f);
				break;
			case MoveDirection.UP:
				displacement = new Vector3 (0f, Speed, 0f);
				break;
			default:
				return;
			}
			gameObject.transform.position = gameObject.transform.position + displacement;
		}
	}
}
