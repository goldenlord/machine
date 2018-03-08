using UnityEngine;

namespace machine
{
	/// <summary>
	/// Prefab manager.
	/// </summary>
	public class PrefabManager
	{
		const string PREFAB_PATH = "Prefabs/";

		public GameObject TankPrefab { private set; get; }
		public GameObject FieldPrefab { private set; get; }
		public GameObject BrickWallPrefab { private set; get; }
		public GameObject HeadquartersPrefab { private set; get; }

		public PrefabManager ()
		{
			Load ();
		}

		private void Load ()
		{
			TankPrefab = (GameObject)Resources.Load (PREFAB_PATH + "Tank");
			FieldPrefab = (GameObject)Resources.Load (PREFAB_PATH + "Field");
			BrickWallPrefab = (GameObject)Resources.Load (PREFAB_PATH + "BrickWall");
			HeadquartersPrefab = (GameObject)Resources.Load (PREFAB_PATH + "Headquarters");
		}
	}
}
