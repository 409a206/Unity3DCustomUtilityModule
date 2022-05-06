using UnityEngine;
using System.Collections;

public class AchievementSystem : MonoBehaviour
{
	// achievement level
	public int achKills, achTotGold, achGoldSpnt, achLvl, achRndsW, achTime;
	// if achievement can still be advanced
	bool getKills, getTotGold, getGoldSpnt, getLvl, getRndsW, getTime;
	public bool showAchievements = false;
	public Rect achRect = new Rect(Screen.width / 2, Screen.height / 2, 700, 700);

	void ResetAchievements()
	{
		achKills = 0;
		achTotGold = 0;
		achGoldSpnt = 0;
		achLvl = 0;
		achRndsW = 0;
		achTime = 0;
		getKills = true;
		getTotGold = true;
		getGoldSpnt = true;
		getLvl = true;
		getRndsW = true;
		getTime = true;
	}

	void Kills(int Amount)
	{
		if(getKills)
		{
			if(Amount >= 10 && Amount < 49)
			{
				if(achKills != 1)
					achKills++;
			}
			if(Amount >= 50 && Amount < 99)
			{
				if(achKills != 2)
					achKills++;
			}
			if(Amount >= 100 && Amount < 249)
			{
				if(achKills != 3)
					achKills++;
			}
			if(Amount >= 250 && Amount < 499)
			{
				if(achKills != 4)
					achKills++;
			}
			if(Amount >= 500 && Amount < 999)
			{
				if(achKills != 5)
					achKills++;
			}
			if(Amount >= 1000)
			{
				if(achKills != 6)
					achKills = 6;
			}

			if(achKills == 6)
				getKills = false;
		}
	}
	
	void TotalGold(int Amount)
	{
		if(getTotGold)
		{
			if(Amount >= 100 && Amount < 249)
			{
				if(achTotGold != 1)
					achTotGold++;
			}
			if(Amount >= 250 && Amount < 499)
			{
				if(achTotGold != 2)
					achTotGold++;
			}
			if(Amount >= 500 && Amount < 999)
			{
				if(achTotGold != 3)
					achTotGold++;
			}
			if(Amount >= 1000 && Amount < 4999)
			{
				if(achTotGold != 4)
					achTotGold++;
			}
			if(Amount >= 5000 && Amount < 9999)
			{
				if(achTotGold != 5)
					achTotGold++;
			}
			if(Amount >= 10000)
			{
				if(achTotGold != 6)
					achTotGold = 6;
			}
			
			if(achTotGold == 6)
				getTotGold = false;
		}
	}
	
	void GoldSpent(int Amount)
	{
		if(getGoldSpnt)
		{
			if(Amount >= 100 && Amount < 249)
			{
				if(achGoldSpnt != 1)
					achGoldSpnt++;
			}
			if(Amount >= 250 && Amount < 499)
			{
				if(achGoldSpnt != 2)
					achGoldSpnt++;
			}
			if(Amount >= 500 && Amount < 999)
			{
				if(achGoldSpnt != 3)
					achGoldSpnt++;
			}
			if(Amount >= 1000 && Amount < 4999)
			{
				if(achGoldSpnt != 4)
					achGoldSpnt++;
			}
			if(Amount >= 5000 && Amount < 9999)
			{
				if(achGoldSpnt != 5)
					achGoldSpnt++;
			}
			if(Amount >= 10000)
			{
				if(achGoldSpnt != 6)
					achGoldSpnt = 6;
			}
			
			if(achGoldSpnt == 6)
				getGoldSpnt = false;
		}
	}
	
	void Level(int Amount)
	{
		if(getLvl)
		{
			if(Amount >= 5 && Amount < 9)
			{
				if(achLvl != 1)
					achLvl++;
			}
			if(Amount >= 10 && Amount < 24)
			{
				if(achLvl != 2)
					achLvl++;
			}
			if(Amount >= 25 && Amount < 49)
			{
				if(achLvl != 3)
					achLvl++;
			}
			if(Amount >= 50 && Amount < 74)
			{
				if(achLvl != 4)
					achLvl++;
			}
			if(Amount >= 75 && Amount < 99)
			{
				if(achLvl != 5)
					achLvl++;
			}
			if(Amount >= 100)
			{
				if(achLvl != 6)
					achLvl = 6;
			}
			
			if(achLvl == 6)
				getLvl = false;
		}
	}
	
