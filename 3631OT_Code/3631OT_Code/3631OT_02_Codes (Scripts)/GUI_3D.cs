using UnityEngine;
using System.Collections;

public class GUI_3D : MonoBehaviour
{
	public float currentHealth = 100;
	public float maximumHealth = 100;
	float currentBarLength;
	public Transform HealthBar;
	Vector3 OrigScale;

	public TextMesh DamageReport;
	public float Damage = 5;
	Color txtColor;
	public float SpawnTime = 2;
	public float KillTime = 3;
	public float PreviousTime = 0;
	bool HasChanged = false;

	public string Name = "Skeleton Warrior";
	public int Level = 1;
	public TextMesh NameTag;

	void Start()
	{
		OrigScale = HealthBar.transform.localScale;

		txtColor = DamageReport.color;
		txtColor.a = 0;
	}

	void Update()
	{
		currentBarLength = currentHealth / maximumHealth;
		HealthBar.transform.LookAt(Camera.main.transform);

		DamageReport.color = txtColor;
		if(Time.time > (SpawnTime + PreviousTime))
		{
			DamageReport.text = Damage.ToString();
			txtColor.a = 1;
			if(!HasChanged)
			{
				currentHealth -= Damage;
				ChangeBar();
			}
		}
		if(Time.time > (KillTime + PreviousTime))
		{
			DamageReport.text = "";

			txtColor.a = 0;
			PreviousTime = Time.time;
			HasChanged = false;
		}

		SetNameTag();
	}

	void ChangeBar()
	{
		HealthBar.transform.localScale = Vector3.Lerp(OrigScale, new Vector3(currentBarLength, OrigScale.y,OrigScale.z), Time.fixedTime);
		HasChanged = true;
	}

	void SetNameTag()
	{
		NameTag.text = Level + "   " + Name;
	}
}