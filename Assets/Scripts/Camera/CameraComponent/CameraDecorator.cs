using UnityEngine;
using System.Collections;

public class CameraDecorator : CameraBase
{
	/// <summary>
	/// The camera.
	/// </summary>
	protected CameraBase camera;

	/// <summary>
	/// Sets the component.
	/// </summary>
	/// <param name="camera">Camera.</param>
	public void SetComponent(CameraBase camera)
	{
		this.camera = camera;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	public override void Update()
	{
		if (camera != null) camera.Update();
	}

	/// <summary>
	/// Lates the update.
	/// </summary>
	public override void LateUpdate()
	{
		if (camera != null) camera.LateUpdate();
	}

	/// <summary>
	/// Raises the GUI event.
	/// </summary>
	public override void OnGUI()
	{
		if (camera != null) camera.OnGUI();
	}
}
