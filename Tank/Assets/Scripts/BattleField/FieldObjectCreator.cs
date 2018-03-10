using UnityEngine;
using machine.Tank;

namespace machine.Field
{
	public class FieldObjectCreator
	{
		private PrefabManager _prefabManager;
		private BattleField _field;

		public FieldObjectCreator (PrefabManager prefabManager, BattleField field)
		{
			_prefabManager = prefabManager;
			_field = field;
		}

		public TankBase CreateTank (bool isPlayer)
		{
			TankBase tank = new TankBase (_prefabManager.TankPrefab, _prefabManager.BulletPrefab, _field, isPlayer);
			_field.FieldObjects.Add (tank);
			return tank;
		}

		public Headquarters CreateHeadquarters (bool isPlayer)
		{
			Headquarters headquarters = new Headquarters (_prefabManager.HeadquartersPrefab, isPlayer);
			_field.FieldObjects.Add (headquarters);
			return headquarters;
		}

		public BrickWall CreateBrickWall ()
		{
			BrickWall brickWall = new BrickWall (_prefabManager.BrickWallPrefab);
			_field.FieldObjects.Add (brickWall);
			return brickWall;
		}
	}
}
