using UnityEngine;
using System.Collections;

public class ZoomCamera : CameraDecorator
{
	/// <summary>
	/// The transform.
	/// </summary>
	private Transform transform;

	/// <summary>
	/// Camera zooming limits.
	/// </summary>
	public int zoomMin, zoomMax;
	
	/// <summary>
	/// Camera zooming speed.
	/// </summary>
	public float zoomSpeed;

	/// <summary>
	/// The velocity.
	/// </summary>
	private Vector3 velocity = Vector3.zero;

	/// <summary>
	/// The height of the max camera.
	/// </summary>
	private float maxCameraHeight = 50;

	/// <summary>
	/// Initializes a new instance of the <see cref="ZoomCamera"/> class.
	/// </summary>
	/// <param name="camera">Camera.</param>
	/// <param name="zoomMin">Zoom minimum.</param>
	/// <param name="zoomMax">Zoom max.</param>
	/// <param name="zoomSpeed">Zoom speed.</param>
	public ZoomCamera(CameraBase camera, int zoomMin, int zoomMax, float zoomSpeed) : base(camera)
	{
		this.transform = camera.getCameraGameObject().transform;
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
		Zoom();
	}

	/// <summary>
	/// Zoom this instance.
	/// </summary>
	private void Zoom()
	{
//		RaycastHit hit;
//		float distance = 0;
//		float height = 0;
//		Vector3 maxPosiblePosition = transform.position;
//		maxPosiblePosition.y = maxCameraHeight;
//
//		if (Physics.Raycast(maxPosiblePosition, -transform.up, out hit, Mathf.Infinity))
//		{
//			distance = Vector3.Distance(maxPosiblePosition, hit.point);
//			height = maxCameraHeight - distance;
//
//			Debug.DrawLine(maxPosiblePosition, hit.point, Color.green, 2, false);
//			Debug.Log(height);
//		}
//		if (height > transform.position.y)
//		{
//			//float difference = 30 - distance;
//			//transform.position = Vector3.SmoothDamp(transform.position, transform.position + new Vector3(0, height, 0), ref velocity, 0.5f);
//		}

		if (transform.position.y > zoomMin && InputManager.ZoomAxis() > 0)
		{
			transform.Translate(0, -zoomSpeed, zoomSpeed);
		}
		if (transform.position.y < zoomMax && InputManager.ZoomAxis() < 0)
		{
			transform.Translate(0, zoomSpeed, -zoomSpeed);
		}
	}
}
