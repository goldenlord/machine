using machine.Field;

namespace machine.Player
{
	public class BattlePlayerBase
	{
		public BattleField Field { protected set; get; }
		public virtual bool IsPlayer { get { return true; } }
		protected Headquarters _headquarters;

		public BattlePlayerBase (BattleField field)
		{
			Field = field;
			//Headquarters
			CreateHeadquarters ();
			//Tank
			CreateTank ();
			Initialize ();
			Field.CreateBrickWallsForHeadquarters (_headquarters);
		}

		protected virtual void Initialize ()
		{
			((HeadquartersView)_headquarters.View).SetStartPosition (Field, IsPlayer);
		}

		protected virtual void CreateTank () {}

		protected virtual void CreateHeadquarters ()
		{
			if (_headquarters == null)
			{
				_headquarters = Field.CreateHeadquarters (IsPlayer);
			}
		}
	}
}
