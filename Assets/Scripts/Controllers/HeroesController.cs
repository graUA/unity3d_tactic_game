using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Global;

public class HeroesController : MonoBehaviour 
{
	/// <summary>
	/// The heroes.
	/// </summary>
    private List<Hero> heroes = new List<Hero>();

	/// <summary>
	/// The selected heroes.
	/// </summary>
	private List<Hero> selectedHeroes = new List<Hero>();

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
	private RaycastHit shootHit;

	/// <summary>
	/// The ray.
	/// </summary>
	private Ray ray;

	/// <summary>
	/// The user interface ctr.
	/// </summary>
	private UIController uiCtr;

	/// <summary>
	/// Delegate for on free event
	/// </summary>
	public delegate void FreeMode();
	
	/// <summary>
	/// Delegate for on followed event
	/// </summary>
	public delegate void FollowMode(GameObject target);
	
	/// <summary>
	/// Occurs when on follow mode.
	/// </summary>
	public static event FollowMode onFollowMode;
	
	/// <summary>
	/// Occurs when on free mode.
	/// </summary>
	public static event FreeMode onFreeMode;
	
	/// <summary>
	/// The is follow mode presented.
	/// </summary>
	private bool isFollowMode = false;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() 
	{
        foreach (GameObject hero in GameObject.FindGameObjectsWithTag(Tags.heroes))
        {
            heroes.Add(hero.GetComponent<Hero>());
        }

		selectebleMask = LayerMask.GetMask(Layers.heroes);
		uiCtr = GetComponent<UIController>();
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () 
	{
		if (InputManager.Fire1() && !InputManager.Shift() && !isFollowMode)
		{
			SelectHero();
			SelectHeroBySelectionFrame();
		}
		if (InputManager.Fire2())
		{
			GetDistinationPosition();
		}
		if (InputManager.Shift() && selectedHeroes.Count > 0)
		{
			SetHeroOrientation();
			if (InputManager.Fire1())
			{
				HeroMustShoot();
			}
		}
        else
        {
            if (selectedHeroes.Count > 0)
            {
                Hero hero = selectedHeroes[0];
                hero.readyToShoot = false;
            }
        }
		if (InputManager.Follow())
		{
			SetUpCameraMode();
		}
	}

	/// <summary>
	/// Sets up camera mode.
	/// </summary>
	void SetUpCameraMode()
	{
		if (onFollowMode != null && selectedHeroes.Count > 0 && !isFollowMode)
		{
			onFollowMode(selectedHeroes[0].gameObject);
			isFollowMode = true;
		}
		else if (onFreeMode != null)
		{
			onFreeMode();
			isFollowMode = false;
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
            camPos.y = SelectionFrameCamera.InvertMouseY(camPos.y);

			if (SelectionFrameCamera.selection.Contains(camPos, true))
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
			if (!InputManager.Shift())
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

    void SetHeroOrientation()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Hero hero = selectedHeroes[0];
		hero.OrientateHero(ray);
        hero.readyToShoot = true;
	}

	void HeroMustShoot()
	{
		Hero hero = selectedHeroes[0];
		hero.AttackCharacter();
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
		selectedHeroes.Clear();
	}

	#endregion

}