	void RoundsWon(int Amount)
	{
		if(getRndsW)
		{
			if(Amount >= 5 && Amount < 9)
			{
				if(achRndsW != 1)
					achRndsW++;
			}
			if(Amount >= 10 && Amount < 24)
			{
				if(achRndsW != 2)
					achRndsW++;
			}
			if(Amount >= 25 && Amount < 49)
			{
				if(achRndsW != 3)
					achRndsW++;
			}
			if(Amount >= 50 && Amount < 74)
			{
				if(achRndsW != 4)
					achRndsW++;
			}
			if(Amount >= 75 && Amount < 99)
			{
				if(achRndsW != 5)
					achRndsW++;
			}
			if(Amount >= 100)
			{
				if(achRndsW != 6)
					achRndsW = 6;
			}
			
			if(achRndsW == 6)
				getRndsW = false;
		}
	}
	
	void TimePlayed(float Amount)
	{
		if(getTime)
		{
			float minutes = Amount / 60.00f;

			if(minutes >= 10.00f && minutes < 59.00f)
			{
				if(achTime != 1)
					achTime++;
			}
			if(minutes >= 60.00f && minutes < 119.00f)
			{
				if(achTime != 2)
					achTime++;
			}
			if(minutes >= 120.00f && minutes < 179.00f)
			{
				if(achTime != 3)
					achTime++;
			}
			if(minutes >= 180.00f && minutes < 239.00f)
			{
				if(achTime != 4)
					achTime++;
			}
			if(minutes >= 240.00f && minutes < 299.00f)
			{
				if(achTime != 5)
					achTime++;
			}
			if(minutes >= 300.00f)
			{
				if(achTime != 6)
					achTime = 6;
			}
			
			if(achTime == 6)
				getTime = false;
		}
 	}

	void CheckAchievement(string Achievement)
	{
		switch(Achievement)
		{
		case "Kills":
			Kills(PlayerPrefs.GetInt("PlayerKills"));
			break;
		case "TotalGold":
			TotalGold(PlayerPrefs.GetInt("PlayerTotalGold"));
			break;
		case "GoldSpent":
			GoldSpent(PlayerPrefs.GetInt("PlayerGoldSpent"));
			break;
		case "Level":
			Level(PlayerPrefs.GetInt("PlayerLevel"));
			break;
		case "RoundsWon":
			RoundsWon(PlayerPrefs.GetInt("PlayerRoundsWon"));
			break;
		case "TimePlayed":
			TimePlayed(PlayerPrefs.GetFloat("PlayerTimePlayed"));
			break;
		}
	}

	void CheckAllAchievements()
	{
		Kills(PlayerPrefs.GetInt("PlayerKills"));
		TotalGold(PlayerPrefs.GetInt("PlayerTotalGold"));
		GoldSpent(PlayerPrefs.GetInt("PlayerGoldSpent"));
		Level(PlayerPrefs.GetInt("PlayerLevel"));
		RoundsWon(PlayerPrefs.GetInt("PlayerRoundsWon"));
		TimePlayed(PlayerPrefs.GetFloat("PlayerTimePlayed"));
	}
	
	void OnGUI()
	{
		if(showAchievements)
		{
			achRect = GUI.Window(0, achRect, AchGUI, "Achievements");
		}
	}
	
	void AchGUI(int ID)
	{
		GUILayout.BeginArea(new Rect(15, 25, 700, 700));
		
		GUILayout.BeginVertical();
		GUILayout.Label("Level");
		GUILayout.Label("Kills");
		GUILayout.Label("Total Gold");
		GUILayout.Label("Gold Spent");
		GUILayout.Label("Rounds Won");
		GUILayout.Label("Time Played");
		GUILayout.EndVertical();
		
		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect(50, 25, 700, 700));
		
