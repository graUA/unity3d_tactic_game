using UnityEngine;
using System.Collections;

using Global;

public interface IEnemyBehavior
{
	bool CanIMove();
	bool CanIRotate();
}
