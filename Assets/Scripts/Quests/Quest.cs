using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Quest 
{

	private int _ID;
	private string _title;
	private string _description;
	private string _text1;
	private string _text2;
	private string _text3;
	private List<string> _responses1 = new List<string>();
	private List<string> _responses2 = new List<string>();
	private List<string> _responses3 = new List<string>();
	private List<int> _checks1 = new List<int>();
	private List<int> _checks2 = new List<int>();
	private List<int> _checks3 = new List<int>();
	private bool _combat;
	private List<int> _xp = new List<int>();
	private List<int> _followers = new List<int>();
	private List<int> _items = new List<int>();

	public Quest(Dictionary<string, string> questDictionary)
	{
		string[] delimiter1 = new string[] {" "};
		string[] delimiter2 = new string[] {";"};

		_ID = int.Parse(questDictionary["ID"]);
		_title = questDictionary["Title"];
		_description = questDictionary["Description"];
		_text1 = questDictionary["Text1"];
		_text2 = questDictionary["Text2"];
		_text3 = questDictionary["Text3"];
		
		string[] tempResponses1 = questDictionary["Responses1"].Split(delimiter2, StringSplitOptions.None);
		for (int i = 0; i < tempResponses1.Length; i++)
		{
			_responses1.Add(tempResponses1[i]);	
		}

		string[] tempResponses2 = questDictionary["Responses2"].Split(delimiter2, StringSplitOptions.None);
		for (int i = 0; i < tempResponses2.Length; i++)
		{
			_responses2.Add(tempResponses2[i]);	
		}

		string[] tempResponses3 = questDictionary["Responses3"].Split(delimiter2, StringSplitOptions.None);
		for (int i = 0; i < tempResponses3.Length; i++)
		{
			_responses3.Add(tempResponses3[i]);	
		}

		string[] tempChecks1 = questDictionary["Checks1"].Split(delimiter1, StringSplitOptions.None);
		for (int i = 0; i < tempChecks1.Length; i++)
		{
			_checks1.Add(int.Parse(tempChecks1[i]));	
		}

		string[] tempChecks2 = questDictionary["Checks2"].Split(delimiter1, StringSplitOptions.None);
		for (int i = 0; i < tempChecks2.Length; i++)
		{
			_checks2.Add(int.Parse(tempChecks2[i]));	
		}

		string[] tempChecks3 = questDictionary["Checks3"].Split(delimiter1, StringSplitOptions.None);
		for (int i = 0; i < tempChecks3.Length; i++)
		{
			_checks3.Add(int.Parse(tempChecks3[i]));	
		}

		_combat = false;
		if (questDictionary["Combat"] == "True")
		{
			_combat = true;
		}

		string[] tempXP = questDictionary["XP"].Split(delimiter1, StringSplitOptions.None);
		for (int i = 0; i < tempXP.Length; i++)
		{
			_xp.Add(int.Parse(tempXP[i]));	
		}

		string[] tempFollowers = questDictionary["Followers"].Split(delimiter1, StringSplitOptions.None);
		for (int i = 0; i < tempFollowers.Length; i++)
		{
			_followers.Add(int.Parse(tempFollowers[i]));	
		}

		string[] tempItems = questDictionary["Items"].Split(delimiter1, StringSplitOptions.None);
		for (int i = 0; i < tempItems.Length; i++)
		{
			_items.Add(int.Parse(tempItems[i]));	
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

	public List<string> QuestResponses1 
	{
		get { return _responses1; }
		set {_responses1 = value; }
	}

	public List<string> QuestResponses2 
	{
		get { return _responses2; }
		set {_responses2 = value; }
	}

	public List<string> QuestResponses3 
	{
		get { return _responses3; }
		set {_responses3 = value; }
	}

	public List<int> QuestChecks1 
	{
		get { return _checks1; }
		set {_checks1 = value; }
	}

	public List<int> QuestChecks2 
	{
		get { return _checks2; }
		set {_checks2 = value; }
	}

	public List<int> QuestChecks3 
	{
		get { return _checks3; }
		set {_checks3 = value; }
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
		get { return _items; }
		set {_items = value; }
	}
}
