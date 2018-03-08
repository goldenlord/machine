using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace machine.Field
{
	/// <summary>
	/// Battle field
	/// </summary>
	public class BattleField
	{
		public BattleFieldView View { private set; get; }
		public List<FieldObjectBase> FieldObjects;

		public BattleField (GameObject fieldPrefab)
		{
			View = new BattleFieldView (fieldPrefab);
			FieldObjects = new List<FieldObjectBase> ();
		}

		public bool CheckTankMovable (Vector3 position, Vector2 size)
		{
			//Check if tank is in field
			float x = Mathf.Abs (position.x) + size.x / 2;
			float y = Mathf.Abs (position.y) + size.y / 2;
			if (x > View.FieldWidth / 2 || y > View.FieldHeight / 2)
			{
				return false;
			}
			//Check if tank collides with other objects
			for (int index = 0; index < FieldObjects.Count; ++index)
			{
				FieldObjectBase objectTemp = FieldObjects [index];
				if (!objectTemp.CanBePassThrough)
				{
					//Todo: Check collision
				}
			}

			return true;;
		}
	}
}
