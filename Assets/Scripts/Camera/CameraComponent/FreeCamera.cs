using UnityEngine;
using System.Collections;

public class FreeCamera : CameraDecorator
{	
	/// <summary>
	/// The active screen border width
	/// </summary>
	private static int ACTIVE_SCREEN_BORDER_WIDTH = 5;

	/// <summary>
	/// The transform.
	/// </summary>
	private Transform transform;

	/// <summary>
	/// Camera moving speed
	/// </summary>
	private float speed;
	
	/// <summary>
	/// Camera moving limits
	/// </summary>
	private int minX, minZ, maxX, maxZ;
	
	/// <summary>
	/// Initializes a new instance of the <see cref="FreeCamera"/> class.
	/// </summary>
	/// <param name="camera">Camera.</param>
	/// <param name="minX">Minimum x.</param>
	/// <param name="minZ">Minimum z.</param>
	/// <param name="maxX">Max x.</param>
	/// <param name="maxZ">Max z.</param>
	/// <param name="movementSpeed">Movement speed.</param>
	public FreeCamera(CameraBase camera, int minX, int minZ, int maxX, int maxZ, float movementSpeed) : base(camera)
	{
		this.transform = camera.getCameraGameObject().transform;
		this.minX = minX;
		this.maxX = maxX;
		this.minZ = minZ;
		this.maxZ = maxZ;
		this.speed = movementSpeed;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	public override void Update()
	{
		base.Update();
		UpdateCamera();
	}

	/// <summary>
	/// Updates the camera.
	/// </summary>
	private void UpdateCamera()
	{
		if (InputManager.HorizontalAxis() == 0 && InputManager.VerticalAxis() == 0) {
			MoveCameraByMouse(Input.mousePosition.x, Input.mousePosition.y);
		}

		MoveCameraByKeys();
	}

	/// <summary>
	/// Moves the camera by mouse.
	/// </summary>
	/// <param name="mouseX">Mouse x.</param>
	/// <param name="mouseY">Mouse y.</param>
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

	/// <summary>
	/// Moves the camera by keys.
	/// </summary>
	private void MoveCameraByKeys()
	{
		var previousPosition = transform.position;

		if (InputManager.HorizontalAxis() > 0)
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
		if (InputManager.HorizontalAxis() < 0)
		{
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}
		if (InputManager.VerticalAxis() < 0)
		{
			transform.Translate(Vector3.back * speed * Time.deltaTime);
		}
		if (InputManager.VerticalAxis() > 0)
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		LimitCamera(previousPosition, transform.position);
	}

	/// <summary>
	/// Limits the camera.
	/// </summary>
	/// <param name="previousPosition">Previous position.</param>
	/// <param name="currentPosition">Current position.</param>
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
