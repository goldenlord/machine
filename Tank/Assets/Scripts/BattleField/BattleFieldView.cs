using UnityEngine;

namespace machine.Field
{
	/// <summary>
	/// view of battle field
	/// </summary>
	public class BattleFieldView
	{
		private GameObject _object;

		public float FieldWidth { private set; get; }
		public float FieldHeight { private set; get; }

		public BattleFieldView (GameObject fieldPrefab)
		{
			_object = UnityEngine.Object.Instantiate (fieldPrefab);
			Initialize ();
		}

		private void Initialize ()
		{
			Camera camera = GameManager.MainCamera;
			SpriteRenderer backGround = _object.GetComponent<SpriteRenderer> ();
			backGround.drawMode = SpriteDrawMode.Sliced;
			//size
			FieldWidth = camera.orthographicSize * 2 * camera.aspect;
			FieldHeight = camera.orthographicSize * 2;
			backGround.size = new Vector2 (FieldWidth, FieldHeight);
		}
	}
}

