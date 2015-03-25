using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvailableSkills
{
	public List<Skill> Skills;

	public AvailableSkills()
	{
		Skills = new List<Skill>();
		addSkills();
	}

	private void addSkills()
	{
		Skills.Add(new Skill("A_Armadura01", Skill.SkillType.Armor, KeyCode.Alpha1, 3.5f, 20.0f, true, "Nice Armor"));
		Skills.Add(new Skill("A_Armadura03", Skill.SkillType.Armor, KeyCode.Alpha2, 1.0f, 999.0f, false, "Better Armor"));
		Skills.Add(new Skill("W_Machado010", Skill.SkillType.Weapon, KeyCode.Alpha3, 10.0f, 10.0f, true, "Ancient Axe"));
	}
}