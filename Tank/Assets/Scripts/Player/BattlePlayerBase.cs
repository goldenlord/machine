using machine.Field;

namespace machine.Player
{
	public class BattlePlayerBase
	{
		public BattleField Field { protected set; get; }
		protected Headquarters _headquarters;

		public BattlePlayerBase (BattleField field)
		{
			Field = field;
		}
	}
}
