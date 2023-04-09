using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SkillInventary : MonoBehaviour
{
	public List<Skill> Skills = new List<Skill>();
	public Button template;

	public void AddSkill(Skill skill)
	{
		if (Skills.Any(s => s.Id == skill.Id)) {
			return;
		}

		Skills.Add(skill);
		var button = Instantiate(template, transform);
		button.gameObject.SetActive(true);
		var renderer = skill.GetComponent<SpriteRenderer>();
		button.image.sprite = renderer.sprite;
		button.image.color = renderer.color;
	}

	public void ShowInventory()
	{
		gameObject.SetActive(true);
	}

	public void HideInventory()
	{
		gameObject.SetActive(false);
	}
}
