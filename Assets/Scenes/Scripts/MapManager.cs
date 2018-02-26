using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour 
{

	public GameObject _questFrame;

	void Awake()
	{
		LoadInformation.LoadAllInformation();
	}

	// Use this for initialization
	void Start () 
	{	
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
		for (int i = 0; i < QuestDB.quests.Count; i++) 
		{
			QuestPin pin;
			pin = GameObject.Find("Quest_Pin_" + (i+1)).GetComponent<QuestPin>();
			pin._hoverMenu.SetActive(false);
		}
	}

	public void DisableAllPins()
	{
		for (int i = 0; i < QuestDB.quests.Count; i++) 
		{
			GameObject pin = GameObject.Find("Quest_Pin_" + (i+1));
			pin.SetActive(false);
		}
	}
}
