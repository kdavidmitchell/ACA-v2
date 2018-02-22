using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCManager : MonoBehaviour 
{
	private BasePlayer _newPlayer = new BasePlayer();
	
	private Image _selectedPortrait;

	public GameObject _question1;
	public GameObject _confirmation1;
	public GameObject _portraitHolder;
	public GameObject _question2;

	// Use this for initialization
	void Start () 
	{
		_confirmation1.SetActive(false);
		_question2.SetActive(false);
	}

	public void DeterminePlayerPortrait(int index)
	{
		_selectedPortrait = GameObject.Find("Image_" + index).GetComponent<Image>();
		_newPlayer.PlayerPortrait = _selectedPortrait;
		GameInformation.PlayerPortrait = _selectedPortrait;

		_confirmation1.SetActive(true);
	}

	public void EnableQuestion2()
	{
		_question1.SetActive(false);
		_portraitHolder.SetActive(false);
		_question2.SetActive(true);
		_confirmation1.SetActive(false);
	}
}
