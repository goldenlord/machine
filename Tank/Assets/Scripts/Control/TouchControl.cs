using UnityEngine;
using machine.Tank;

/// <summary>
/// Control tank moving
/// </summary>
public class TouchControl
{
	private TankBase _tank;

	public TouchControl (TankBase tank)
	{
		_tank = tank;
	}

	public void Update ()
	{
		MoveDirection direction = GetMoveDirection ();
		_tank.MoveTank (direction);
	}

	private MoveDirection GetMoveDirection ()
	{
		if (Input.GetKey (KeyCode.UpArrow))
		{
			return MoveDirection.UP;
		}
		else if (Input.GetKey (KeyCode.DownArrow))
		{
			return MoveDirection.DOWN;
		}
		else if (Input.GetKey (KeyCode.LeftArrow))
		{
			return MoveDirection.LEFT;
		}
		else if (Input.GetKey (KeyCode.RightArrow))
		{
			return MoveDirection.RIGHT;
		}
		return MoveDirection.NONE;
	}
}

public enum MoveDirection
{
	NONE,
	LEFT,
	RIGHT,
	UP,
	DOWN
}