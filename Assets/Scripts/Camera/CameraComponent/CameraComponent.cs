using UnityEngine;
using System.Collections;

public class CameraComponent : CameraBase
{
	private readonly Transform transform;

	public CameraComponent(Transform transform) 
	{
		this.transform = transform;
	}

	public override void Update()
	{
		// Do something
	}

	public void CameraToStartPoint()
	{
		// Move camera to start point
	}
}
