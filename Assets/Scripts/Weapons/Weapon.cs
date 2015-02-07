using UnityEngine;
using System.Collections;

using Global;

public class Weapon : MonoBehaviour 
{
	public float shotDamage = 10f;
	public int ammoCount = 10;
	public int ammoInStack = 5;
	public GameObject shotPointObject;
	public float timeBetweenBullets = 1f;
	public float range = 100f;
	public float timerBetweenReload = 5f;
	
	float timer;
	float reloadTimer;
	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;
	ParticleSystem gunParticles;
	LineRenderer gunLine;
	AudioSource gunAudio;
	Light gunLight;
	float effectsDisplayTime = 0.05f;

	protected WeaponBehavior weaponBehavior;
	protected int unitAmmoCount = 0;

	// Use this for initialization
	void Awake () {
		shootableMask = LayerMask.GetMask (Layers.heroes);
		
		// Set up the references.
		gunParticles = GetComponent<ParticleSystem> ();
		gunLine = GetComponent <LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		gunLight = GetComponent<Light> ();

		timer = timeBetweenBullets;
		reloadTimer = timerBetweenReload;
	}

	void Update ()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;
		reloadTimer += Time.deltaTime;
		
		// If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
		if(timer >= effectsDisplayTime)
		{
			// ... disable the effects.
			DisableEffects ();
		}
	}
	
	protected void DisableEffects()
	{
		// Disable the line renderer and the light.
		gunLine.enabled = false;
		gunLight.enabled = false;
	}

	protected void PlayEffects()
	{
		// Play the gun shot audioclip.
		gunAudio.Play ();

		// Enable the light.
		gunLight.enabled = true;

		// Stop the particles from playing if they were, then start the particles.
		gunParticles.Stop ();
		gunParticles.Play ();
		
		// Enable the line renderer and set it's first position to be the end of the gun.
		gunLine.enabled = true;
	}

	protected void Reloading()
	{
		if ((ammoCount - ammoInStack) > 0)
		{
			unitAmmoCount = ammoInStack;
			ammoCount -= ammoInStack;
		}
		else
		{
			unitAmmoCount = ammoCount;
			ammoCount = 0;
		}
	}

	public void Shoot()
	{
		if (timer >= timeBetweenBullets && weaponBehavior.CanIShoot()) 
		{
			if (unitAmmoCount > 0)
			{
				unitAmmoCount--;

				timer = 0f;
				reloadTimer = 0;

				// Enable gunLine, gunLight and Play gunAudio.
				PlayEffects();

				gunLine.SetPosition (0, transform.position);
				
				// Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
				shootRay.origin = transform.position;
				shootRay.direction = transform.forward;
				
				// Perform the raycast against gameobjects on the shootable layer and if it hits something...
				if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
				{
					Hero hero = shootHit.collider.GetComponent <Hero> ();
					hero.TakeDemage();
					gunLine.SetPosition (1, shootHit.point);
				}
				else
				{
					gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
				}
			}
			else if (reloadTimer >= timerBetweenReload)
			{
				Reloading();
			}
		}
	}
}
