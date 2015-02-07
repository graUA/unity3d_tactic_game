using UnityEngine;
using System.Collections;

using Global;

public class Revolver : Weapon 
{
	Revolver()
	{
		weaponBehavior = new WeaponBehavior(new RevolverBehavior());
	}
}
