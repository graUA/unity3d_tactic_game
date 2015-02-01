using UnityEngine;
using System.Collections;

using Global;

public class Enemy : MonoBehaviour
{
	
	public float fieldOfViewAngle;
	public float speed;
	public enum EnemyType {Turret = 0, Guard, Hunter};
	public EnemyType enemyType;

	private NavMeshAgent navAgent;
	private SphereCollider col;
	private Animator anim;
	private GameObject GM;				// Game Manager Object
	private EnemyController EC;         // EnemyController Class

	public void Awake()
	{
		navAgent = GetComponent<NavMeshAgent>();
		col = GetComponent<SphereCollider>();
		anim = GetComponent<Animator>();
		GM = GameObject.FindGameObjectWithTag(Tags.gameManager);
		EC = GM.GetComponent<EnemyController>();
	}

	void Update()
	{
		if (navAgent)
			speed = navAgent.velocity.magnitude;

		if (anim)
			RuntimeAnimation();
	}

	void OnTriggerStay(Collider other)
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
						EC.ISeeHero(this, other.gameObject);
					}
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == Tags.heroes)
		{
			Debug.Log("Out: " + other.gameObject.name);
		}
	}

	public void MoveCharacter(Vector3 destinationPosition)
	{
		float destinationDistance = Vector3.Distance(destinationPosition, transform.position);

		if (destinationDistance > .5f)
		{
			navAgent.SetDestination(destinationPosition);
		}
		else
		{
			navAgent.Stop();
		}
	}

	void RuntimeAnimation()
	{

	}
}		