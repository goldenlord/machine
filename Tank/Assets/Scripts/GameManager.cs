using System;
using UnityEngine;
using machine.Field;
using machine.Player;

namespace machine
{
	public class GameManager
	{
		private PrefabManager _prefabManager;
		private TouchControl _touchControl;

		private BattleField _field;

		public BattlePlayer Player {private set; get;}

		//main camera
		public static Camera MainCamera { get { return Camera.main; } }

		public GameManager ()
		{
			_prefabManager = new PrefabManager ();
			CreateField ();
			CreatePlayer ();
			_touchControl = new TouchControl (Player.Tank);
		}

		public void Update ()
		{
			_touchControl.Update ();
		}

		private void CreateField ()
		{
			if (_field == null)
			{
				_field = new BattleField (_prefabManager.FieldPrefab);
			}
		}

		private void CreatePlayer ()
		{
			if (Player == null) {
				Player = new BattlePlayer (_field, _prefabManager);
			}
		}
	}
}
