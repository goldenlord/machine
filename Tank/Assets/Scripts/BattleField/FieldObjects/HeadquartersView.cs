using UnityEngine;
using machine.Player;

namespace machine.Field
{
	public class HeadquartersView : FieldObjectViewBase
	{
		protected override float DefaultSize { get { return 500f; }}

		public HeadquartersView (GameObject headquartersPrefab, bool isPlayer) : base (headquartersPrefab)
		{
			if (!isPlayer)
			{
				SpriteRenderer sprite = _object.GetComponent<SpriteRenderer> ();
				sprite.color = BattleEnemy.ENEMY_HEADQUARTERS_COLOR;
			}
		}

		public void SetStartPosition (BattleField field, bool isPlayer)
		{
			float x = (isPlayer ? -1f : 1f) * (field.View.FieldWidth - Size.x) / 2f;
			SetPosition (x, 0f);
		}
	}
}
