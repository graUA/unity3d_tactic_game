using UnityEngine;
using System.Collections;

public class CameraComponent : CameraBase
{
	/// <summary>
	/// The camera game object.
	/// </summary>
	private GameObject cameraGameObject;

	/// <summary>
	/// Initializes a new instance of the <see cref="CameraComponent"/> class.
	/// </summary>
	/// <param name="cameraGameObject">Camera game object.</param>
	public CameraComponent(GameObject cameraGameObject)
	{
		this.cameraGameObject = cameraGameObject;
	}

	/// <summary>
	/// Gets the camera target.
	/// </summary>
	/// <returns>The camera target.</returns>
	public override GameObject getCameraGameObject()
	{
		return cameraGameObject;
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
}
