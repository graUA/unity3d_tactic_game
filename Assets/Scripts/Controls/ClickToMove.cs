using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour
{
	public float speed = 7f;                         // Speed at which the character moves

	private float characterSpeed;
	private Animator anim;                     // Animator to Anim converter
	private Transform myTransform;              // this transform
	private Vector3 destinationPosition;        // The destination Point
	private float destinationDistance;          // The distance between myTransform and destinationPosition
    
    // Use this for initialization
    void Awake()
    {
		characterSpeed = 0f;
		anim = GetComponent<Animator>();
		myTransform = transform;                            // sets myTransform to this GameObject.transform
		destinationPosition = myTransform.position;
    }

    // Update is called once per frame
	void FixedUpdate()
    {		
		destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);

		CalculateCharacterSpeed (destinationDistance);

		anim.SetFloat ("Speed", characterSpeed);
		
		// Moves the Player if the Left Mouse Button was clicked
		if (Input.GetMouseButtonDown(1))
		{			
			GetDistinationPosition();
		}
		
		// Moves the player if the mouse button is hold down
		else if (Input.GetMouseButton(1))
		{			
			GetDistinationPosition();
		}

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

	void GetDistinationPosition()
	{
		Plane playerPlane = new Plane(Vector3.up, myTransform.position);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float hitdist = 0.0f;
		
		if (playerPlane.Raycast(ray, out hitdist))
		{
			Vector3 targetPoint = ray.GetPoint(hitdist);
			destinationPosition = ray.GetPoint(hitdist);
			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			myTransform.rotation = targetRotation;
		}
	}
}
