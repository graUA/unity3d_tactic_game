using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour
{
    /// <summary>
    /// The movement speed.
    /// </summary>
    public float movementSpeed;

    /// <summary>
    /// The minimum x.
    /// </summary>
    public int minX, minZ, maxX, maxZ;

    /// <summary>
    /// The zoom minimum.
    /// </summary>
    public int zoomMin, zoomMax;

    /// <summary>
    /// The zoom speed.
    /// </summary>
    public float zoomSpeed;

    /// <summary>
    /// The rotate speed.
    /// </summary>
	public float rotateSpeed;
    
	/// <summary>
	/// The selection_frame.
	/// </summary>
	public Texture2D selection_frame = null;

	/// <summary>
	/// The current camera.
	/// </summary>
	private CameraBase currentCamera;

	/// <summary>
	/// The rts camera.
	/// </summary>
	private CameraBase rtsCamera;

	/// <summary>
	/// The follow camera.
	/// </summary>
	private CameraBase followCamera;

	private static GameObject followTarget = null;

	private static bool hasFollowed = false;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() 
	{
		/// RTS camera init
		CameraComponent camera = new CameraComponent(transform);
		FreeCamera freeCamera = new FreeCamera(transform, minX, minZ, maxX, maxZ, movementSpeed);
		ZoomCamera zoomCamera = new ZoomCamera(transform, zoomMin, zoomMax, zoomSpeed);
		RotateCamera rotateCamera = new RotateCamera(transform, rotateSpeed);
		CameraSelectionFrame cameraSelect = new CameraSelectionFrame(selection_frame);

		freeCamera.SetComponent(camera);
		zoomCamera.SetComponent(freeCamera);
		rotateCamera.SetComponent(zoomCamera);
		cameraSelect.SetComponent(rotateCamera);

		rtsCamera = cameraSelect;
		followCamera = rotateCamera;

		currentCamera = rtsCamera;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
    void Update()
	{
		currentCamera.Update();
    }

    /// <summary>
    /// Lates the update.
    /// </summary>
    void LateUpdate()
    {
		currentCamera.LateUpdate();
    }

	/// <summary>
	/// Raises the GUI event.
	/// </summary>
    void OnGUI()
    {
		currentCamera.OnGUI();
    }

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable()
	{
		HeroesController.onFollowCamera += OnFollowCamera;
	}

	/// <summary>
	/// Raises the disable event.
	/// </summary>
	void OnDisable()
	{
		HeroesController.onFollowCamera -= OnFollowCamera;
	}

	/// <summary>
	/// Raises the camera mode changed event.
	/// </summary>
	void OnFollowCamera(GameObject target)
	{
		currentCamera = followCamera;
	}

	// TODO: Move to follow camera component
	public static void SetFollowCamera(GameObject target)
	{
		hasFollowed = true;
		followTarget = target;
	}

	private static void RemoveFollowCamera()
	{
		hasFollowed = false;
		followTarget = null;
	}

	private void FollowCamera()
	{
		if (followTarget != null)
		{
			Vector3 targetPos = followTarget.transform.position;
		
			transform.position = new Vector3(
				(targetPos.x + transform.position.x) / 2,
				transform.position.y,
				targetPos.z
			);

			// Debug.Log(targetPos.z + "----" + transform.position.y);
			// transform.Translate(targetPos.x, transform.position.y, targetPos.z);
			// transform.position = followTarget.transform.position + ();
		}
	}
}
