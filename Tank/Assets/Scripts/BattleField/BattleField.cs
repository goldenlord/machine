using UnityEngine;

namespace machine.Field
{
	/// <summary>
	/// Battle field
	/// </summary>
	public class BattleField
	{
		public BattleFieldView View { private set; get; }

		public BattleField (GameObject fieldPrefab)
		{
			View = new BattleFieldView (fieldPrefab);
		}
	}
}
