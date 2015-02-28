using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Global;

public class HeroesController : MonoBehaviour 
{
	/// <summary>
	/// Delegate for on camera followed event
	/// </summary>
	public delegate void CameraFollowMode(GameObject target);

	/// <summary>
	/// Occurs when on camera followed.
	/// </summary>
	public static event CameraFollowMode onFollowCamera;

	/// <summary>
	/// The heroes.
	/// </summary>
    List<Hero> heroes = new List<Hero>();

	/// <summary>
	/// The selected heroes.
	/// </summary>
	List<Hero> selectedHeroes = new List<Hero>();

	/// <summary>
	/// The selecteble mask.
	/// </summary>
	private int selectebleMask;

	/// <summary>
	/// The range.
	/// </summary>
	private float range = 100f;

	/// <summary>
	/// The shoot hit.
	/// </summary>
	RaycastHit shootHit;

	/// <summary>
	/// The ray.
	/// </summary>
	Ray ray;

	/// <summary>
	/// The user interface ctr.
	/// </summary>
	UIController uiCtr;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () 
	{
        foreach (GameObject hero in GameObject.FindGameObjectsWithTag(Tags.heroes))
        {
            heroes.Add(hero.GetComponent<Hero>());
        }

		selectebleMask = LayerMask.GetMask (Layers.heroes);
		uiCtr = GetComponent<UIController>();
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () 
	{
		if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftShift))
		{
			SelectHero();
			SelectHeroBySelectionFrame();
		}
		if (Input.GetMouseButton(1))
		{
			GetDistinationPosition();
		}
		if (Input.GetKey(KeyCode.LeftShift) && selectedHeroes.Count > 0)
		{
			SetHeroRatation();
			if (Input.GetMouseButton(0))
			{
				HeroMustShoot();
			}
		}
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.F))
		{
			SetUpFollowMode();
		}
	}

	/// <summary>
	/// Sets up follow mode.
	/// </summary>
	void SetUpFollowMode()
	{
		if (onFollowCamera != null && selectedHeroes.Count > 0)
		{
			onFollowCamera(selectedHeroes[0].gameObject);
		}
	}

	/// <summary>
	/// Check heroes and select those are under selection frame
	/// </summary>
    void SelectHeroBySelectionFrame()
    {
        foreach (Hero hero in heroes)
        {
            Vector3 camPos = Camera.main.WorldToScreenPoint(hero.transform.position);
            camPos.y = CameraSelectionFrame.InvertMouseY(camPos.y);

			if (CameraSelectionFrame.selection.Contains(camPos, true))
            {
                AddNewHero(hero);
            }
        }
    }

	/// <summary>
	/// Selects the hero.
	/// </summary>
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

	/// <summary>
	/// Gets the distination position.
	/// </summary>
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

	void SetHeroRatation()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Hero hero = selectedHeroes[0];
		hero.RotateHero(ray);
	}

	void HeroMustShoot()
	{
		Hero hero = selectedHeroes[0];
		hero.AttackCharacter(null);
	}

	#region Heroes Array monipulation methods:

	/// <summary>
	/// Adds the new hero.
	/// </summary>
	/// <param name="hero">Hero.</param>
	void AddNewHero(Hero hero)
	{
		if (!selectedHeroes.Contains(hero))
		{
			hero.SelectHero();
			selectedHeroes.Add(hero);
		}
	}

	/// <summary>
	/// Clears the heroes list.
	/// </summary>
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