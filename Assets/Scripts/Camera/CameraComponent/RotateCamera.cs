using UnityEngine;
using System.Collections;

public class RotateCamera : CameraDecorator
{
	/// <summary>
	/// The transform.
	/// </summary>
	private Transform transform;

	/// <summary>
	/// The mouse X position for rotation.
	/// </summary>
	private float mouseXPositionForRotation;

	/// <summary>
	/// The rotate speed.
	/// </summary>
	private float rotateSpeed;

	/// <summary>
	/// Initializes a new instance of the <see cref="RotateCamera"/> class.
	/// </summary>
	/// <param name="camera">Camera.</param>
	/// <param name="rotateSpeed">Rotate speed.</param>
	public RotateCamera(CameraBase camera, float rotateSpeed) : base(camera)
	{
		this.transform = camera.getCameraGameObject().transform;
		this.rotateSpeed = rotateSpeed;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	public override void Update()
	{
		base.Update();
		RotateCameraByMouse();
	}

	/// <summary>
	/// Lates the update.
	/// </summary>
	public override void LateUpdate()
	{
		base.LateUpdate();
		mouseXPositionForRotation = Input.mousePosition.x;
	}

	/// <summary>
	/// Rotates the camera by mouse.
	/// </summary>
	private void RotateCameraByMouse()
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