		GUILayout.BeginHorizontal();
		if(achLvl >= 1)
			GUILayout.Button("Level 1", GUILayout.Height(25), GUILayout.Width(75));
		if(achLvl >= 2)
			GUILayout.Button("Level 2", GUILayout.Height(25), GUILayout.Width(75));
		if(achLvl >= 3)
			GUILayout.Button("Level 3", GUILayout.Height(25), GUILayout.Width(75));
		if(achLvl >= 4)
			GUILayout.Button("Level 4", GUILayout.Height(25), GUILayout.Width(75));
		if(achLvl >=5)
			GUILayout.Button("Level 5", GUILayout.Height(25), GUILayout.Width(75));
		if(achLvl >=6)
			GUILayout.Button("Level 6", GUILayout.Height(25), GUILayout.Width(75));
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		if(achKills >= 1)
			GUILayout.Button("Kills 1", GUILayout.Height(25), GUILayout.Width(75));
		if(achKills >= 2)
			GUILayout.Button("Kills 2", GUILayout.Height(25), GUILayout.Width(75));
		if(achKills >= 3)
			GUILayout.Button("Kills 3", GUILayout.Height(25), GUILayout.Width(75));
		if(achKills >= 4)
			GUILayout.Button("Kills 4", GUILayout.Height(25), GUILayout.Width(75));
		if(achKills >=5)
			GUILayout.Button("Kills 5", GUILayout.Height(25), GUILayout.Width(75));
		if(achKills >=6)
			GUILayout.Button("Kills 6", GUILayout.Height(25), GUILayout.Width(75));
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		
		GUILayout.BeginArea(new Rect(90, 80, 700, 700));
		GUILayout.BeginHorizontal();
		if(achTotGold >= 1)
			GUILayout.Button("Total Gold 1", GUILayout.Height(25), GUILayout.Width(75));
		if(achTotGold >= 2)
			GUILayout.Button("Total Gold 2", GUILayout.Height(25), GUILayout.Width(75));
		if(achTotGold >= 3)
			GUILayout.Button("Total Gold 3", GUILayout.Height(25), GUILayout.Width(75));
		if(achTotGold >= 4)
			GUILayout.Button("Total Gold 4", GUILayout.Height(25), GUILayout.Width(75));
		if(achTotGold >=5)
			GUILayout.Button("Total Gold 5", GUILayout.Height(25), GUILayout.Width(75));
		if(achTotGold >=6)
			GUILayout.Button("Total Gold 6", GUILayout.Height(25), GUILayout.Width(75));
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		if(achGoldSpnt >= 1)
			GUILayout.Button("Gold Spent 1", GUILayout.Height(25), GUILayout.Width(75));
		if(achGoldSpnt >= 2)
			GUILayout.Button("Gold Spent 2", GUILayout.Height(25), GUILayout.Width(75));
		if(achGoldSpnt >= 3)
			GUILayout.Button("Gold Spent 3", GUILayout.Height(25), GUILayout.Width(75));
		if(achGoldSpnt >= 4)
			GUILayout.Button("Gold Spent 4", GUILayout.Height(25), GUILayout.Width(75));
		if(achGoldSpnt >=5)
			GUILayout.Button("Gold Spent 5", GUILayout.Height(25), GUILayout.Width(75));
		if(achGoldSpnt >=6)
			GUILayout.Button("Gold Spent 6", GUILayout.Height(25), GUILayout.Width(75));
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		if(achRndsW >= 1)
			GUILayout.Button("Rounds Won 1", GUILayout.Height(25), GUILayout.Width(75));
		if(achRndsW >= 2)
			GUILayout.Button("Rounds Won 2", GUILayout.Height(25), GUILayout.Width(75));
		if(achRndsW >= 3)
			GUILayout.Button("Rounds Won 3", GUILayout.Height(25), GUILayout.Width(75));
		if(achRndsW >= 4)
			GUILayout.Button("Rounds Won 4", GUILayout.Height(25), GUILayout.Width(75));
		if(achRndsW >=5)
			GUILayout.Button("Rounds Won 5", GUILayout.Height(25), GUILayout.Width(75));
		if(achRndsW >=6)
			GUILayout.Button("Rounds Won 6", GUILayout.Height(25), GUILayout.Width(75));
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		if(achTime >= 1)
			GUILayout.Button("Time Played 1", GUILayout.Height(25), GUILayout.Width(75));
		if(achTime >= 2)
			GUILayout.Button("Time Played 2", GUILayout.Height(25), GUILayout.Width(75));
		if(achTime >= 3)
			GUILayout.Button("Time Played 3", GUILayout.Height(25), GUILayout.Width(75));
		if(achTime >= 4)
			GUILayout.Button("Time Played 4", GUILayout.Height(25), GUILayout.Width(75));
		if(achTime >=5)
			GUILayout.Button("Time Played 5", GUILayout.Height(25), GUILayout.Width(75));
		if(achTime >=6)
			GUILayout.Button("Time Played 6", GUILayout.Height(25), GUILayout.Width(75));
		GUILayout.EndHorizontal();
		
		GUILayout.EndArea();
	}
}