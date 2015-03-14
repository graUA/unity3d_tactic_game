using UnityEngine;
using System.Collections;

using Global;

public class Shotgun : Weapon 
{
	Shotgun()
	{
		weaponBehavior = new WeaponBehavior(new ShotgunBehavior());
	}
}
