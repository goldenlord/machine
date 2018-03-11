using UnityEngine;
using System.Collections;

namespace machine.Tank
{
	public class Cannon
	{
		private const float DEFAULT_SHOOTING_FREQUENCE = 1f;
		private const float DEFAULT_BULLET_SPEED = 50f;

		private GameObject _bulletPrefab;

		private TankBase _tank;
		public float ShootingFrequence;
		public float BulletSpeed;

		public Cannon (TankBase tank, GameObject bulletPrefab)
		{
			_tank = tank;
			_bulletPrefab = bulletPrefab;
			ShootingFrequence = DEFAULT_SHOOTING_FREQUENCE;
			BulletSpeed = DEFAULT_BULLET_SPEED;
			IEnumerator shooting = KeepShooting ();
			GameManager.CoroutineHandler._StartCoroutine (shooting);
		}

		public IEnumerator KeepShooting ()
		{
			yield return null;
			while (true)
			{
				Bullet bullet = CreateBullet ();
				yield return null;//wait for 1 frame;
				//bullet initialize
				bullet.Speed = BulletSpeed;
				bullet.Direction = _tank.Direction;

				yield return new WaitForSeconds (1f / ShootingFrequence);
			}
		}

		private Bullet CreateBullet ()
		{
			Bullet bullet = new Bullet (_bulletPrefab, _tank);
			_tank.Field.FieldObjects.Add (bullet);
			_tank.Field.Bullets.Add (bullet);
			return bullet;
		}
	}
}