using UnityEngine;
using System.Collections;

using Global;

public class TurretBehavior : IEnemyBehavior
{
	public bool CanIMove()
	{
		return false;
	}

	public bool CanIRotate()
	{
		return true;
	}
}
