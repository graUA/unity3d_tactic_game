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
		AdoptHeight();
	}

	/// <summary>
	/// Zoom this instance.
	/// </summary>
	private void Zoom()
	{
		if (transform.position.y > GetRelativeZoomMin() && InputManager.ZoomAxis() > 0)
		{
			transform.Translate(0, -zoomSpeed, zoomSpeed);
		}
		if (transform.position.y < GetRelativeZoomMax() && InputManager.ZoomAxis() < 0)
		{
			transform.Translate(0, zoomSpeed, -zoomSpeed);
		}
	}

	/// <summary>
	/// Gets the relative zoom minimum.
	/// </summary>
	/// <returns>The relative zoom minimum.</returns>
	private float GetRelativeZoomMin()
	{
		return GetDistance() - zoomMin;
	}
	
	/// <summary>
	/// Gets the relative zoom max.
	/// </summary>
	/// <returns>The relative zoom max.</returns>
	private float GetRelativeZoomMax()
	{
		return GetDistance() + zoomMax;
	}

	/// <summary>
	/// Gets the distance.
	/// </summary>
	/// <returns>The distance.</returns>
	private float GetDistance()
	{
		RaycastHit hit;
		float distance = 0;
		
		if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity))
		{
			distance = Vector3.Distance(transform.position, hit.point);
			Debug.DrawLine(transform.position, hit.point, Color.green, 2, false);
		}
		
		return distance;
	}

	/// <summary>
	/// Adopts the height.
	/// </summary>
	private void AdoptHeight()
	{
		float distance = GetDistance();

		if (distance > 0 && distance < zoomMin)
		{
			transform.position = Vector3.SmoothDamp(
				transform.position,
				transform.position + new Vector3(0, zoomMin - distance, 0),
				ref velocity,
				0.25f);
		}

		if (distance > 0 && distance > zoomMax)
		{
			transform.position = Vector3.SmoothDamp(
				transform.position,
				transform.position - new Vector3(0, distance - zoomMax, 0),
				ref velocity,
				0.25f);
		}
	}
}
