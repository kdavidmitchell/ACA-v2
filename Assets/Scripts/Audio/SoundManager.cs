using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour 
{

	private AudioSource currentSource = null;
	private AudioSource currentEfx;

	public AudioSource[] efxSources;
	public AudioSource[] musicSources;
	public static SoundManager instance = null;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		} else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
		SwitchTrack(0);
	}

	public void StopTrack()
	{
		if (currentSource != null)
		{
			currentSource.Stop();
		}
	}

	public void SwitchTrack(int sceneIndex)
	{
		currentSource = musicSources[sceneIndex];
		currentSource.loop = true;
		currentSource.Play();
	}

	void OnLevelWasLoaded(int level)
	{
		if (level == 0 || level == 1)
		{
			return;
		}

		StopTrack();
		SwitchTrack(level - 1);
	}

	public void Mute()
	{
		currentSource.mute = !currentSource.mute; 
	}

	public void PlaySingleEfx(int index)
	{
		currentEfx = efxSources[index];
		currentEfx.Play();
	}
}
