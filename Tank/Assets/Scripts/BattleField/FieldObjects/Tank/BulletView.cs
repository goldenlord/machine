using UnityEngine;
using machine.Field;

namespace machine.Tank
{
	public class BulletView : FieldObjectViewBase
	{
		protected override float DefaultSize { get { return 100f; } }
		protected override float DefaultZ { get { return -0.5f; } }
		public BulletView (GameObject bulletPrefab) : base (bulletPrefab) {}
	}
}