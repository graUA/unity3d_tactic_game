using UnityEngine;
using System.Collections;

public static class GUIFramePosition
{
	private static float screenHeight;
	private static float screenWidth;

	public static float percentOfScreen = 0.6f;
	public static Texture2D texture;

	public static Rect bottomCenter()
	{
		screenDimension();
		Rect frame = scaledFrame();

		frame.y = screenHeight - frame.height;
		frame.x = screenWidth / 2 - frame.width / 2;

		return frame;
	}

	public static Rect bottomRight()
	{
		screenDimension();
		Rect frame = scaledFrame();
		
		frame.y = screenHeight - frame.height;
		frame.x = screenWidth - frame.width;
		
		return frame;
	}

	private static Rect scaledFrame()
	{
		float textureWidth = (float)texture.width;
		float textureHeight = (float)texture.height;

		float textureUnitsWidth = textureWidth / screenWidth;
		float scale = percentOfScreen / textureUnitsWidth;

		float scaledWidth = scale * screenWidth;
		float ratio = scaledWidth / textureWidth;
		float scaleHeight = ratio * textureHeight;
		return new Rect (0f, 0f, scaledWidth, scaleHeight);
	}

	private static void screenDimension()
	{
		screenHeight = (float)Screen.height;
		screenWidth = (float)Screen.width;
	}
}
