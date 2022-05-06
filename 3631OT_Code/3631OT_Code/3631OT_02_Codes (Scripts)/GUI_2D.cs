using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUI_2D : MonoBehaviour
{
	List<Rect> SkillButtons = new List<Rect>();
	List<Rect> ItemButtons = new List<Rect>();

	public float currentHP = 100;
	public float maxHP = 100;
	public float currentBarLength;
	public float maxBarLength = 100;

	public int currentLevel = 1;
	public GUIStyle myStyle;

	public float maxExperience = 100;
	public float currentExperience = 0;
	public float currentExpBarLength;
	public float maxExpBarLength = 100;

	void Start()
	{
		SkillButtons.Add(new Rect(Screen.width/2 + 50, Screen.height/2 + 333, 55, 55));
		SkillButtons.Add(new Rect(Screen.width/2 + 105, Screen.height/2  + 333, 55, 55));
		SkillButtons.Add(new Rect(Screen.width/2 + 160, Screen.height/2  + 333, 55, 55));
		ItemButtons.Add(new Rect(Screen.width/2 - 160, Screen.height/2  + 333, 55, 55));
		ItemButtons.Add(new Rect(Screen.width/2 - 105, Screen.height/2  + 333, 55, 55));
		ItemButtons.Add(new Rect(Screen.width/2 - 50, Screen.height/2 + 333, 55, 55));

		myStyle.fontSize = 36;
	}

	void OnGUI()
	{
		GUI.Button(SkillButtons[0], "Skill A");
		GUI.Button(SkillButtons[1], "Skill B");
		GUI.Button(SkillButtons[2], "Skill C");
		GUI.Button(ItemButtons[0], "Item A");
		GUI.Button(ItemButtons[1], "Item B");
		GUI.Button(ItemButtons[2], "Item C");

		GUI.Box(new Rect(Screen.width/2 - 20, Screen.height/2 + 300, currentBarLength, 25), "");
		currentBarLength = currentHP * maxBarLength / maxHP;

		GUI.Label(new Rect(Screen.width/2 + 15, Screen.height/2 + 335, 30, 30), currentLevel.ToString(), myStyle);

		if(currentExpBarLength > 5)
			GUI.Box(new Rect(Screen.width/2 - 20, Screen.height/2 - 300, currentExpBarLength, 25), "");
		GUI.Box(new Rect(Screen.width/2 - 20, Screen.height/2 - 300, maxExperience, 25), "");

		currentExpBarLength = currentExperience * maxExpBarLength / maxExperience;
		
		if(currentExpBarLength >= maxExpBarLength)
		{
			currentExpBarLength = 0;
			currentExperience = 0;
			currentLevel++;
		}
	}
}