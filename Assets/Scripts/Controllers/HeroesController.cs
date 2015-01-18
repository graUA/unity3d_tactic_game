using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Global;

public class HeroesController : MonoBehaviour 
{
	List<Hero> heroes = new List<Hero>();

	private int selectebleMask;
	private float range = 100f;
	RaycastHit shootHit;
	Ray ray;

	// Use this for initialization
	void Start () 
	{
		selectebleMask = LayerMask.GetMask (Layers.heroes);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton(0))
		{
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
			if (!Input.GetKey(KeyCode.LeftShift))
			{
				ClearHeroesList();
			}

			AddNewHero(shootHit.collider.GetComponent<Hero>());
		} 
		else 
		{
			ClearHeroesList();
		}
	}


	void GetDistinationPosition()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		foreach (Hero hero in heroes)
		{
			hero.SetDistinationPosition(ray);
		}
	}

	#region Heroes Array monipulation methods:

	void AddNewHero(Hero hero)
	{
		if (!heroes.Contains(hero))
		{
			hero.SelectHero();
			heroes.Add(hero);
		}
	}

	void ClearHeroesList()
	{
		foreach (Hero hero in heroes)
		{
			hero.UnselectHero();
		}
		heroes = new List<Hero>();
	}

	#endregion

}