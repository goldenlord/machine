using System;
using UnityEngine;
using machine.Tank;
using machine.Field;

namespace machine
{
	public class GameManager
	{
		const float TANK_START_POSITION_X = 0f;
		const float TANK_START_POSITION_Y = -1500f;

		private PrefabManager _prefabManager;
		private TouchControl _touchControl;

		private BattleField _field;
		//Todo: player和enemy分离
		private TankBase _tank;

		//main camera
		public static Camera MainCamera { get { return Camera.main; } }

		public GameManager ()
		{
			_prefabManager = new PrefabManager ();
			CreateField ();
			CreateTank ();
			_touchControl = new TouchControl (_tank);
			//初始化
			Initialize ();
		}

		public void Update ()
		{
			_touchControl.Update ();
		}

		private void Initialize ()
		{
			_tank.View.SetPosition (TANK_START_POSITION_X, TANK_START_POSITION_Y);
		}

		private void CreateTank ()
		{
			if (_tank == null)
			{
				_tank = new TankBase (_prefabManager.TankPrefab);
			}
		}

		private void CreateField ()
		{
			if (_field == null)
			{
				_field = new BattleField (_prefabManager.FieldPrefab);
			}
		}
	}
}
