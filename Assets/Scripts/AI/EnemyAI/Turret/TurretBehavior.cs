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

	public bool CanShotBeSuccess(Transform transformA, Transform transformB, float maxAngle)
	{
		float angle = HelperTrans.angleBetwineTwoTransforms(transformA, transformB);
		return (angle < maxAngle * 0.5f) ? true : false;
	}
}
