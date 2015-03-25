using UnityEngine;
using System.Collections;

public class Skill
{
	public string name;
	public string description;
	public Sprite icon;
	public KeyCode keyCode;
	public float interval;
	public float energyConsumption;
	public bool isAvailable;
	public SkillType type;

	public enum SkillType
	{
		Weapon,
		Armor
	}

	public Skill(string name, SkillType type, KeyCode keyCode, float interval, float energyConsumption, bool isAvailable, string description = "")
	{
		this.name = name; 
		this.description = description;
		this.type = type;
		this.keyCode = keyCode;
		this.interval = interval;
		this.energyConsumption = energyConsumption;
		this.isAvailable = isAvailable;
		this.icon = Resources.Load<Sprite>(name);
	}
}
