using UnityEngine;
using System.Collections;

using Global;

public class WeaponFactory : MonoBehaviour 
{

	public GameObject revolver;
	public GameObject shotgun;	
	
	public GameObject getWeapon(WeaponType weaponType, Transform deployTransform)
	{
		GameObject tragetWeapon;
		
		switch (weaponType)
		{
		case WeaponType.Revolver:
			tragetWeapon = revolver;
			break;

		case WeaponType.Shotgun:
			tragetWeapon = shotgun;
			break;
			
		default:
			tragetWeapon = revolver;
			break;
		}
		
		return (GameObject)Instantiate (tragetWeapon, deployTransform.position, deployTransform.rotation);
	}
}
