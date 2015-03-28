using UnityEngine;
using System.Collections;

public class RotateCamera : CameraDecorator
{
	/// <summary>
	/// The transform.
	/// </summary>
	private Transform transform;

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
		Rotate();
	}

	/// <summary>
	/// Rotate this instance.
	/// </summary>
	private void Rotate()
	{
		if (InputManager.RotateAxis() != 0)
		{
			var rotation = InputManager.RotateAxis() * rotateSpeed * Time.deltaTime;
			transform.Rotate(0, rotation, 0);
		}
	}
}
