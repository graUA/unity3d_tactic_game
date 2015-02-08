using UnityEngine;
using System.Collections;

using Global;

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

	private NavMeshAgent navAgent;
	
	void Awake()
	{
		characterSpeed = 0f;
		anim = GetComponent<Animator>();
		myTransform = transform;                                  // sets myTransform to this GameObject.transform
		destinationPosition = myTransform.position;
		selectCircle = GetComponentInChildren<SpriteRenderer> (); // hero select circle sprite
		navAgent = GetComponent<NavMeshAgent>();
	}

	void FixedUpdate()
	{		
		destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);
		
		characterSpeed = navAgent.velocity.magnitude;
		
		anim.SetFloat ("Speed", characterSpeed);
		
		MoveCharacter (destinationDistance);
	}

	void MoveCharacter(float destinationDistance)
	{
		if(destinationDistance > .5f && navAgent.enabled)
		{
			navAgent.SetDestination(destinationPosition);

//			myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, speed * Time.deltaTime * characterSpeed);
		}
		else
		{
			navAgent.enabled = false;
		}
	}
	
	public void SetDistinationPosition(Ray ray)
	{
		Plane playerPlane = new Plane(Vector3.up, myTransform.position);
		float hitdist = 0.0f;
		
		if (playerPlane.Raycast(ray, out hitdist))
		{
			navAgent.enabled = true;
			Vector3 targetPoint = ray.GetPoint(hitdist);
			destinationPosition = ray.GetPoint(hitdist);
			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			myTransform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 20f * Time.smoothDeltaTime);
		}
	}

	public void TakeDemage()
	{
		transform.rigidbody.AddForce(Vector3.back * 100, ForceMode.Impulse);
	}

	public void SelectHero()
	{
		if (selectCircle != null)
		{
			selectCircle.enabled = true;  // show select circle
		}
	}

	public void UnselectHero()
	{
		if (selectCircle != null)
		{
			selectCircle.enabled = false;  // hide select circle
		}
	}
}
