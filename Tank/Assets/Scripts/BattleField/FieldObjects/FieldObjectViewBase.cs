using UnityEngine;

namespace machine.Field
{
	public class FieldObjectViewBase
	{
		protected const float DEFAULT_Z = -1f;
		protected virtual float DefaultSize { get { return 250f; } }
		protected GameObject _object;
		public Vector2 Size { private set; get; }
		public Vector3 Position {get { return _object.transform.position; }}

		public FieldObjectViewBase () {}

		public FieldObjectViewBase (GameObject prefab)
		{
			_object = UnityEngine.Object.Instantiate (prefab);
			Size = new Vector2 (DefaultSize, DefaultSize);
			Initialize ();
		}

		protected virtual void Initialize ()
		{
			SpriteRenderer sprite = _object.GetComponent<SpriteRenderer> ();
			sprite.drawMode = SpriteDrawMode.Sliced;
			sprite.size = Size;
		}

		public void SetPosition (float x, float y)
		{
			_object.transform.position = new Vector3 (x, y, DEFAULT_Z);
		}

		public virtual void Move (Vector3 position, Quaternion rotation) {}
	}
}
