using UnityEngine;
using System.Collections;

namespace machine.Tank
{
	public class Cannon
	{
		private const float DEFAULT_SHOOTING_FREQUENCE = 1f;
		private const float DEFAULT_BULLET_SPEED = 50f;
		private const float BULLET_POSITION_Z = -0.5f;

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
				GameObject bulletObject = UnityEngine.Object.Instantiate (_bulletPrefab);
				Bullet bullet = bulletObject.GetComponent<Bullet> ();
				bulletObject.transform.position = new Vector3 (_tank.View.Position.x, _tank.View.Position.y, BULLET_POSITION_Z);
				yield return null;//wait for 1 frame;
				//bullet initialize
				bullet.Speed = BulletSpeed;
				bullet.Direction = _tank.Direction;

				yield return new WaitForSeconds (1f / ShootingFrequence);
			}
		}
	}
}