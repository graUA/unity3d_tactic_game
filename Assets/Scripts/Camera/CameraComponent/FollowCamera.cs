using UnityEngine;
using System.Collections;

public class FollowCamera : CameraDecorator
{
	/// <summary>
	/// The transform.
	/// </summary>
	private Transform transform;

	/// <summary>
	/// The target.
	/// </summary>
	private GameObject target = null;

	/// <summary>
	/// The damp time.
	/// </summary>
	private float dampTime;

	/// <summary>
	/// The velocity.
	/// </summary>
	private Vector3 velocity = Vector3.zero;
	
	/// <summary>
	/// Initializes a new instance of the <see cref="FollowCamera"/> class.
	/// </summary>
	/// <param name="camera">Camera.</param>
	public FollowCamera(CameraBase camera, float dampTime) : base(camera)
	{
		this.transform = camera.getCameraGameObject().transform;
		this.dampTime = dampTime;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	public override void Update()
	{
		base.Update();
		if (target != null) FollowTarget();
	}

	/// <summary>
	/// Sets the follow target.
	/// </summary>
	/// <param name="target">Target.</param>
	public void SetTarget(GameObject target)
	{
		this.target = target;
	}

	/// <summary>
	/// Follows the target.
	/// </summary>
	private void FollowTarget()
	{
		Vector3 targetPos = target.transform.position;
		Vector3 point = Camera.main.WorldToViewportPoint(targetPos);
		Vector3 delta = targetPos - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
		Vector3 destination = transform.position + delta;

		// Old school Y-Axis for isometric camera
		destination.y = transform.position.y;

		transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
	}
}
