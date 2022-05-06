using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Behaviors {Idle, Guard, Combat, Flee};

public class AI_Agent : MonoBehaviour
{
	public Behaviors aiBehaviors = Behaviors.Idle;

	public bool isSuspicious = false;
	public bool isInRange = false;
	public bool FightsRanged = false;
	public List<KeyValuePair<string, int>> Stats = new List<KeyValuePair<string, int>>();
	public GameObject Projectile;

	NavMeshAgent navAgent;
	Vector3 Destination;
	float Distance;
	public Transform[] Waypoints;
	public int curWaypoint = 0;
	bool ReversePath = false;

	#region Behaviors
	void RunBehaviors()
	{
		switch(aiBehaviors)
		{
		case Behaviors.Idle:
			RunIdleNode();
			break;
		case Behaviors.Guard:
			RunGuardNode();
			break;
		case Behaviors.Combat:
			RunCombatNode();
			break;
		case Behaviors.Flee:
			RunFleeNode();
			break;
		}
	}

	void ChangeBehavior(Behaviors newBehavior)
	{
		aiBehaviors = newBehavior;

		RunBehaviors();
	}

	void RunIdleNode()
	{
		Idle();
	}

	void RunGuardNode()
	{
		Guard();
	}
	
	void RunCombatNode()
	{
		if(FightsRanged)
			RangedAttack();
		else
			MeleeAttack();
	}
	
	void RunFleeNode()
	{
		Flee();
	}
	#endregion

	#region Actions
	void Idle()
	{
		animation.Play("idle");
	}

	void Guard()
	{
		if(isSuspicious)
		{
			SearchForTarget();
		}
		else
		{
			Patrol();
		}
	}
	
	void Combat()
	{
		if(isInRange)
		{
			if(FightsRanged)
			{
				RangedAttack();
			}
			else
			{
				MeleeAttack();
			}
		}
		else
		{
			SearchForTarget();
		}
	}
	
	void Flee()
	{
		animation.Play("run");
		for(int fleePoint = 0; fleePoint < Waypoints.Length; fleePoint++)
		{
			Distance = Vector3.Distance(gameObject.transform.position, Waypoints[fleePoint].position);
			if(Distance > 10.00f)
			{
				Destination = Waypoints[curWaypoint].position;
				navAgent.SetDestination(Destination);
				break;
			}
			else if(Distance < 2.00f)
			{
				ChangeBehavior(Behaviors.Idle);
			}
		}
	}

	void SearchForTarget()
	{
		animation.Play("run");
		Destination = GameObject.FindGameObjectWithTag("Player").transform.position;
		navAgent.SetDestination(Destination);
		Distance = Vector3.Distance(gameObject.transform.position, Destination);
		if(Distance < 10)
			ChangeBehavior(Behaviors.Combat);
	}
	void Patrol()
	{
		animation.Play("run");
		Distance = Vector3.Distance(gameObject.transform.position, Waypoints[curWaypoint].position);
		if(Distance > 2.00f)
		{
			Destination = Waypoints[curWaypoint].position;
			navAgent.SetDestination(Destination);
		}
		else
		{
			if(ReversePath)
			{
				if(curWaypoint <= 0)
				{
					ReversePath = false;
				}
				else
				{
					curWaypoint--;
					Destination = Waypoints[curWaypoint].position;
				}
			}
			else
			{
				if(curWaypoint >= Waypoints.Length - 1)
				{
					ReversePath = true;
				}
				else
				{
					curWaypoint++;
					Destination = Waypoints[curWaypoint].position;
				}
			}
		}
	}
	void RangedAttack()
	{
		animation.Play("attack");
		GameObject newProjectile;
		newProjectile = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
	}
	void MeleeAttack()
	{
		animation.Play("attack");
	}
	#endregion

	void ChangeHealth(int Amount)
	{
		if(Amount < 0)
		{
			if(!isSuspicious)
			{
				isSuspicious = true;
				ChangeBehavior(Behaviors.Guard);
			}
		}
		for(int i = 0; i < Stats.Capacity; i++)
		{
			if(Stats[i].Key == "Health")
			{
				int tempValue = Stats[i].Value;
				Stats[i] = new KeyValuePair<string, int>(Stats[i].Key, tempValue += Amount);
				if(Stats[i].Value < 0)
				{
					Destroy(gameObject);
				}
				else if(Stats[i].Value < 25)
				{
					isSuspicious = false;
					ChangeBehavior(Behaviors.Flee);
				}
				break;
			}
		}
	}

	void ModifyStat(string Stat, int Amount)
	{
		for(int i = 0; i < Stats.Capacity; i++)
		{
			if(Stats[i].Key == Stat)
			{
				int tempValue = Stats[i].Value;
				Stats[i] = new KeyValuePair<string, int>(Stats[i].Key, tempValue += Amount);
				break;
			}
		}
		if(Amount < 0)
		{
			if(!isSuspicious)
			{
				isSuspicious = true;
				ChangeBehavior(Behaviors.Guard);
			}
		}
	}
	
	void Start()
	{
		navAgent = GetComponent<NavMeshAgent>();

		Stats.Add(new KeyValuePair<string, int>("Health", 100));
		Stats.Add(new KeyValuePair<string, int>("Speed", 10));
		Stats.Add(new KeyValuePair<string, int>("Damage", 25));
		Stats.Add(new KeyValuePair<string, int>("Agility", 25));
		Stats.Add(new KeyValuePair<string, int>("Accuracy", 60));
	}

	void Update ()
	{
		if(Input.GetButtonUp("Fire1"))
		{
			RangedAttack();
		}

		RunBehaviors();
	}
}