using UnityEngine;
using System.Collections;

using Global;

[AddComponentMenu("Main/Heroes/Hero")]

public class Hero : MonoBehaviour
{
	public string Name = "Scout";

	public float speed = 7f;                    // Speed at which the character moves

	private float characterSpeed;
	private Animator anim;                      // Animator to Anim converter
	private Transform myTransform;              // this transform
	private Vector3 destinationPosition;        // The destination Point
	private float destinationDistance;          // The distance between myTransform and destinationPosition

	private SpriteRenderer selectCircle;
	
	void Awake()
	{
		characterSpeed = 0f;
		anim = GetComponent<Animator>();
		myTransform = transform;                                  // sets myTransform to this GameObject.transform
		destinationPosition = myTransform.position;
		selectCircle = GetComponentInChildren<SpriteRenderer> (); // hero select circle sprite
	}

	void FixedUpdate()
	{		
		destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);
		
		CalculateCharacterSpeed (destinationDistance);
		
		anim.SetFloat ("Speed", characterSpeed);
		
		MoveCharacter (destinationDistance);
	}

	void MoveCharacter(float destinationDistance)
	{
		if(destinationDistance > .5f)
		{
			myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, speed * Time.deltaTime * characterSpeed);
		}
	}
	
	void CalculateCharacterSpeed(float destinationDistance)
	{
		if (destinationDistance < .5f)
		{
			characterSpeed = 0f;
		}
		else if (destinationDistance < 2f)
		{
			characterSpeed = .5f;
		}
		else if (destinationDistance > 5f)
		{
			characterSpeed = 1f;
		}
	}
	
	public void SetDistinationPosition(Ray ray)
	{
		Plane playerPlane = new Plane(Vector3.up, myTransform.position);
		float hitdist = 0.0f;
		
		if (playerPlane.Raycast(ray, out hitdist))
		{
			Vector3 targetPoint = ray.GetPoint(hitdist);
			destinationPosition = ray.GetPoint(hitdist);
			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			myTransform.rotation = targetRotation;
		}
	}

	public void SelectHero()
	{
		selectCircle.enabled = true;  // show select circle
	}

	public void UnselectHero()
	{
		selectCircle.enabled = false;  // hide select circle
	}
}
