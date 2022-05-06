using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum RangedAction {BuffDebuff, ChangeHP, ActivateEnv, None};
public enum RangedType {Weapon, None};
public enum MovementType {Basic, Drop, None};

public class itemRanged : MonoBehaviour
{
	public int Amount, Value;
	public float Weight, Speed, DropSpeed;
	public string Name, Stat;
	public RangedAction rangedAction = RangedAction.None;
	public RangedType rangedType = RangedType.None;
	public MovementType moveType = MovementType.None;

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

	void BasicMovement()
	{
		transform.Translate(Vector3.forward * (Time.deltaTime * Speed));
	}

	void DropMovement()
	{
		transform.Translate(new Vector3(0, DropSpeed, 1) * (Time.deltaTime * Speed));
	}

	void Update()
	{
		switch(moveType)
		{
		case MovementType.Basic:
			BasicMovement();
			break;
		case MovementType.Drop:
			DropMovement();
			break;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		switch(col.gameObject.tag)
		{
		case "Enemy":
			if(rangedType == RangedType.Weapon)
			{
				if(rangedType != RangedType.None)
				{
					if(rangedAction == RangedAction.ChangeHP)
						ChangeHealth(col.gameObject);
					
					if(rangedAction == RangedAction.BuffDebuff)
						BuffDebuffStat(col.gameObject);
					
					if(rangedAction == RangedAction.ActivateEnv)
						ActivateEnvironment(col.gameObject);
				}
			}
			break;
		case "Environment":
			if(rangedType != RangedType.None)
			{
				if(rangedAction == RangedAction.ChangeHP)
					ChangeHealth(col.gameObject);
				
				if(rangedAction == RangedAction.BuffDebuff)
					BuffDebuffStat(col.gameObject);
				
				if(rangedAction == RangedAction.ActivateEnv)
					ActivateEnvironment(col.gameObject);
			}
			break;
		}
		Destroy(gameObject);
	}
}