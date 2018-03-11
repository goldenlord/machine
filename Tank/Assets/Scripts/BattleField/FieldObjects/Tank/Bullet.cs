using UnityEngine;
using machine.Field;

namespace machine.Tank
{
	public class Bullet : FieldObjectBase
	{
		public float Speed;
		public MoveDirection Direction;
		public bool IsDead;
		public TankBase SelfTank { private set; get; }

		public Bullet (GameObject bulletPrefab, TankBase tank) : base ()
		{
			View = new BulletView (bulletPrefab);
			SelfTank = tank;
			View.SetPosition (tank.View.Position.x, tank.View.Position.y);
			IsDead = false;
		}

		public void Move ()
		{
			Vector3 newPosition = View.Position;
			switch (Direction)
			{
			case MoveDirection.UP:
				newPosition += new Vector3 (0f, Speed, 0f);
				break;
			case MoveDirection.DOWN:
				newPosition += new Vector3 (0f, -Speed, 0f);
				break;
			case MoveDirection.LEFT:
				newPosition += new Vector3 (-Speed, 0f, 0f);
				break;
			case MoveDirection.RIGHT:
				newPosition += new Vector3 (Speed, 0f, 0f);
				break;
			default:
				return;
			}
			View.Move (newPosition, Quaternion.Euler (0f, 0f, 0f));
		}

		public void Destroy ()
		{
			View.DestroyObject ();
			View = null;
			IsDead = true;
		}
	}
}
