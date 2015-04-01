using UnityEngine;
using System.Collections;

public class OrbitalCamera : CameraDecorator
{
	/// <summary>
	/// The transform.
	/// </summary>
	private Transform transform;

	/// <summary>
	/// The target.
	/// </summary>
	private GameObject target;

	/// <summary>
	/// The rotate speed.
	/// </summary>
	private float rotateSpeed;

	/// <summary>
	/// Initializes a new instance of the <see cref="OrbitalCamera"/> class.
	/// </summary>
	/// <param name="camera">Camera.</param>
	/// <param name="rotateSpeed">Rotate speed.</param>
	public OrbitalCamera(CameraBase camera, float rotateSpeed) : base(camera)
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
		if (target != null) Rotate();
	}

	/// <summary>
	/// Sets the target.
	/// </summary>
	/// <param name="target">Target.</param>
	public void SetTarget(GameObject target)
	{
		this.target = target;
	}

	/// <summary>
	/// Rotate this instance.
	/// </summary>
	private void Rotate()
	{
		if (InputManager.RotateAxis() != 0)
		{
			var rotation = InputManager.RotateAxis() * rotateSpeed * Time.deltaTime;
			transform.RotateAround(target.transform.position, Vector3.up, rotation);
		}
	}
}

