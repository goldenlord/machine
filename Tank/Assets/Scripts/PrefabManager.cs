using UnityEngine;

namespace Tank
{
	public class PrefabManager
	{
		const string PREFAB_PATH = "Prefabs/";

		private GameObject _tankPrefab;
		public GameObject TankPrefab { get { return _tankPrefab; } }

		public PrefabManager ()
		{
			Load ();
		}

		private void Load ()
		{
			_tankPrefab = (GameObject)Resources.Load (PREFAB_PATH + "Tank");
		}
	}
}
