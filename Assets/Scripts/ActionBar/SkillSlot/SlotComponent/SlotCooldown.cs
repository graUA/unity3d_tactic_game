using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotCooldown: ISkillSlotComponent
{
	private GameObject gameObject;
	private float waitSeconds = 5.0f;
	private bool cooldowning = false;
	private float initialFillAmount;

	public SlotCooldown(GameObject gameObject)
	{
		this.gameObject = gameObject;
		initialFillAmount = ImageComponent().fillAmount;
	}

	#region ISkillSlotComponent
	
	public GameObject GameObject
	{
		get { return gameObject; }
	}

	public void Add(ISkillSlotComponent component) {}

	#endregion

	public void Run()
	{
		if (!cooldowning)
		{
			ShowImage();
			cooldowning = true;
		}
	}

	public void Update()
	{
		if (cooldowning)
		{
			ImageComponent().fillAmount -= initialFillAmount / waitSeconds * Time.deltaTime;

			if (ImageComponent().fillAmount <= 0)
			{
				Reset();
			}
		}
	}

	public void WaitSeconds(float seconds)
	{
		if (!cooldowning)
		{
			waitSeconds = seconds;
		}
	}

	public void SetImage(Sprite image) 
	{
		ImageComponent().sprite = image;
	}
	
	public void ShowImage()
	{
		ImageComponent().enabled = true;
	}
	
	public void HideImage()
	{
		ImageComponent().enabled = false;
	}

	protected Image ImageComponent()
	{
		return this.gameObject.GetComponent<Image>();
	}

	private void Reset()
	{
		HideImage();
		ImageComponent().fillAmount = initialFillAmount;
		cooldowning = false;
	}
}