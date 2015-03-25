using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotHotKey: ISkillSlotComponent
{
	private GameObject gameObject;

	public SlotHotKey(GameObject gameObject)
	{
		this.gameObject = gameObject;
	}

	#region ISkillSlotComponent

	public GameObject GameObject
	{
		get { return gameObject; }
	}

	public void Add(ISkillSlotComponent component) {}

	#endregion

	public void ShowHotKey()
	{
		TextComponent().enabled = true;
	}

	public void HideHotKey()
	{
		TextComponent().enabled = false;
	}

	public void ChangeHotKeyText(string text)
	{
		TextComponent().text = text;
	}

	protected Text TextComponent()
	{
		return this.gameObject.GetComponent<Text>();
	}
}