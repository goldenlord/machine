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

		public void CreateBrickWallsForHeadquarters (Headquarters headquarters, PrefabManager prefabManager)
		{
			const int brickWallCount = 8;
			List<BrickWall> brickWalls = new List<BrickWall> ();
			for (int index = 0; index < brickWallCount; ++index)
			{
				BrickWall brickWall = new BrickWall (prefabManager.BrickWallPrefab);
				brickWalls.Add (brickWall);
				FieldObjects.Add (brickWall);
			}
			float brickWallSizeHalfX = brickWalls [0].View.Size.x / 2;
			float brickWallSizeHalfY = brickWalls [0].View.Size.y / 2;
			//calculate position
			float headquartersLeftSide = headquarters.View.Position.x - headquarters.View.Size.x / 2;
			float headquartersRightSide = headquarters.View.Position.x + headquarters.View.Size.x / 2;
			float headquartersUpSide = headquarters.View.Position.y + headquarters.View.Size.y / 2;
			float headquartersDownSide = headquarters.View.Position.y - headquarters.View.Size.y / 2;
			//set upper and downstair bricks
			float midLeftX = headquartersLeftSide + brickWallSizeHalfX;
			float midRightX = headquartersRightSide - brickWallSizeHalfX;
			float upperY = headquartersUpSide + brickWallSizeHalfY;
			float downstairY = headquartersDownSide - brickWallSizeHalfY;
			int brickIndex = 0;
			BrickWall upLeft = brickWalls [brickIndex++]; //0
			upLeft.View.SetPosition (midLeftX, upperY);
			BrickWall upRight = brickWalls [brickIndex++]; //1
			upRight.View.SetPosition (midRightX, upperY);
			BrickWall downLeft = brickWalls [brickIndex++]; //2
			downLeft.View.SetPosition (midLeftX, downstairY);
			BrickWall downRight = brickWalls [brickIndex++]; //3
			downRight.View.SetPosition (midRightX, downstairY);
			//set left or right bricks
			float restBricksX = headquarters.IsPlayer ? 
				headquartersRightSide + brickWallSizeHalfX : headquartersLeftSide - brickWallSizeHalfX;
			for (int restIndex = brickIndex; restIndex < brickWallCount; ++restIndex)
			{
				brickWalls [restIndex].View.SetPosition (restBricksX, upperY - (restIndex - brickIndex) * brickWallSizeHalfY * 2);
			}

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
					float horizontalDistance = Mathf.Abs(position.x - objectTemp.View.Position.x);
					float verticalDistance = Mathf.Abs (position.y - objectTemp.View.Position.y);
					if (horizontalDistance < (objectTemp.View.Size.x + size.x) / 2
						&& verticalDistance < (objectTemp.View.Size.y + size.y) / 2)
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}
