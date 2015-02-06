using UnityEngine;
using System.Collections;

using Global;

public interface IWeaponBehavior
{
	void Shoot();
	bool CanIShoot();
}
