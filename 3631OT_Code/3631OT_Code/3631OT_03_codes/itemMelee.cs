using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MeleeAction {BuffDebuff, ChangeHP, ActivateEnv, None};
public enum MeleeType {Weapon, Potion, None};

public class itemMelee : MonoBehaviour
{
	public int Amount, Value;
	public float Weight;
	public string Name, Stat;
	public MeleeAction meleeAction = MeleeAction.None;
	public MeleeType meleeType = MeleeType.None;

	void BuffDebuffStat(GameObject other)
	{
		other.SendMessage("BuffDebuffStat", new KeyValuePair<string, int>(Stat, Amount));
	}
	
	void ChangeHealth(GameObject other)
	{
		other.SendMessage("ChangeHealth", Amount);
	}
	
	void ActivateEnvironment(GameObject other)
	{
		other.SendMessage("Activate");
	}

	void OnTriggerEnter(Collider col)
	{
		switch(col.gameObject.tag)
		{
		case "Enemy":
			if(meleeType != MeleeType.Potion)
			{
				if(meleeAction == MeleeAction.ChangeHP)
					ChangeHealth(col.gameObject);

				if(meleeAction == MeleeAction.BuffDebuff)
					BuffDebuffStat(col.gameObject);

				if(meleeAction == MeleeAction.ActivateEnv)
					ActivateEnvironment(col.gameObject);
			}
			break;
		case "Environment":
			if(meleeType == MeleeType.Potion)
			{
				if(meleeAction == MeleeAction.ChangeHP)
					ChangeHealth(col.gameObject);

				if(meleeAction == MeleeAction.BuffDebuff)
					BuffDebuffStat(col.gameObject);
			}
			break;
		}
		
		if(meleeType == MeleeType.Potion)
			Destroy(gameObject);
	}
}