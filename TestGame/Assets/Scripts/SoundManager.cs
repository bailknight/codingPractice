using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

	public AudioSource BGMSource;
	public AudioSource SFXSource;
	public AudioClip deathClip;
	public AudioClip coinClip;
	public AudioClip monsterDeathClip;


	void Start () 
	{
		BGMSource.Stop();
		instance = this;
	}

	public void PlayBGM()
	{
		BGMSource.Play();
	}

	public void MuteBGM()
	{
		BGMSource.Stop();
	}

	public void PlayCoinClip()
	{
		SFXSource.clip = coinClip;
		SFXSource.Play();
	}

	public void PlayDeathClip()
	{
		SFXSource.clip = deathClip;
		SFXSource.Play();
	}

	public void MonsterDeathClip()
	{
		SFXSource.clip = monsterDeathClip;
		SFXSource.Play();
	}
}
