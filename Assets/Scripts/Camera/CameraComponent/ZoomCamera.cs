using UnityEngine;
using System.Collections;

public class ZoomCamera : CameraDecorator
{
	/// <summary>
	/// The transform.
	/// </summary>
	private readonly Transform transform;

	/// <summary>
	/// Camera zooming limits.
	/// </summary>
	public int zoomMin, zoomMax;
	
	/// <summary>
	/// Camera zooming speed.
	/// </summary>
	public float zoomSpeed;

	/// <summary>
	/// Initializes a new instance of the <see cref="ZoomCamera"/> class.
	/// </summary>
	/// <param name="transform">Transform.</param>
	/// <param name="zoomMin">Zoom minimum.</param>
	/// <param name="zoomMax">Zoom max.</param>
	/// <param name="zoomSpeed">Zoom speed.</param>
	public ZoomCamera(Transform transform, int zoomMin, int zoomMax, float zoomSpeed)
	{
		this.transform = transform;
		this.zoomMin = zoomMin;
		this.zoomMax = zoomMax;
		this.zoomSpeed = zoomSpeed;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	public override void Update()
	{
		base.Update();
		ZoomCameraByScrollWheel();
	}

	/// <summary>
	/// Zooms the camera by scroll wheel.
	/// </summary>
	private void ZoomCameraByScrollWheel()
	{
		if (transform.position.y > zoomMin && Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			transform.Translate(0, -zoomSpeed, zoomSpeed);
		}
		if (transform.position.y < zoomMax && Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			transform.Translate(0, zoomSpeed, -zoomSpeed);
		}
	}
}
