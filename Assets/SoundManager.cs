using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip Explosion;
    public AudioClip Coin;
	public AudioClip goal;
    public AudioSource source;
    public static SoundManager manager;

	public void Awake()
	{
		if(manager == null)
		{
			manager = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
		
	}

	public static void PlayExplosion()
	{
		manager.source.PlayOneShot(manager.Explosion);
	}

	public static void PlayCoin()
	{
		manager.source.PlayOneShot(manager.Coin);
	}

	public static void PlayGoal()
	{
		manager.source.PlayOneShot(manager.goal);
	}

}
