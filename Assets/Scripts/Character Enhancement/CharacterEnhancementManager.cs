using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEnhancementManager : MonoBehaviour 
{

	private bool _enhancementIsActive;
	
	public GameObject enhancementPanel;

	// Use this for initialization
	void Start () 
	{
		enhancementPanel.SetActive(false);
		_enhancementIsActive = true;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			_enhancementIsActive = !_enhancementIsActive;
			enhancementPanel.SetActive(!_enhancementIsActive);
		}	
	}
}
