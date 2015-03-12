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
	/// The old target position.
	/// </summary>
	private Vector3 oldTargetPosition;

	private Plane plane = new Plane(Vector3.up, Vector3.zero);
	private Vector3 v3Center = new Vector3(0.5f, 0.5f, 0.0f);

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
	/// Lates the update.
	/// </summary>
	public override void LateUpdate()
	{
		base.LateUpdate();
		if (target != null) oldTargetPosition = target.transform.position;
	}

	/// <summary>
	/// Sets the follow target.
	/// </summary>
	/// <param name="target">Target.</param>
	public void SetTarget(GameObject target)
	{
		this.target = target;
		CenterCameraOnTarget();
	}

	/// <summary>
	/// Centers the camera on target.
	/// </summary>
	private void CenterCameraOnTarget()
	{
		Ray ray = Camera.main.ViewportPointToRay(v3Center);
		float fDist;

		if (plane.Raycast(ray, out fDist))
		{
			Vector3 v3Hit = ray.GetPoint(fDist);
			Vector3 v3Delta = target.transform.position - v3Hit;
			Debug.DrawLine(transform.position, v3Delta, Color.green);
			//transform.Translate(v3Delta);
		}
	}

	/// <summary>
	/// Follows the target.
	/// </summary>
	private void FollowTarget()
	{
		Vector3 distance = target.transform.position - oldTargetPosition;

		//transform.Translate((Vector3.forward + distance) * Time.deltaTime, target.transform);
		//transform.Translate(Vector3.forward * distance.magnitude * Time.deltaTime, target.transform);
		//transform.position = Vector3.Lerp(transform.position, transform.position + distance, Time.deltaTime * 5.0f);
		transform.position += distance;
		//transform.Translate(distance);

		//Vector3 targetPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
		//transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 5.0f);

//		Debug.Log("camera z=>" + transform.position.z);
//		Debug.Log("target z=>" + target.transform.position.z);
//		Debug.Log("distance=>" + distance);
		// transform.Translate(targetPos.x, transform.position.y, targetPos.z);
		// transform.position = followTarget.transform.position + ();
	}
}
