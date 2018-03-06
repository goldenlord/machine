using System;
using UnityEngine;

namespace Tank
{
	public class GameManager
	{
		const float TANK_START_POSITION_X = 0f;
		const float TANK_START_POSITION_Y = -1500f;

		private PrefabManager _prefabManager;
		//Todo: player和enemy分离
		private TankBase _tank;

		public GameManager ()
		{
			_prefabManager = new PrefabManager ();
			CreateTank ();

			Initialize ();
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
	}
}
