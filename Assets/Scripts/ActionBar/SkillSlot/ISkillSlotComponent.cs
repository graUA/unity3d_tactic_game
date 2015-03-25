using UnityEngine;
using System.Collections;

public interface ISkillSlotComponent
{
	GameObject GameObject { get; }
	void Add(ISkillSlotComponent component);
}