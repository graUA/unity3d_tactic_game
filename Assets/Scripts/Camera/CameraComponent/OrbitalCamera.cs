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

	public OrbitalCamera(CameraBase camera) : base(camera)
	{
		this.transform = camera.getCameraGameObject().transform;
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public override void Update()
	{
		base.Update();
	}
	
	/// <summary>
	/// Lates the update.
	/// </summary>
	public override void LateUpdate()
	{
		base.LateUpdate();
	}
}

