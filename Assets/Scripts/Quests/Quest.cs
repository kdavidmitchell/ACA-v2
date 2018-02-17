using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{

	private int _ID;
	private string _title;
	private string _description;
	private string _text1;
	private string _text2;
	private string _text3;
	private List<Dictionary<string, int>> _responses1 = new List<Dictionary<string, int>>();
	private List<Dictionary<string, int>> _responses2 = new List<Dictionary<string, int>>();
	private List<Dictionary<string, int>> _responses3 = new List<Dictionary<string, int>>();
	private bool _combat;
	private List<int> _xp = new List<int>();
	private List<int> _followers = new List<int>();
	private List<int> _item = new List<int>();

	public Quest(Dictionary<string, string> questDictionary, Dictionary<string, string> response1Dictionary, 
		Dictionary<string, string> response2Dictionary, Dictionary<string, string> response3Dictionary,
		Dictionary<string, string> xpDictionary, Dictionary<string, string> followersDictionary, 
		Dictionary<string, string> itemDictionary)
	{
		_ID = int.Parse(questDictionary["ID"]);
		_title = questDictionary["Title"];
		_description = questDictionary["Description"];
		_text1 = questDictionary["Text1"];
		_text2 = questDictionary["Text2"];
		_text3 = questDictionary["Text3"];
		
		for (int i = 1; i < response1Dictionary.Count + 1; i++)
		{
			Dictionary<string, int> tempResponse1Dictionary = new Dictionary<string, int>();
			tempResponse1Dictionary.Add(response1Dictionary["Option" + i], int.Parse(response1Dictionary["Check" + i]));
			_responses1.Add(tempResponse1Dictionary);
		}

		for (int i = 1; i < response2Dictionary.Count + 1; i++)
		{
			Dictionary<string, int> tempResponse2Dictionary = new Dictionary<string, int>();
			tempResponse2Dictionary.Add(response2Dictionary["Option" + i], int.Parse(response2Dictionary["Check" + i]));
			_responses2.Add(tempResponse2Dictionary);
		}

		for (int i = 1; i < response3Dictionary.Count + 1; i++)
		{
			Dictionary<string, int> tempResponse3Dictionary = new Dictionary<string, int>();
			tempResponse3Dictionary.Add(response3Dictionary["Option" + i], int.Parse(response3Dictionary["Check" + i]));
			_responses3.Add(tempResponse3Dictionary);
		}

		_combat = false;
		if (questDictionary["Combat"] == "True")
		{
			_combat = true;
		}

		for (int i = 1; i < xpDictionary.Count + 1; i++)
		{
			_xp.Add(int.Parse(xpDictionary["Tier" + i]));
		}

		for (int i = 1; i < followersDictionary.Count + 1; i++)
		{
			_followers.Add(int.Parse(followersDictionary["Tier" + i]));
		}

		for (int i = 1; i < itemDictionary.Count + 1; i++)
		{
			if (itemDictionary["Tier" + i] != "Null")
			{
				_item.Add(int.Parse(itemDictionary["Tier" + i]));
			}
		}
	}	

	public int QuestID
	{
		get { return _ID; }
		set {_ID = value; }
	}

	public string QuestTitle 
	{
		get { return _title; }
		set {_title = value; }
	}

	public string QuestDescription 
	{
		get { return _description; }
		set {_description = value; }
	}

	public string QuestText1 
	{
		get { return _text1; }
		set {_text1 = value; }
	}

	public string QuestText2 
	{
		get { return _text2; }
		set {_text2 = value; }
	}

	public string QuestText3 
	{
		get { return _text3; }
		set {_text3 = value; }
	}

	public List<Dictionary<string, int>> QuestResponses1 
	{
		get { return _responses1; }
		set {_responses1 = value; }
	}

	public List<Dictionary<string, int>> QuestResponses2 
	{
		get { return _responses2; }
		set {_responses2 = value; }
	}

	public List<Dictionary<string, int>> QuestResponses3 
	{
		get { return _responses3; }
		set {_responses3 = value; }
	}

	public bool QuestCombat
	{
		get { return _combat; }
		set {_combat = value; }
	}

	public List<int> QuestXPReward
	{
		get { return _xp; }
		set {_xp = value; }
	}

	public List<int> QuestFollowerReward
	{
		get { return _followers; }
		set {_followers = value; }
	}

	public List<int> QuestItemReward
	{
		get { return _item; }
		set {_item = value; }
	}
}
