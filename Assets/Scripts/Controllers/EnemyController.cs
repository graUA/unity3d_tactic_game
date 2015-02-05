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
		enemy.MoveCharacter(hero.transform.position);
		enemy.RotateCharacter(hero.transform.position);
		enemy.AttackCharacter(hero);
	}
}
