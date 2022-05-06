using UnityEngine;
using System.Collections;

public class StatTracker : MonoBehaviour
{
	int pKills = 0;
	int pDeaths = 0;
	int pTotalGold = 0;
	int pCurrentGold = 0;
	int pGoldSpent = 0;
	int pLevel = 1;
	int pRoundsWon = 0;
	int pRoundsLost = 0;
	float pKDR = 0.00f;
	float pWLR = 0.00f;
	float pTimePlayed = 0.00f;
	public bool showStats = false;
	public Rect statsRect = new Rect(Screen.width / 2, Screen.height / 2, 400, 400);

	void SetStat(string stat, int intValue = 0)
	{
		switch(stat)
		{
		case "Kills":
			pKills+= intValue;

			float fKills = pKills;
			float fDeaths = pDeaths;
			if(fKills != 0)
				pKDR = fDeaths / fKills;
			break;
		case "Deaths":
			pDeaths+= intValue;

			float fKills2 = pKills;
			float fDeaths2 = pDeaths;
			if(fKills2 != 0)
				pKDR = fDeaths2 / fKills2;
			break;
		case "TotalGold":
			pTotalGold+= intValue;
			break;
		case "CurrentGold":
			pCurrentGold+= intValue;
			break;
		case "GoldSpent":
			pGoldSpent+= intValue;
			break;
		case "Level":
			pLevel+= intValue;
			break;
		case "RoundsWon":
			pRoundsWon+= intValue;

			float fWins = pRoundsWon;
			float fLosses = pRoundsLost;
			if(fWins != 0)
				pWLR = fLosses / fWins;
			break;
		case "RoundsLost":
			pRoundsLost+= intValue;

			float fWins2 = pRoundsWon;
			float fLosses2 = pRoundsLost;
			if(fWins2 != 0)
				pWLR = fLosses2 / fWins2;
			break;
		case "TimePlayed":
			pTimePlayed+= fltValue;
			break;
		}
	}

	void ResetStats()
	{
		pKills = 0;
		pDeaths = 0;
		pTotalGold = 0;
		pCurrentGold = 0;
		pGoldSpent = 0;
		pLevel = 1;
		pRoundsWon = 0;
		pRoundsLost = 0;
		pKDR = 0.00f;
		pWLR = 0.00f;
		pTimePlayed = 0.00f;
	}
	
	void ResetAllPrefs()
	{
		PlayerPrefs.SetInt("PlayerKills", 0);
		PlayerPrefs.SetInt("PlayerDeaths", 0);
		PlayerPrefs.SetInt("PlayerTotalGold", 0);
		PlayerPrefs.SetInt("PlayerCurrentGold", 0);
		PlayerPrefs.SetInt("PlayerGoldSpent", 0);
		PlayerPrefs.SetInt("PlayerLevel", 0);
		PlayerPrefs.SetInt("PlayerRoundsWon", 0);
		PlayerPrefs.SetInt("PlayerRoundsLost", 0);
		PlayerPrefs.SetFloat("PlayerKDR", 0.00f);
		PlayerPrefs.SetFloat("PlayerWLR", 0.00f);
		PlayerPrefs.SetFloat("PlayerTimePlayed", 0.00f);
		PlayerPrefs.Save();
	}

	void SaveAllPrefs()
	{
		PlayerPrefs.SetInt("PlayerKills", pKills);
		PlayerPrefs.SetInt("PlayerDeaths", pDeaths);
		PlayerPrefs.SetInt("PlayerTotalGold", pTotalGold);
		PlayerPrefs.SetInt("PlayerCurrentGold", pCurrentGold);
		PlayerPrefs.SetInt("PlayerGoldSpent", pGoldSpent);
		PlayerPrefs.SetInt("PlayerLevel", pLevel);
		PlayerPrefs.SetInt("PlayerRoundsWon", pRoundsWon);
		PlayerPrefs.SetInt("PlayerRoundsLost", pRoundsLost);
		PlayerPrefs.SetFloat("PlayerKDR", pKDR);
		PlayerPrefs.SetFloat("PlayerWLR", pWLR);
		PlayerPrefs.SetFloat("PlayerTimePlayed", pTimePlayed);
		PlayerPrefs.Save();
	}

	void SetPref(string Pref, int intValue = 0, float fltValue = 0.00f)
	{
		if(intValue != 0)
		{
			if(PlayerPrefs.HasKey(Pref))
				PlayerPrefs.SetInt(Pref, intValue);
		}
		if(fltValue != 0.00f)
		{
			if(PlayerPrefs.HasKey(Pref))
				PlayerPrefs.SetFloat(Pref, fltValue);
		}
		
		PlayerPrefs.Save();
	}

	void ResetPref(string Pref)
	{
		switch(Pref)
		{
		case "Kills":
			PlayerPrefs.SetInt("PlayerKills", 0);
			break;
		case "Deaths":
			PlayerPrefs.SetInt("PlayerDeaths", 0);
			break;
		case "TotalGold":
			PlayerPrefs.SetInt("PlayerTotalGold", 0);
			break;
		case "CurrentGold":
			PlayerPrefs.SetInt("PlayerCurrentGold", 0);
			break;
		case "GoldSpent":
			PlayerPrefs.SetInt("PlayerGoldSpent", 0);
			break;
		case "Level":
			PlayerPrefs.SetInt("PlayerLevel", 0);
			break;
		case "RoundsWon":
			PlayerPrefs.SetInt("PlayerRoundsWon", 0);
			break;
		case "RoundsLost":
			PlayerPrefs.SetInt("PlayerRoundsLost", 0);
			break;
		case "KDR":
			PlayerPrefs.SetFloat("PlayerKDR", 0.00f);
			break;
		case "WLR":
			PlayerPrefs.SetFloat("PlayerWLR", 0.00f);
			break;
		case "TimePlayed":
			PlayerPrefs.SetFloat("PlayerTimePlayed", 0.00f);
			break;
		}
		
		PlayerPrefs.Save();
	}

	void OnGUI()
	{
		if(showStats)
		{
			statsRect = GUI.Window(0, statsRect, StatsGUI, "Stats");
		}
	}

	void StatsGUI(int ID)
	{
		GUILayout.BeginArea(new Rect(15, 25, 400, 400));
		
		GUILayout.BeginVertical();
		GUILayout.Label("Level - " + pLevel);
		GUILayout.Label("Gold - " + pCurrentGold);
		GUILayout.Label("Kills - " + pKills);
		GUILayout.Label("Deaths - " + pDeaths);
		GUILayout.Label("Kill/Death Ratio - " + pKDR);
		GUILayout.Label("Rounds Won - " + pRoundsWon);
		GUILayout.Label("Rounds Loss - " + pRoundsLost);
		GUILayout.Label("Win/Loss Ratio - " + pWLR);
		GUILayout.Label("Time Played (in minutes) - " + (pTimePlayed / 60.00f));
		GUILayout.EndVertical();
		
		GUILayout.EndArea();
	}
}