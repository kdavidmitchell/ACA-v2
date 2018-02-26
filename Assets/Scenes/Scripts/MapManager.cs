﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour 
{

	public static List<GameObject> _pins = new List<GameObject>();
	
	public GameObject _questFrame;

	void Awake()
	{
		LoadInformation.LoadAllInformation();
	}

	// Use this for initialization
	void Start () 
	{	
		for (int i = 0; i < QuestDB.quests.Count; i++) 
		{
			_pins.Add(GameObject.Find("Quest_Pin_" + (i+1)));
		}

		QuestPinSetup();
		DisableAllPinHovers();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void QuestPinSetup()
	{	
		for (int i = 0; i < QuestDB.quests.Count; i++) 
		{
			QuestPin pin;
			pin = GameObject.Find("Quest_Pin_" + (i+1)).GetComponent<QuestPin>();
			pin.PinQuest = QuestDB.quests[i];

			Text title;
			title = GameObject.Find("Quest_Pin_" + (i+1) + "_Title_Text").GetComponent<Text>();
			title.text = pin.PinQuest.QuestTitle;
			Debug.Log(pin.PinQuest.QuestTitle);

			Text description;
			description = GameObject.Find("Quest_Pin_" + (i+1) + "_Description").GetComponent<Text>();
			description.text = pin.PinQuest.QuestDescription;
		}
	}

	public void DisableAllPinHovers()
	{
		foreach (GameObject pin in _pins)
		{
			pin.GetComponent<QuestPin>()._hoverMenu.SetActive(false);
		}
	}

	public void DisableAllPins()
	{
		foreach (GameObject pin in _pins)
		{
			pin.SetActive(false);
		}
	}

	public static void EnableActivePins()
	{
		foreach (GameObject pin in _pins)
		{
			pin.SetActive(true);
		}
	}

	public static void RemovePinFromActiveList(int index)
	{
		_pins.RemoveAt(index - 1);
	}
}
