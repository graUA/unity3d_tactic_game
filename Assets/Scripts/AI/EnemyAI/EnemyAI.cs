using UnityEngine;
using System.Collections;

using Global;

#region Enemy Behavior Interface

public interface IEnemyBehavior
{
	bool CanIMove();
	bool CanIRotate();
}

#endregion

#region Enemy Behavior Context

public class EnemyBehavior
{
	private IEnemyBehavior _enemyBehavior;

	public EnemyBehavior(IEnemyBehavior enemyBehavior)
	{
		_enemyBehavior = enemyBehavior;
	}

	public void SetBehavior(IEnemyBehavior enemyBehavior)
	{
		_enemyBehavior = enemyBehavior;
	}

	public bool CanIMove()
	{
		return _enemyBehavior.CanIMove();
	}

	public bool CanIRotate()
	{
		return _enemyBehavior.CanIRotate();
	}
}

#endregion

#region Enemy Behavior Strategie Turret

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

#endregion

#region #region Enemy Behavior Strategie Guard

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

#endregion
