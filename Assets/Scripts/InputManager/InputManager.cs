using UnityEngine;
using System.Collections;

public class InputManager {

	/// <summary>
	/// The vertical axis.
	/// </summary>
	private static string VERTICAL_AXIS = "Vertical";

	/// <summary>
	/// The horizontal axis.
	/// </summary>
	private static string HORIZONTAL_AXIS = "Horizontal";

	/// <summary>
	/// The vertical mouse (x cordinate)
	/// </summary>
	private static string VERTICAL_MOUSE = "Mouse Y";

	/// <summary>
	/// The horizontal mouse (y cordinate)
	/// </summary>
	private static string HORIZONTAL_MOUSE = "Mouse X";

	/// <summary>
	/// Verticals the axis.
	/// </summary>
	/// <returns>The axis.</returns>
	public static float VerticalAxis()
	{
		return Input.GetAxis(VERTICAL_AXIS);
	}

	/// <summary>
	/// Horizontals the axis.
	/// </summary>
	/// <returns>The axis.</returns>
	public static float HorizontalAxis()
	{
		return Input.GetAxis(HORIZONTAL_AXIS);
	}

	/// <summary>
	/// Verticals the mouse axis.
	/// </summary>
	/// <returns>The mouse axis.</returns>
	public static float VerticalMouseAxis()
	{
		return Input.GetAxis(VERTICAL_MOUSE);
	}

	/// <summary>
	/// Horizontals the mouse axis.
	/// </summary>
	/// <returns>The mouse axis.</returns>
	public static float HorizontalMouseAxis()
	{
		return Input.GetAxis(HORIZONTAL_MOUSE);
	}

	/// <summary>
	/// Rotate this instance.
	/// </summary>
	public static float Rotate()
	{
		// TODO: joystick rotation
		return Input.GetMouseButton(2) ? HorizontalMouseAxis () : 0;
	}
}
