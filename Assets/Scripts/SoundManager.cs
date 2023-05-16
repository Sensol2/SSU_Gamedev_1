using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ESoundType { Jump, GemTrigger };

public class SoundManager : MonoBehaviour
{
    static public SoundManager instance;
	public AudioClip[] sounds;
	AudioSource audioSource;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
	public void PlaySound(ESoundType state)
	{
		audioSource.clip = sounds[(int)state];
		audioSource.Play();
	}

}
