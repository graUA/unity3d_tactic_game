using UnityEngine;
using System.Collections;

using Global;

public class EnemyController : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ISeeHero(Enemy enemy, GameObject hero)
	{
		if (enemy.enemyType != Enemy.EnemyType.Turret)
			enemy.MoveCharacter(hero.transform.position);
	}
}
