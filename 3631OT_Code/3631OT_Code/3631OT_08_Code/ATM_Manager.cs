using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ATM_Manager : MonoBehaviour
{
	public List<AudioClip> tmpList = new List<AudioClip>();
	public List<string> keys = new List<string>();
	private List<KeyValuePair<string, AudioClip>> atmListt = new List<KeyValuePair<string, AudioClip>>();
	public float atmVolume = 1.00f;
	
	void Start()
	{
		audio.volume = atmVolume;
		int i = 0;
		atmListt.Capacity = keys.Capacity;
		foreach(AudioClip ac in tmpList)
		{
			atmListt.Add(new KeyValuePair<string, AudioClip>(keys[i], ac));
			i++;
		}
	}

	void PlayRepeat(string atmSong)
	{
		for(int i = 0; i < atmListt.Count; i++)
		{
			if(atmListt[i].Key == atmSong)
			{
				audio.clip = atmListt[i].Value;
				break;
			}
		}

		audio.loop = true;
		audio.Play();
	}

	void Play(string atmSong)
	{
		for(int i = 0; i < atmListt.Count; i++)
		{
			if(atmListt[i].Key == atmSong)
			{
				audio.clip = atmListt[i].Value;
				break;
			}
		}

		audio.Play();
	}
}