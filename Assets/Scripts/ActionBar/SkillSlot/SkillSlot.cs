using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillSlot: ISkillSlotComponent
{
	private ArrayList components = new ArrayList();
	private GameObject gameObject;
	
	public SkillSlot(GameObject gameObject)
	{
		this.gameObject = gameObject;
	}

	#region ISlotComponent

	public GameObject GameObject {
		get { return gameObject; }
	}

	public void Add(ISkillSlotComponent component)
	{
		components.Add(component);
	}

	#endregion

	public void ImageColor(Color color)
	{
		gameObject.GetComponent<Image>().color = color;
	}
}