using UnityEngine;
using System.Collections;

public class CameraTarget : MonoBehaviour {
    
	// Camera movement speed
    public float _MoveSpeed;

	// Scene limits
	public int _MinX, _MinZ, _MaxX, _MaxZ;

    // Border on screen edges where we can move the camera
    private int _Border = 5;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		moveCamera (Input.mousePosition.x, Input.mousePosition.y);

		// TODO: ZOOM
		// TODO: ROTATION
	}
	
	// Move camera nothing more
	private void moveCamera (float mouseX, float mouseY) {
		var previousPosition = transform.position;

		if (mouseX < _Border) {
			transform.Translate(Vector3.right * -_MoveSpeed * Time.deltaTime);
		}
		if (mouseX >= Screen.width - _Border) {
			transform.Translate(Vector3.right * _MoveSpeed * Time.deltaTime);
		}
		if (mouseY < _Border) {
			transform.Translate(Vector3.forward * -_MoveSpeed * Time.deltaTime);
		}
		if (mouseY >= Screen.height - _Border) {
			transform.Translate(Vector3.forward * _MoveSpeed * Time.deltaTime);
		}

		preventInfiniteMovingOfCamera (previousPosition, transform.position);
	}

	// Stop camera when it reaches scene limits and return it to the previous position 
	private void preventInfiniteMovingOfCamera (Vector3 previousPosition, Vector3 currentPosition) {
		if (currentPosition.z < _MinZ || currentPosition.z > _MaxZ) {
			transform.position = previousPosition;
		}
		if (currentPosition.x < _MinX || currentPosition.x > _MaxX) {
			transform.position = previousPosition;
		}
	}
}
