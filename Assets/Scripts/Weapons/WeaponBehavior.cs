using UnityEngine;
using System.Collections;

using Global;

public class WeaponBehavior
{
	private IWeaponBehavior _weaponBehavior;

	public WeaponBehavior(IWeaponBehavior weaponBehavior)
	{
		_weaponBehavior = weaponBehavior;
	}

	public void SetBehavior(IWeaponBehavior weaponBehavior)
	{
		_weaponBehavior = weaponBehavior;
	}

	public void Shoot()
	{
		_weaponBehavior.Shoot();
	}

	public bool CanIShoot()
	{
		return _weaponBehavior.CanIShoot();
	}
}
