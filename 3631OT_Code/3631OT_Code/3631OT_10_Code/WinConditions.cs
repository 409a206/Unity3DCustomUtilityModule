using UnityEngine;
using System.Collections;

public class WinConditions : MonoBehaviour
{
	public int Enemies;

	void Start ()
	{
		GameObject[] e = GameObject.FindGameObjectsWithTag("Enemy"); 
		Enemies = e.Length;
	}

	void Update ()
	{
		if(Enemies <= 0)
		{
			if(Application.loadedLevel != 3)
				Application.LoadLevel(Application.loadedLevel + 1);
			else
				Application.LoadLevel(0);
		}
	}
}