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
	private GameObject target;

	/// <summary>
	/// Initializes a new instance of the <see cref="FollowCamera"/> class.
	/// </summary>
	/// <param name="camera">Camera.</param>
	public FollowCamera(CameraBase camera) : base(camera)
	{
		this.transform = camera.getCameraGameObject().transform;
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
	public void SetFollowTarget(GameObject target)
	{
		this.target = target;
	}

	/// <summary>
	/// Follows the target.
	/// </summary>
	private void FollowTarget()
	{
		Vector3 targetPos = target.transform.position;
		
		transform.position = new Vector3(
			(targetPos.x + transform.position.x) / 2,
			transform.position.y,
			targetPos.z);
		
		// Debug.Log(targetPos.z + "----" + transform.position.y);
		// transform.Translate(targetPos.x, transform.position.y, targetPos.z);
		// transform.position = followTarget.transform.position + ();
	}
}
