using UnityEngine;

namespace machine.Field
{
	public class HeadquartersView : FieldObjectViewBase
	{
		protected override float DefaultSize { get { return 500f; }}

		public HeadquartersView (GameObject headquartersPrefab) : base (headquartersPrefab) {}

		public void SetStartPosition (BattleField field, bool isPlayer)
		{
			float x = (isPlayer ? -1f : 1f) * (field.View.FieldWidth - Size.x) / 2f;
			SetPosition (x, 0f);
		}
	}
}
