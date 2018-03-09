using machine.Tank;
using machine.Field;
using UnityEngine;

namespace machine.Player
{
	public class BattleEnemy : BattlePlayerBase
	{
		public static Color ENEMY_HEADQUARTERS_COLOR = Color.red;
		public override bool IsPlayer { get { return false; } }
		public BattleEnemy (BattleField field, PrefabManager prefabManager) : base (field, prefabManager) {}


	}
}
