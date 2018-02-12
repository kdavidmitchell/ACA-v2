using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{

	private string _title;
	private string _description;
	private string _text1;
	private string _text2;
	private string _text3;
	private List<Dictionary<string, int>> _responses1;
	private List<Dictionary<string, int>> _responses2;
	private List<Dictionary<string, int>> _responses3;
	private bool _combat;
	private List<int> _xp;
	private List<int> _followers;
	private List<int> _item;

	public Quest()
	{
		// constructor
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
