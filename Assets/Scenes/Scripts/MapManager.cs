using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour 
{

	public static List<GameObject> _pins = new List<GameObject>();
	public static List<RandomEvent> _events = new List<RandomEvent>();
	public static MapManager instance = null;
	
	public GameObject _questFrame;

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

		LoadInformation.LoadAllInformation();
	}

	// Use this for initialization
	void Start () 
	{	
		SaveInformation.SaveAllInformation();

		_events = RandomEventDB.events;

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
			_pins.Add(GameObject.Find("Quest_Pin_" + (i+1)));
		}

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
		_pins.RemoveAt(ParseIndex(index));
	}

	public static void RemoveEventFromActiveList(int id)
	{
		_events.RemoveAt(ParseEventIndex(id));
	}

	public static int ParseIndex(int index)
	{
		int result;
		GameObject pin = null;

		for (int i = 1; i < 11; i++)
		{
			if (index == i)
			{
				foreach (GameObject _pin in _pins)
				{
					if (_pin.name == ("Quest_Pin_" + i))
					{
						pin = _pin;
					}
				}
			}
		}

		result = _pins.IndexOf(pin);
		return result;
	}

	public static int ParseEventIndex(int id)
	{
		int result;
		RandomEvent randomEvent = null;
		Debug.Log(id);

		foreach (RandomEvent _event in _events)
		{
			Debug.Log(_event.EventID);
			if (_event.EventID == id)
			{
				randomEvent = _event;
			}
		}

		result = _events.IndexOf(randomEvent);
		return result;
	}
}
