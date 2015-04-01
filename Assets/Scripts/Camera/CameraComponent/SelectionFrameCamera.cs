using UnityEngine;
using System.Collections;

/// <summary>
/// Selection frame camera.
/// 
/// IMPORTANT: Please note that it can be used for mouse ONLY
/// </summary>
public class SelectionFrameCamera : CameraDecorator
{
	/// <summary>
	/// The selection.
	/// </summary>
	public static Rect selection = new Rect(0, 0, 0, 0);

	/// <summary>
	/// The selection frame.
	/// </summary>
	private Texture2D selectionFrame = null;

	/// <summary>
	/// The start click.
	/// </summary>
	private Vector3 startClick = -Vector3.one;

	/// <summary>
	/// Inverts the mouse y.
	/// </summary>
	/// <returns>The mouse y.</returns>
	/// <param name="y">The y coordinate.</param>
	public static float InvertMouseY(float y)
	{
		return Screen.height - y;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="CameraSelectionFrame"/> class.
	/// </summary>
	/// <param name="selectionFrame">Selection frame.</param>
	public SelectionFrameCamera(CameraBase camera, Texture2D selectionFrame) : base(camera)
	{
		this.selectionFrame = selectionFrame;
	}

	/// <summary>
	/// Raises the GUI event.
	/// </summary>
	public override void OnGUI()
	{
		base.OnGUI();

		if (startClick != -Vector3.one)
		{
			GUI.color = new Color(1, 1, 1, 0.2f);
			GUI.DrawTexture(selection, selectionFrame);
		}
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	public override void Update()
	{
		base.Update();
		CheckCameraAndDrawSelectionFrame();
	}

	/// <summary>
	/// Checks the camera and draw selection frame.
	/// </summary>
	private void CheckCameraAndDrawSelectionFrame()
	{
		if (Input.GetMouseButtonDown(0))
		{
			startClick = Input.mousePosition;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			if (selection.width < 0)
			{
				selection.x += selection.width;
				selection.width = -selection.width;
			}
			if (selection.height < 0)
			{
				selection.y += selection.height;
				selection.height = -selection.height;
			}
			
			startClick = -Vector3.one;
		}
		if (Input.GetMouseButton(0))
		{
			selection = new Rect(
				startClick.x,
				InvertMouseY(startClick.y),
				Input.mousePosition.x - startClick.x,
				InvertMouseY(Input.mousePosition.y) - InvertMouseY(startClick.y));
		}
	}
}
