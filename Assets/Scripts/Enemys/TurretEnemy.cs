using UnityEngine;
using System.Collections;

using Global;

public class TurretEnemy : Enemy {

	TurretEnemy()
	{
		enemyBehavior = new EnemyBehavior(new TurretBehavior());
	}
}
