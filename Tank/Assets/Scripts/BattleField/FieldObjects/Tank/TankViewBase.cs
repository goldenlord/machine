using UnityEngine;
using machine.Field;

namespace machine.Tank
{
	/// <summary>
	/// view of tank
	/// </summary>
	public class TankViewBase : FieldObjectViewBase
	{
		public Vector3 Rotation { get { return _object.transform.rotation.eulerAngles; }}
		public TankViewBase(GameObject tankPrefab) : base (tankPrefab) {}
	}
}
