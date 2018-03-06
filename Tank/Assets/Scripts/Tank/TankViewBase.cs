using UnityEngine;

namespace Tank
{
	public class TankViewBase
	{
		private GameObject _object;

		public TankViewBase(GameObject tankPrefab)
		{
			_object = UnityEngine.Object.Instantiate (tankPrefab);
		}

		public void SetPosition (float x, float y)
		{
			_object.transform.position = new Vector3 (x, y, 0f);
		}
	}

	public enum MoveDirection
	{
		LEFT,
		RIGHT,
		UP,
		DOWN
	}
}
