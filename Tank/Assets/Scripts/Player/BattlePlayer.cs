using machine.Tank;
using machine.Field;
using UnityEngine;

namespace machine.Player
{
	public class BattlePlayer : BattlePlayerBase
	{
		public static Vector3 TANK_START_POSITION = new Vector3 (-3000, 0f, -1f);
		public static Quaternion TANK_START_ROTATION = Quaternion.Euler (new Vector3 (0f, 0f, -90f));

		public TankBase Tank { private set; get; }
		public BattlePlayer (BattleField field, PrefabManager prefabManager) : base (field)
		{
			//Headquarters
			CreateHeadquarters (prefabManager);
			//Tank
			CreateTank (prefabManager);
			Initialize ();
		}

		private void Initialize ()
		{
			Tank.View.Move (TANK_START_POSITION, TANK_START_ROTATION);
			((HeadquartersView)_headquarters.View).SetStartPosition (Field, true);
		}

		private void CreateTank (PrefabManager prefabManager)
		{
			if (Tank == null)
			{
				Tank = new TankBase (prefabManager.TankPrefab, Field);
			}
		}

		private void CreateHeadquarters (PrefabManager prefabManager)
		{
			if (_headquarters == null)
			{
				_headquarters = new Headquarters (prefabManager.HeadquartersPrefab);
				Field.FieldObjects.Add (_headquarters);
			}
		}
	}
}
