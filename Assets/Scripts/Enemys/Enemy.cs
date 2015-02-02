﻿using UnityEngine;
using System.Collections;

using Global;

public class Enemy : MonoBehaviour
{
	
	public float fieldOfViewAngle;
	public float speed;

	protected NavMeshAgent navAgent;
	protected EnemyBehavior enemyBehavior;
	protected SphereCollider col;
	protected Animator anim;
	protected GameObject GM;				// Game Manager Object
	protected EnemyController EC;         // EnemyController Class

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

	// Main Actions Methods:

	public void MoveCharacter(Vector3 destinationPosition)
	{
		float destinationDistance = Vector3.Distance(destinationPosition, transform.position);

		if (destinationDistance > .5f && enemyBehavior.CanIMove())
		{
			navAgent.SetDestination(destinationPosition);
		}
	}

	public void RotateCharacter(Vector3 position)
	{
		if (enemyBehavior.CanIRotate())
		{
			Quaternion targetRotation = Quaternion.LookRotation(position - transform.position);
			transform.rotation = targetRotation;
		}
	}

	public void AttackCharacter(GameObject hero)
	{
		Debug.Log("FIRE!!!");
	}

	// Virtual Methods:
	public virtual void RuntimeAnimation(){}
}		