using machine.Field;

namespace machine.Player
{
	public class BattlePlayerBase
	{
		public BattleField Field { protected set; get; }
		public virtual bool IsPlayer { get { return true; } }
		protected Headquarters _headquarters;

		public BattlePlayerBase (BattleField field, PrefabManager prefabManager)
		{
			Field = field;
			//Headquarters
			CreateHeadquarters (prefabManager);
			//Tank
			CreateTank (prefabManager);
			Initialize ();
			field.CreateBrickWallsForHeadquarters (_headquarters, prefabManager);
		}

		protected virtual void Initialize ()
		{
			((HeadquartersView)_headquarters.View).SetStartPosition (Field, IsPlayer);
		}

		protected virtual void CreateTank (PrefabManager prefabManager) {}

		protected virtual void CreateHeadquarters (PrefabManager prefabManager)
		{
			if (_headquarters == null)
			{
				_headquarters = new Headquarters (prefabManager.HeadquartersPrefab, IsPlayer);
				Field.FieldObjects.Add (_headquarters);
			}
		}
	}
}
