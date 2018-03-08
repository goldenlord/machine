using UnityEngine;
using machine.Field;

namespace machine.Tank
{
	/// <summary>
	/// view of tank
	/// </summary>
	public class TankViewBase : FieldObjectViewBase
	{
		public TankViewBase(GameObject tankPrefab) : base (tankPrefab) {}

		public override void Move (Vector3 position, Quaternion rotation)
		{
			_object.transform.position = position;
			_object.transform.rotation = rotation;
		}
	}
}
