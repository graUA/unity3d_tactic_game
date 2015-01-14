using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	public CharacterController controller;
	public float speed = 10f;
	private Vector3 clickPosition;
	// Use this for initialization
	void Start () {
		clickPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton(1)) {
			// Locate a palyer click:
			LocateClickPosition ();
		}

		// Move player to the clickPosition:
		MoveToPosition ();
	}

	void LocateClickPosition () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast(ray, out hit, 1000)) {
			clickPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
			Debug.Log(clickPosition);
		}
	}

	void MoveToPosition () {
		if (Vector3.Distance (transform.position, clickPosition) > 1) {
			Quaternion newRotation = Quaternion.LookRotation (clickPosition - transform.position);

			newRotation.x = 0f;
			newRotation.z = 0f;

			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 10);
			controller.SimpleMove (transform.forward * speed);
		}
	}
}
