using UnityEngine;
using System.Collections;

public abstract class CameraBase
{
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
