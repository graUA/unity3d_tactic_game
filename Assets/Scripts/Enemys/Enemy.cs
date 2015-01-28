using UnityEngine;
using System.Collections;

using Global;

public class Enemy : MonoBehaviour {

	public enum EnemyType {Turret = 0, Guard, Hunter};
	public EnemyType Enemys;
	public float fieldOfViewAngle;
	public float characterSpeed;

	private NavMeshAgent navAgent;
	private SphereCollider col;
	private Animator anim;
	private float destinationDistance;
	private Vector3 destinationPosition;

	void Awake()
	{
		navAgent = GetComponent<NavMeshAgent>();
		col = GetComponent<SphereCollider>();
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		if (Enemys != EnemyType.Turret)
		{
			characterSpeed = navAgent.velocity.magnitude;		
			anim.SetFloat ("Speed", characterSpeed * 0.3f);

			destinationDistance = Vector3.Distance(destinationPosition, transform.position);
			if (navAgent) {
				MoveCharacter (destinationDistance);
			}
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == Tags.heroes)
		{
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);

			if (angle < fieldOfViewAngle * 0.5f)
			{
				RaycastHit hit;
				if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
				{
					if (hit.collider.gameObject.tag == Tags.heroes)
					{
						SetDistinationPosition(other.transform.position);
					}
				}
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == Tags.heroes)
		{
			Debug.Log("Out: " + other.gameObject.name);
		}
	}

	void MoveCharacter(float destinationDistance)
	{
		if(destinationDistance > .5f)
		{
			navAgent.SetDestination(destinationPosition);
		}
		else
		{
			navAgent.ResetPath();
		}
	}

	public void SetDistinationPosition(Vector3 position)
	{
		Quaternion targetRotation = Quaternion.LookRotation(position - transform.position);
		transform.rotation = targetRotation;

		destinationPosition = position;
	}
}		