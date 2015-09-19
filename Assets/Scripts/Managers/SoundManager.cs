using UnityEngine;
using System.Collections;

public class SoundManager : Singleton<SoundManager> {

	private AudioSource source;

	void Start () 
	{
		source = GetComponent<AudioSource>();
	}

	public void PlayOnce(AudioClip clip)
	{
		source.PlayOneShot(clip);
	}
}
