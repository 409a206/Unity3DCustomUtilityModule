using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;

public class FLAT_Save_System : MonoBehaviour
{
	public string sFileName;
	public string sDirectory;
	
	public GameObject Player;

	void WriteToFile(string file = "")
	{
		if(file != "")
			sFileName = file;

		if(File.Exists(sDirectory + sFileName))
		{
			DeleteFile(sFileName);
		}

		using(StreamWriter sw = new StreamWriter(sDirectory + sFileName))
		{
			sw.WriteLine(PlayerPrefs.GetInt("PlayerKills").ToString());
			sw.WriteLine(PlayerPrefs.GetInt("PlayerDeaths").ToString());
			sw.WriteLine(PlayerPrefs.GetInt("PlayerTotalGold").ToString());
			sw.WriteLine(PlayerPrefs.GetInt("PlayerCurrentGold").ToString());
			sw.WriteLine(PlayerPrefs.GetInt("PlayerGoldSpent").ToString());
			sw.WriteLine(PlayerPrefs.GetInt("PlayerLevel").ToString());
			sw.WriteLine(PlayerPrefs.GetInt("PlayerRoundsWon").ToString());
			sw.WriteLine(PlayerPrefs.GetInt("PlayerRoundsLost").ToString());
			sw.WriteLine(PlayerPrefs.GetFloat("PlayerKDR").ToString());
			sw.WriteLine(PlayerPrefs.GetFloat("PlayerWLR").ToString());
			sw.WriteLine(PlayerPrefs.GetFloat("PlayerTimePlayed").ToString());
			sw.WriteLine(Player.transform.position.x.ToString());
			sw.WriteLine(Player.transform.position.y.ToString());
			sw.WriteLine(Player.transform.position.z.ToString());
		}
	}

	void DeleteFile(string file = "")
	{
		File.Delete(sDirectory + file);
	}

	void ReadFile(string file = "")
	{
		if(file != "")
			sFileName = file;

		using(StreamReader sr = new StreamReader(sDirectory + sFileName))
		{
			int kills = Convert.ToInt32(sr.ReadLine());
			int deaths = Convert.ToInt32(sr.ReadLine());
			int totgold = Convert.ToInt32(sr.ReadLine());
			int curgold = Convert.ToInt32(sr.ReadLine());
			int level = Convert.ToInt32(sr.ReadLine());
			int rwon = Convert.ToInt32(sr.ReadLine());
			int rlost = Convert.ToInt32(sr.ReadLine());
			float pkdr = Convert.ToSingle(sr.ReadLine());
			float pwlr = Convert.ToSingle(sr.ReadLine());
			float ptime = Convert.ToSingle(sr.ReadLine());
			float x = Convert.ToSingle(sr.ReadLine());
			float y = Convert.ToSingle(sr.ReadLine());
			float z = Convert.ToSingle(sr.ReadLine());
			Player.transform.position = new Vector3(x, y, z);
		}
	}
}