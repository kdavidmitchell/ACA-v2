using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour 
{

	private SoundManager sm;
	private Button button;

	// Use this for initialization
	void Start () 
	{
		sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
		button = GetComponent<Button>();

		button.onClick.AddListener(() => sm.Mute());
	}
}
