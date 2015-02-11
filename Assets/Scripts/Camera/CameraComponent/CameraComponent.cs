using UnityEngine;
using System.Collections;

public class CameraComponent : CameraBase
{
	public readonly Transform transform;

	public CameraComponent(Transform transform) 
	{
		this.transform = transform;
	}

	public override void Update()
	{
		// Do something
	}

	private void CameraToStartPoint()
	{
		// Move camera to start point
	}
}
