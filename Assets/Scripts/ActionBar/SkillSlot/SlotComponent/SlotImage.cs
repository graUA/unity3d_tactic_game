using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotImage: ISkillSlotComponent
{
	private ArrayList components = new ArrayList();
	private GameObject gameObject;

	public SlotImage(GameObject gameObject)
	{
		this.gameObject = gameObject;
	}

	#region ISkillSlotComponent

	public GameObject GameObject
	{
		get { return gameObject; }
	}

	public void Add(ISkillSlotComponent component)
	{
		components.Add(component);
	}

	#endregion
	
	public void ShowImage()
	{
		ImageComponent().enabled = true;
	}
	
	public void HideImage()
	{
		ImageComponent().enabled = false;
	}

	public void SetImage(Sprite image) 
	{
		ImageComponent().sprite = image;
	}

	private Image ImageComponent()
	{
		return this.gameObject.GetComponent<Image>();
	}
}