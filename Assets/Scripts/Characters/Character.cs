using UnityEngine;
using System.Collections;

using Global;

public class Character : MonoBehaviour
{
	public GameObject weaponDeploy;
	public WeaponType curWeaponType = WeaponType.Revolver;

	protected NavMeshAgent navAgent;
	protected Animator anim;
	protected GameObject GM;				// Game Manager Object
	protected EnemyController EC;         // EnemyController Class
	protected GameObject curWeapon;
	protected Weapon GUN;

	public void Init()
	{
		navAgent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		GM = GameObject.FindGameObjectWithTag(Tags.gameManager);
		EC = GM.GetComponent<EnemyController>();
		//
		curWeapon = GM.GetComponent<WeaponFactory>().getWeapon(curWeaponType, weaponDeploy.transform);
		curWeapon.transform.parent = weaponDeploy.transform;
		GUN = curWeapon.GetComponent<Weapon>();
	}

	public void AttackCharacter(GameObject hero)
	{
		GUN.Shoot();
	}
}
