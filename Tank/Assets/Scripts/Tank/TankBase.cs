using UnityEngine;

namespace Tank
{
	/// <summary>
	/// 坦克
	/// </summary>
	public class TankBase
	{
		public TankViewBase View { private set; get; }

		public TankBase (GameObject tankPrefab)
		{
			//view生成
			View = new TankViewBase (tankPrefab);
		}
	}
}
