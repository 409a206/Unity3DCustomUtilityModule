using UnityEngine;
using System.Collections;
public class SFX_Manager : MonoBehaviour
{
	public AudioClip Run, Spell, Strike;
	public float sfxVolume = 1.00f;
	
	void Start()
	{
		audio.volume = sfxVolume;
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.W))
			pRun();
		
		if(Input.GetButtonUp("Fire1"))
			pStrike();

		if(Input.GetButtonUp("Fire2"))
			pSpell();
	}

	void pRun()
	{
		if(!audio.isPlaying)
		{
			audio.clip = Run;
			audio.Play();
		}
	}

	void pSpell()
	{
		audio.clip = Spell;
		audio.Play();
	}
	
	void pStrike()
	{
		audio.clip = Strike;
		audio.Play();
	}
}