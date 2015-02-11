using UnityEngine;
using System.Collections;

public class FreeCamera : CameraDecorator
{	
	// Border on screen edges where we can move the camera
	private static int ACTIVE_SCREEN_BORDER_WIDTH = 5;

	// Camera movement speed
	private float speed;
	
	// Scene limits
	private int minX, minZ, maxX, maxZ;

	// Game object transformation
	private readonly Transform transform;

	public FreeCamera(Transform transform, int minX, int minZ, int maxX, int maxZ, float movementSpeed)
	{
		this.transform = transform;

		this.minX = minX;
		this.maxX = maxX;
		this.minZ = minZ;
		this.maxZ = maxZ;
		this.speed = movementSpeed;
	}

	public override void Update()
	{
		base.Update();
		UpdateCamera();
	}

	// Update сamera by mouse or by keyborad
	private void UpdateCamera()
	{
		if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
		{
			MoveCameraByMouse(Input.mousePosition.x, Input.mousePosition.y);
		}
		
		MoveCameraByKeys();
	}

	// Move camera by mouse
	private void MoveCameraByMouse(float mouseX, float mouseY)
	{
		var previousPosition = transform.position;
		
		if (mouseX < ACTIVE_SCREEN_BORDER_WIDTH)
		{
			transform.Translate(Vector3.right * -speed * Time.deltaTime);
		}
		if (mouseX >= Screen.width - ACTIVE_SCREEN_BORDER_WIDTH)
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
		if (mouseY < ACTIVE_SCREEN_BORDER_WIDTH)
		{
			transform.Translate(Vector3.forward * -speed * Time.deltaTime);
		}
		if (mouseY >= Screen.height - ACTIVE_SCREEN_BORDER_WIDTH)
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		LimitCamera(previousPosition, transform.position);
	}

	// Move camera by keyborad arrows
	private void MoveCameraByKeys()
	{
		var previousPosition = transform.position;

		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(Vector3.back * speed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		LimitCamera(previousPosition, transform.position);
	}

	// Setup camera limits
	private void LimitCamera(Vector3 previousPosition, Vector3 currentPosition)
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
}
