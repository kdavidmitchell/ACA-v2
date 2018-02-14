using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RandomEvent 
{

	private int _ID;
	private string _title;
	private string _description;
	private List<Dictionary<string, int>> _options;
	private string _resolution1;
	private string _resolution2;
	private int _xp;
	private int _money;
	private int _followers;
	private int _item;
	private EventTypes _type;

	public enum EventTypes
	{
		OPPORTUNITY,
		CHALLENGE
	}

	public RandomEvent()
	{
		// constructor
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
		get { return _title; }
		set {_title = value; }
	}

	public List<Dictionary<string, int>> EventOptions 
	{
		get { return _options; }
		set {_options = value; }
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

	public EventTypes EventType
	{
		get { return _type; }
		set {_type = value; }
	}
}
