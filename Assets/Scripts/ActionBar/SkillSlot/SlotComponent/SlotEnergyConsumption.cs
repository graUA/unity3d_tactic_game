using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotEnergyConsumption: ISkillSlotComponent
{
	private GameObject gameObject;

	public SlotEnergyConsumption(GameObject gameObject)
	{
		this.gameObject = gameObject;
	}

	#region ISkillSlotComponent
	
	public GameObject GameObject {
		get { return gameObject; }
	}
	
	public void Add(ISkillSlotComponent component) {}
	
	#endregion

	public void ShowConsumptionLevel()
	{
		TextComponent().enabled = true;
	}

	public void HideConsumptionLevel()
	{
		TextComponent().enabled = false;
	}

	public void ConsumptionLevel(float amount)
	{
		TextComponent().text = amount.ToString("0");
	}

	protected Text TextComponent()
	{
		return this.gameObject.GetComponent<Text>();
	}
}
