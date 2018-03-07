using UnityEngine;

namespace machine.Field
{
	/// <summary>
	/// view of battle field
	/// </summary>
	public class BattleFieldView
	{
		private GameObject _object;
		public BattleFieldView (GameObject fieldPrefab)
		{
			_object = UnityEngine.Object.Instantiate (fieldPrefab);
			InitializeField ();
		}

		private void InitializeField ()
		{
			Camera camera = GameManager.MainCamera;
			SpriteRenderer fieldObject = _object.GetComponent<SpriteRenderer> ();
			fieldObject.drawMode = SpriteDrawMode.Sliced;
			//size
			float x = camera.orthographicSize * 2 * camera.aspect;
			float y = camera.orthographicSize * 2;
			fieldObject.size = new Vector2 (x, y);
		}
	}
}

