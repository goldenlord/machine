using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using machine.Tank;

namespace machine.Field
{
	/// <summary>
	/// Battle field
	/// </summary>
	public class BattleField
	{
		public BattleFieldView View { private set; get; }
		public List<FieldObjectBase> FieldObjects;
		public List<Bullet> Bullets;
		private FieldObjectCreator _objectCreator;

		public BattleField (PrefabManager prefabManager)
		{
			View = new BattleFieldView (prefabManager.FieldPrefab);
			FieldObjects = new List<FieldObjectBase> ();
			Bullets = new List<Bullet> ();
			_objectCreator = new FieldObjectCreator (prefabManager, this);
		}

		public TankBase CreateTank (bool isPlayer)
		{
			return _objectCreator.CreateTank (isPlayer);
		}

		public Headquarters CreateHeadquarters (bool isPlayer)
		{
			return _objectCreator.CreateHeadquarters (isPlayer);
		}

		public void CreateBrickWallsForHeadquarters (Headquarters headquarters)
		{
			const int brickWallCount = 8;
			List<BrickWall> brickWalls = new List<BrickWall> ();
			for (int index = 0; index < brickWallCount; ++index)
			{
				BrickWall brickWall = _objectCreator.CreateBrickWall ();
				brickWalls.Add (brickWall);
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

		public void BulletsFly ()
		{
			for (int index = 0; index < Bullets.Count; ++index)
			{
				Bullet bullet = Bullets [index];
				if (bullet.Speed > 0)
				{
					FieldObjectBase hit = HitObject (bullet, bullet.View.Position);
					if ((hit == null || hit == bullet.SelfTank)  && CheckIsInField (bullet, bullet.View.Position))
					{
						bullet.Move ();
					}
					else
					{
						bullet.Destroy ();
					}
				}
			}
			//delete dead bullet
			Bullets.RemoveAll (b => b.IsDead);
		}

		public bool CheckMovable (FieldObjectBase movingObject, Vector3 position)
		{
			if (!CheckIsInField (movingObject, position))
			{
				return false;
			}
			if (HitObject (movingObject, position) != null)
			{
				return false;
			}
			return true;
		}

		public bool CheckIsInField (FieldObjectBase movingObject, Vector3 newPosition)
		{
			Vector2 size = movingObject.View.Size;
			//Check if tank is in field
			float x = Mathf.Abs (newPosition.x) + size.x / 2;
			float y = Mathf.Abs (newPosition.y) + size.y / 2;
			if (x > View.FieldWidth / 2 || y > View.FieldHeight / 2)
			{
				return false;
			}
			return true;
		}

		public FieldObjectBase HitObject (FieldObjectBase movingObject, Vector3 newPosition)
		{
			Vector2 size = movingObject.View.Size;
			//Check if tank collides with other objects
			for (int index = 0; index < FieldObjects.Count; ++index)
			{
				FieldObjectBase objectTemp = FieldObjects [index];
				if (objectTemp == movingObject) continue;
				if (!objectTemp.CanBePassThrough)
				{
					//Todo: Check collision
					float horizontalDistance = Mathf.Abs(newPosition.x - objectTemp.View.Position.x);
					float verticalDistance = Mathf.Abs (newPosition.y - objectTemp.View.Position.y);
					if (horizontalDistance < (objectTemp.View.Size.x + size.x) / 2
						&& verticalDistance < (objectTemp.View.Size.y + size.y) / 2)
					{
						return objectTemp;
					}
				}
			}
			return null;
		}
	}
}
