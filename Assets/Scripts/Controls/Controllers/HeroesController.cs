using UnityEngine;
using System.Collections;

using Global;

public class HeroesController : MonoBehaviour 
{
 	Hero[] heroes = new Hero[3];

	private int selectebleMask;
	private float range = 100f;
	RaycastHit shootHit;
	Ray ray;

	// Use this for initialization
	void Start () 
	{
		selectebleMask = LayerMask.GetMask ("Heroes");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton(0))
		{		
			Debug.Log("Click");
			SelectHero();
		}

		if (Input.GetMouseButton(1))
		{
			GetDistinationPosition();
		}
	}

	void SelectHero()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast (ray, out shootHit, range, selectebleMask)) {	
			heroes [0] = shootHit.collider.GetComponent<Hero> ();
			heroes [0].SelectHero ();
		} 
		else 
		{
			if (heroes[0])
			{
				heroes [0].UnselectHero ();
				heroes = new Hero[3];
			}
		}
	}


	void GetDistinationPosition()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (heroes[0])
		{
			heroes[0].SetDistinationPosition(ray);
		}
	}

}