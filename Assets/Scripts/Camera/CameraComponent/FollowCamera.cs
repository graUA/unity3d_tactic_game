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
		Vector3 distance = targetPos - transform.position;

		//transform.Translate(Vector3.forward * target.rigidbody.velocity.magnitude * Time.deltaTime, target.transform);
		//transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 5.0f);
		//transform.position = targetPos + distance;

		//Vector3 targetPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
		//transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 5.0f);

		Debug.Log("camera z=>" + transform.position.z);
		Debug.Log("target z=>" + target.transform.position.z);
		Debug.Log("distance z=>" + distance);
		// transform.Translate(targetPos.x, transform.position.y, targetPos.z);
		// transform.position = followTarget.transform.position + ();
	}
}
