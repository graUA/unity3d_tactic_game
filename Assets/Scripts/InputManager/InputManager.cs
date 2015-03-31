using UnityEngine;
using System.Collections;

public class InputManager {

	/// <summary>
	/// Input Manager name constants
	/// </summary>
	private static string VERTICAL_AXIS = "Vertical";
	private static string HORIZONTAL_AXIS = "Horizontal";
	private static string VERTICAL_MOUSE = "Mouse Y";
	private static string HORIZONTAL_MOUSE = "Mouse X";
	private static string SCROLLWHEEL_MOUSE = "Mouse ScrollWheel";
	private static string FIRE1 = "Fire1";
	private static string FIRE2 = "Fire2";
	private static string FIRE3 = "Fire3";
	private static string SHIFT = "Shift";
	private static string CONTROL = "Control";
	private static string FUNCTION = "Function";
	
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
	/// Scrolls the wheel axis.
	/// </summary>
	/// <returns>The wheel axis.</returns>
	public static float ScrollWheelAxis()
	{
		return Input.GetAxis(SCROLLWHEEL_MOUSE);
	}

	/// <summary>
	/// Rotates the axis.
	/// </summary>
	/// <returns>The axis.</returns>
	public static float RotateAxis()
	{
		// TODO: joystick rotation
		return Fire3() ? HorizontalMouseAxis() : 0;
	}

	/// <summary>
	/// Zooms the axis.
	/// </summary>
	/// <returns>The axis.</returns>
	public static float ZoomAxis()
	{
		// TODO: joystick zoom
		return ScrollWheelAxis();
	}

	/// <summary>
	/// Fire1.
	/// </summary>
	public static bool Fire1()
	{
		return Input.GetButton(FIRE1);
	}

	/// <summary>
	/// Fire2.
	/// </summary>
	public static bool Fire2()
	{
		return Input.GetButton(FIRE2);
	}

	/// <summary>
	/// Fire3.
	/// </summary>
	public static bool Fire3()
	{
		return Input.GetButton(FIRE3);
	}

	/// <summary>
	/// Shift.
	/// </summary>
	public static bool Shift()
	{
		return Input.GetButton(SHIFT);
	}

	/// <summary>
	/// Control.
	/// </summary>
	public static bool Control()
	{
		return Input.GetButton(CONTROL);
	}

	/// <summary>
	/// Function.
	/// </summary>
	public static bool Function()
	{
		return Input.GetButton(FUNCTION);
	}

	/// <summary>
	/// Functions up.
	/// </summary>
	private static bool FunctionUp()
	{
		return Input.GetButtonUp(FUNCTION);
	}

	/// <summary>
	/// Follow.
	/// </summary>
	public static bool Follow()
	{
		// TODO: joystick follow mode
		return Shift() && Control() && FunctionUp();
	}
}
