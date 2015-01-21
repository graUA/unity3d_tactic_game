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

    // Camera Selection Frame
    public Texture2D selection_frame = null;
    public static Rect selection = new Rect(0, 0, 0, 0);
    private Vector3 startClick = -Vector3.one;

    // Update is called once per frame
    void Update()
    {
		UpdateCamera ();
        ZoomCamera();
        RotateCamera();
        CheckCameraAndDrawSelectionFrame();
    }

    // Update is called once per frame after Update() was called
    void LateUpdate()
    {
        mouseXPositionForRotation = Input.mousePosition.x;
    }

    void OnGUI()
    {
        if (startClick != -Vector3.one)
        {
            GUI.color = new Color(1, 1, 1, 0.2f);
            GUI.DrawTexture(selection, selection_frame);
        }
    }

    private void CheckCameraAndDrawSelectionFrame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startClick = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (selection.width < 0)
            {
                selection.x += selection.width;
                selection.width = -selection.width;
            }
            if (selection.height < 0)
            {
                selection.y += selection.height;
                selection.height = -selection.height;
            }
            startClick = -Vector3.one;
        }

        if (Input.GetMouseButton(0))
        {
            selection = new Rect(
                startClick.x,
                InvertMouseY(startClick.y),
                Input.mousePosition.x - startClick.x,
                InvertMouseY(Input.mousePosition.y) - InvertMouseY(startClick.y));
        }
    }

    public static float InvertMouseY(float y)
    {
        return Screen.height - y;
    }

    // Move camera by mouse
    private void MoveCameraByMouse(float mouseX, float mouseY)
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

        PreventInfiniteMovingOfCamera(previousPosition, transform.position);
    }

	private void UpdateCamera()
	{
		if (!Input.GetKey(KeyCode.RightArrow) &&
            !Input.GetKey(KeyCode.LeftArrow) &&
            !Input.GetKey(KeyCode.DownArrow) &&
            !Input.GetKey(KeyCode.UpArrow)) {
			
            MoveCameraByMouse(Input.mousePosition.x, Input.mousePosition.y);
		}

		MoveCameraByKeys ();
	}

	// Move camera by keys
	private void MoveCameraByKeys()
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

		PreventInfiniteMovingOfCamera(previousPosition, transform.position);
	}

    // Stop camera when it reaches scene limits and return it to the previous position 
    private void PreventInfiniteMovingOfCamera(Vector3 previousPosition, Vector3 currentPosition)
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
    private void ZoomCamera()
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
    private void RotateCamera()
    {
        if (Input.GetMouseButton(2))
        {
            if (Input.mousePosition.x != mouseXPositionForRotation)
            {
                var rotation = (Input.mousePosition.x - mouseXPositionForRotation) * rotateSpeed * Time.deltaTime;
                transform.Rotate(0, rotation, 0);
            }
        }
    }
}
