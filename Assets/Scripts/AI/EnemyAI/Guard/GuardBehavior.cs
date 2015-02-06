using UnityEngine;
using System.Collections;

using Global;

public class GuardBehavior : IEnemyBehavior
{
	public bool CanIMove()
	{
		return true;
	}

	public bool CanIRotate()
	{
		return false;
	}
}
