using UnityEngine;
using System.Collections;

public class CameraComponent : CameraBase
{
	/// <summary>
	/// The transform.
	/// </summary>
	private readonly Transform transform;

	/// <summary>
	/// Initializes a new instance of the <see cref="CameraComponent"/> class.
	/// </summary>
	/// <param name="transform">Transform.</param>
	public CameraComponent(Transform transform) 
	{
		this.transform = transform;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	public override void Update(){}

	/// <summary>
	/// Lates the update.
	/// </summary>
	public override void LateUpdate(){}

	/// <summary>
	/// Raises the GUI event.
	/// </summary>
	public override void OnGUI(){}

	/// <summary>
	/// Cameras to start point.
	/// </summary>
	public void CameraToStartPoint()
	{
		// Move camera to start point
	}
}
