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
	private FollowCamera followCamera;

	private static GameObject followTarget = null;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() 
	{
		/// RTS camera init
		CameraComponent camera = new CameraComponent(this.gameObject);
		ZoomCamera zoomCamera = new ZoomCamera(camera, zoomMin, zoomMax, zoomSpeed);
		RotateCamera rotateCamera = new RotateCamera(zoomCamera, rotateSpeed);
		FreeCamera freeCamera = new FreeCamera(rotateCamera, minX, minZ, maxX, maxZ, movementSpeed);
		rtsCamera = new SelectionFrameCamera(freeCamera, selection_frame);

		/// RTS follow camera init
		followCamera = new FollowCamera(rotateCamera);

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
		HeroesController.onFollow += OnFollowCamera;
	}

	/// <summary>
	/// Raises the disable event.
	/// </summary>
	void OnDisable()
	{
		HeroesController.onFollow -= OnFollowCamera;
	}

	/// <summary>
	/// Raises the camera mode changed event.
	/// </summary>
	void OnFollowCamera(GameObject target)
	{
		followCamera.SetFollowTarget(target);
		currentCamera = followCamera;
	}
}
