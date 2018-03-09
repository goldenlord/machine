using machine.Tank;
using machine.Field;
using UnityEngine;

namespace machine.Player
{
	public class BattlePlayer : BattlePlayerBase
	{
		public static Vector3 TANK_START_POSITION = new Vector3 (-3875, 1125f, -1f);
		public static Quaternion TANK_START_ROTATION = Quaternion.Euler (new Vector3 (0f, 0f, -90f));

		public TankBase Tank { private set; get; }
		public BattlePlayer (BattleField field, PrefabManager prefabManager) : base (field, prefabManager) {}

		protected override void Initialize ()
		{
			base.Initialize ();
			Tank.View.Move (TANK_START_POSITION, TANK_START_ROTATION);
		}

		protected override void CreateTank (PrefabManager prefabManager)
		{
			if (Tank == null)
			{
				Tank = new TankBase (prefabManager.TankPrefab, Field);
			}
		}
	}
}
