using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RandomEvent 
{

	private int _ID;
	private string _title;
	private string _description;
	private string _option1;
	private string _option2;
	private int _check1;
	private int _check2;
	private string _resolution1;
	private string _resolution2;
	private int _xp;
	private int _money;
	private int _followers;
	private int _item;
	private int _enemy;
	private EventTypes _type;

	public enum EventTypes
	{
		OPPORTUNITY,
		CHALLENGE
	}

	public RandomEvent(Dictionary<string, string> eventDictionary)
	{
		_ID = int.Parse(eventDictionary["ID"]);
		_title = eventDictionary["Title"];
		_description = eventDictionary["Description"];
		_option1 = eventDictionary["Option1"];
		_option2 = eventDictionary["Option2"];
		_check1 = int.Parse(eventDictionary["Check1"]);
		_check2 = int.Parse(eventDictionary["Check2"]);
		_resolution1 = eventDictionary["Resolution1"];
		_resolution2 = eventDictionary["Resolution2"];
		_xp = int.Parse(eventDictionary["XP"]);
		_money = int.Parse(eventDictionary["Money"]);
		_followers = int.Parse(eventDictionary["Followers"]);
		_item = int.Parse(eventDictionary["Item"]);
		_enemy = int.Parse(eventDictionary["Enemy"]);
		_type = (EventTypes)System.Enum.Parse(typeof(RandomEvent.EventTypes), eventDictionary["Type"].ToString());
	}

	public int EventID
	{
		get { return _ID; }
		set {_ID = value; }
	}

	public string EventTitle
	{
		get { return _title; }
		set {_title = value; }
	}

	public string EventDescription
	{
		get { return _description; }
		set {_description = value; }
	}

	public string EventOption1 
	{
		get { return _option1; }
		set {_option1 = value; }
	}

	public string EventOption2 
	{
		get { return _option2; }
		set {_option2 = value; }
	}

	public int EventCheck1 
	{
		get { return _check1; }
		set {_check1 = value; }
	}

	public int EventCheck2 
	{
		get { return _check2; }
		set {_check2 = value; }
	}

	public string EventResolution1
	{
		get { return _resolution1; }
		set {_resolution1 = value; }
	}

	public string EventResolution2
	{
		get { return _resolution2; }
		set {_resolution2 = value; }
	}

	public int EventXPReward
	{
		get { return _xp; }
		set {_xp = value; }
	}

	public int EventMoneyReward
	{
		get { return _money; }
		set {_money = value; }
	}

	public int EventFollowersReward
	{
		get { return _followers; }
		set {_followers = value; }
	}

	public int EventItemReward
	{
		get { return _item; }
		set {_item = value; }
	}

	public int EventEnemy
	{
		get { return _enemy; }
		set { _enemy = value; }
	}

	public EventTypes EventType
	{
		get { return _type; }
		set {_type = value; }
	}
}
