using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class SkillSlotController: MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
	/// <summary>
	/// Delegate the subscribers must implement for event when active slot updates.
	/// </summary>
	public delegate void SkillSlotDelegate(GameObject currentSlot);
	
	/// <summary>
	/// An instance of the delegate with selected slot.
	/// </summary>
	public static event SkillSlotDelegate SlotUpdated;

	public Color selectedSlotColor = new Color32 (50, 220, 150, 255);
	public Color deselectedSlotColor = Color.white;
	public Color suspendSlotColor = new Color32 (170, 170, 170, 255);

	/// <summary>
	/// Elements names in Hierarchy.
	/// </summary>
	private const string imageElement = "Icon";
	private const string hotKeyElement = "HotKey";
	private const string cooldownElement = "FillRadial";
	private const string energyConsuptionElement = "EnergyConsuption";

	private SkillSlot skillSlot;
	private SlotImage slotImage;
	private SlotHotKey hotKey;
	private SlotCooldown cooldown;
	private SlotEnergyConsumption energyConsuption;

	private Skill skill;

	#region Unity Memthods

	void Awake()
	{
		skillSlot = new SkillSlot(this.gameObject);

		slotImage = new SlotImage(skillSlot.GameObject.transform.FindChild(imageElement).gameObject);
		hotKey = new SlotHotKey(skillSlot.GameObject.transform.FindChild(hotKeyElement).gameObject);
		energyConsuption = new SlotEnergyConsumption(skillSlot.GameObject.transform.FindChild(energyConsuptionElement).gameObject);

		skillSlot.Add(slotImage);
		skillSlot.Add(hotKey);
		skillSlot.Add(energyConsuption);

		cooldown = new SlotCooldown(slotImage.GameObject.transform.FindChild(cooldownElement).gameObject);
		slotImage.Add(cooldown);
	}

	void Update()
	{
		if (HasSkill())
		{
			cooldown.Update();
			if (Input.GetKey(skill.keyCode))
			{
				UseSkill();
			}
		}
	}

	#endregion

	#region Slot State

	/// <summary>
	/// None (just a gray, closed, ...).
	/// </summary>
	public void Clear()
	{
	}

	/// <summary>
	/// Cooldawn state (with timer to next use)
	/// Toggled (action in auto use)
	/// </summary>
	public void UseSkill(bool auto = false)
	{
		cooldown.Run();
	}

	/// <summary>
	/// Available
	/// </summary>
	public void Activate()
	{
		if (HasSkill())
		{
			skillSlot.ImageColor(deselectedSlotColor);
		}
	}
	
	/// <summary>
	/// Disabled
	/// </summary>
	public void Suspend()
	{
		if (HasSkill())
		{
			skillSlot.ImageColor(suspendSlotColor);
		}
	}

	/// <summary>
	/// Add fucosed state. Can do actions like set hot key.
	/// </summary>
	public void Focus()
	{
		if (HasSkill())
		{
			skillSlot.ImageColor(selectedSlotColor);
		}
	}

	/// <summary>
	/// Remove focused state.
	/// </summary>
	public void Blur()
	{
		skillSlot.ImageColor(deselectedSlotColor);
	}

	#endregion

	/// <summary>
	/// Set skills properties to slot.
	/// </summary>
	public void SetSkill(Skill skill)
	{
		this.skill = skill;

		slotImage.ShowImage();
		slotImage.SetImage (skill.icon);

		hotKey.ChangeHotKeyText(skill.keyCode.ToString());
		hotKey.ShowHotKey();

		energyConsuption.ConsumptionLevel(skill.energyConsumption);
		energyConsuption.ShowConsumptionLevel();

		cooldown.WaitSeconds(skill.interval);
	}

	public bool HasSkill()
	{
		return skill != null;
	}

	/// <summary>
	/// Event method of the IPointerEnterHandler interface.
	/// </summary>
	public void OnPointerEnter(PointerEventData eventData)
	{
		// show tooltip
	}

	/// <summary>
	/// Event method of the IPointerDownHandler interface.
	/// </summary>
	public void OnPointerDown(PointerEventData eventData)
	{
		Focus();

		if (SlotUpdated != null)
		{
			// pass to delegate subscribers.
			SlotUpdated(this.gameObject);
		}
	}
}
