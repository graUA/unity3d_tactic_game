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
	protected CameraDecorator(CameraBase camera)
	{
		this.camera = camera;
	}

	/// <summary>
	/// Gets the camera game object.
	/// </summary>
	/// <returns>The camera game object.</returns>
	public override GameObject getCameraGameObject()
	{
		return camera.getCameraGameObject();
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	public override void Update()
	{
		camera.Update();
	}

	/// <summary>
	/// Lates the update.
	/// </summary>
	public override void LateUpdate()
	{
		camera.LateUpdate();
	}

	/// <summary>
	/// Raises the GUI event.
	/// </summary>
	public override void OnGUI()
	{
		camera.OnGUI();
	}
}
