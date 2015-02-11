using UnityEngine;
using System.Collections;

public class CameraDecorator : CameraBase
{
	protected CameraBase camera;

	public void SetComponent(CameraBase camera)
	{
		this.camera = camera;
	}

	public override void Update()
	{
		if (camera != null)
		{
			camera.Update();
		}
	}
}
