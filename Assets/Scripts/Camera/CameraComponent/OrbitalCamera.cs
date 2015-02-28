using UnityEngine;
using System.Collections;

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
	/// The mouse X position for rotation.
	/// </summary>
	private float mouseXPositionForRotation;
	
	/// <summary>
	/// The rotate speed.
	/// </summary>
	private float rotateSpeed;

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
	/// Lates the update.
	/// </summary>
	public override void LateUpdate()
	{
		base.LateUpdate();
	}

	public void SetTarget(GameObject target)
	{
		this.target = target;
	}

	private void Rotate()
	{
		if (Input.GetMouseButton(2))
		{
			transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
		}
	}
}

