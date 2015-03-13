using UnityEngine;
using System.Collections;

using Global;

public class Character : MonoBehaviour
{
	public GameObject weaponDeploy;
	public Weapon.WeaponType curWeaponType = Weapon.WeaponType.None;

	protected NavMeshAgent navAgent;
	protected Animator anim;
	protected GameObject GM;				// Game Manager Object
	protected EnemyController EC;         // EnemyController Class
	protected GameObject curWeapon;
	protected Weapon GUN;

	protected virtual void Init()
	{
		navAgent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		GM = GameObject.FindGameObjectWithTag(Tags.gameManager);
		EC = GM.GetComponent<EnemyController>();
		//
		EquipWeapon(curWeaponType);
	}

	public void AttackCharacter(GameObject hero)
	{
		ShootFromCurGun();
	}

	public void AttackCharacter()
	{
		ShootFromCurGun();
	}

	protected void ShootFromCurGun()
	{
		if (!GUN)
			return;
		
		GUN.Shoot();
	}

	public void EquipWeapon(Weapon.WeaponType wType)
	{
		if (curWeapon && curWeaponType == wType)
		{
			return;
		}

		curWeaponType = wType;

		Destroy(curWeapon);
		curWeapon = null;
		GUN = null;

		if (curWeaponType != Weapon.WeaponType.None)
		{
			curWeapon = GM.GetComponent<WeaponFactory>().getWeapon(curWeaponType, weaponDeploy.transform);
			curWeapon.transform.parent = weaponDeploy.transform;
			GUN = curWeapon.GetComponent<Weapon>();
		}
	}
}
