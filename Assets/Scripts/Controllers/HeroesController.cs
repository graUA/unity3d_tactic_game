using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Global;

public class HeroesController : MonoBehaviour 
{
    List<Hero> heroes = new List<Hero>();
	List<Hero> selectedHeroes = new List<Hero>();

	private int selectebleMask;
	private float range = 100f;
	RaycastHit shootHit;
	Ray ray;
	UIController uiCtr;

	// Use this for initialization
	void Start () 
	{
        foreach (GameObject hero in GameObject.FindGameObjectsWithTag(Tags.heroes))
        {
            heroes.Add(hero.GetComponent<Hero>());
        }

		selectebleMask = LayerMask.GetMask (Layers.heroes);
		uiCtr = GetComponent<UIController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (Input.GetMouseButton(0))
		{
			SelectHero();
            SelectHeroBySelectionFrame();
		}

		if (Input.GetMouseButton(1))
		{
			GetDistinationPosition();
		}

		if (Input.GetKey(KeyCode.LeftShift)
		    && Input.GetKey(KeyCode.LeftControl)
		    && Input.GetKey(KeyCode.F))
		{
			SetUpFollowMode();
		}
	}

	void SetUpFollowMode()
	{
		if (selectedHeroes.Count > 0)
			CameraTarget.SetFollowCamera(selectedHeroes[0].gameObject);
	}

	// Check heroes and select those are under selection frame
    void SelectHeroBySelectionFrame()
    {
        foreach (Hero hero in heroes)
        {
            Vector3 camPos = Camera.main.WorldToScreenPoint(hero.transform.position);
            camPos.y = CameraTarget.InvertMouseY(camPos.y);

            if (CameraTarget.selection.Contains(camPos, true))
            {
                AddNewHero(hero);
            }
        }
    }

	void SelectHero()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out shootHit, range, selectebleMask)) {
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

		if (selectedHeroes.Count > 0)
		{
			uiCtr.HighlightDestinationPoint(ray);
		}

		foreach (Hero hero in selectedHeroes)
		{
			hero.SetDistinationPosition(ray);
		}
	}

	#region Heroes Array monipulation methods:

	void AddNewHero(Hero hero)
	{
		if (!selectedHeroes.Contains(hero))
		{
			hero.SelectHero();
			selectedHeroes.Add(hero);
		}
	}

	void ClearHeroesList()
	{
		foreach (Hero hero in selectedHeroes)
		{
			hero.UnselectHero();
		}
		selectedHeroes = new List<Hero>();
	}

	#endregion

}