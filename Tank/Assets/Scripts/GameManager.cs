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
		public BattleEnemy Enemy { private set; get;}

		//for coroutine
		public static SubBehaviour CoroutineHandler {private set; get;}

		//main camera
		public static Camera MainCamera { get { return Camera.main; } }

		public GameManager ()
		{
			//coroutine handler
			GameObject g = new GameObject ();
			CoroutineHandler = g.AddComponent<SubBehaviour> ();
			_prefabManager = new PrefabManager ();
			CreateField ();
			CreatePlayers ();
			_touchControl = new TouchControl (Player.Tank);
		}

		public void Update ()
		{
			_touchControl.Update ();
			_field.BulletsFly ();
		}

		private void CreateField ()
		{
			if (_field == null)
			{
				_field = new BattleField (_prefabManager);
			}
		}

		private void CreatePlayers ()
		{
			if (Player == null)
			{
				Player = new BattlePlayer (_field);
			}
			if (Enemy == null)
			{
				Enemy = new BattleEnemy (_field);
			}
		}
	}
}
