using UnityEngine;
using System.Collections;

public abstract class CameraBase
{
	/// <summary>
	/// Gets the camera game object.
	/// </summary>
	/// <returns>The camera game object.</returns>
	public abstract GameObject getCameraGameObject();

	/// <summary>
	/// Update this instance.
	/// </summary>
	public abstract void Update();

	/// <summary>
	/// Lates the update.
	/// </summary>
	public abstract void LateUpdate();

	/// <summary>
	/// Raises the GUI event.
	/// </summary>
	public abstract void OnGUI();
}
