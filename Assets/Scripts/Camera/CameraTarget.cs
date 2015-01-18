using UnityEngine;
using System.Collections;

public class CameraTarget : MonoBehaviour
{

    // Border on screen edges where we can move the camera
    private static int ACTIVE_SCREEN_BORDER_WIDTH = 5;

    // Camera movement speed
    public float movementSpeed;

    // Scene limits
    public int minX, minZ, maxX, maxZ;

    // Camera zooming limits
    public int zoomMin, zoomMax;

    // Camera zooming speed
    public float zoomSpeed;

    // Camera rotation speed
    public float rotateSpeed;

    // Mouse x position for camera rotation
    private float mouseXPositionForRotation;

    // Use this for initialization
    void Start()
    {
        // initialize something
    }

    // Update is called once per frame
    void Update()
    {
		updateCamera ();
        zoomCamera();
        rotateCamera();
    }

    // Update is called once per frame after Update() was called
    void LateUpdate()
    {
        mouseXPositionForRotation = Input.mousePosition.x;
    }

    // Move camera by mouse
    private void moveCameraByMouse(float mouseX, float mouseY)
    {
        var previousPosition = transform.position;

        if (mouseX < ACTIVE_SCREEN_BORDER_WIDTH)
        {
            transform.Translate(Vector3.right * -movementSpeed * Time.deltaTime);
        }
        if (mouseX >= Screen.width - ACTIVE_SCREEN_BORDER_WIDTH)
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }
        if (mouseY < ACTIVE_SCREEN_BORDER_WIDTH)
        {
            transform.Translate(Vector3.forward * -movementSpeed * Time.deltaTime);
        }
        if (mouseY >= Screen.height - ACTIVE_SCREEN_BORDER_WIDTH)
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }

        preventInfiniteMovingOfCamera(previousPosition, transform.position);
    }

	private void updateCamera()
	{
		if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow)) {
						moveCameraByMouse (Input.mousePosition.x, Input.mousePosition.y);
				}
		moveCameraByKeys ();
	}

	// Move camera by keys
	private void moveCameraByKeys()
	{
		var previousPosition = transform.position;
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
		}

		preventInfiniteMovingOfCamera(previousPosition, transform.position);
	}

    // Stop camera when it reaches scene limits and return it to the previous position 
    private void preventInfiniteMovingOfCamera(Vector3 previousPosition, Vector3 currentPosition)
    {
        if (currentPosition.z < minZ || currentPosition.z > maxZ)
        {
            transform.position = previousPosition;
        }
        if (currentPosition.x < minX || currentPosition.x > maxX)
        {
            transform.position = previousPosition;
        }
    }

    // Zoom camera by scrolling the wheel
    private void zoomCamera()
    {
        if (transform.position.y > zoomMin && Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.Translate(0, -zoomSpeed, zoomSpeed);
        }
        if (transform.position.y < zoomMax && Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.Translate(0, zoomSpeed, -zoomSpeed);
        }
    }

    // Rotate camera by shift + right mouse button
    private void rotateCamera()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButton(1))
        {
            if (Input.mousePosition.x != mouseXPositionForRotation)
            {
                var rotation = (Input.mousePosition.x - mouseXPositionForRotation) * rotateSpeed * Time.deltaTime;
                transform.Rotate(0, rotation, 0);
            }
        }
    }
}
