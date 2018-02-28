using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseStat 
{

	private string _name;
	private string _description;
	private int _baseValue;
	private int _modifiedValue;
	private StatTypes _type;
	private List<int> _cost;

	public enum StatTypes 
	{
		RHETORIC,
		IMAGE,
		DIPLOMACY,
		HEALTH,
		AMBITION,
		ELOQUENCE
	}

	public static BaseStat Parse(string name)
	{
		if (name == "RHETORIC")
		{
			return new BaseRhetoric();
		} else if (name == "IMAGE")
		{
			return new BaseImage();
		} else if (name == "DIPLOMACY")
		{
			return new BaseDiplomacy();
		} else if (name == "HEALTH") 
		{
			return new BaseHealth();
		} else if (name == "AMBITION") 
		{
			return new BaseAmbition();
		} else if (name == "ELOQUENCE")
		{
			return new BaseEloquence();
		} else
		{
			return null;
		}
	}

	public string StatName 
	{
		get { return _name; }
		set { _name = value; }
	}

	public string StatDescription 
	{
		get { return _description; }
		set { _description = value; }
	}

	public int StatBaseValue 
	{
		get { return _baseValue; }
		set { _baseValue = value; }
	}

	public int StatModifiedValue 
	{
		get { return _modifiedValue; }
		set { _modifiedValue = value; }
	}

	public StatTypes StatType 
	{
		get { return _type; }
		set { _type = value; }
	}

	public List<int> StatCost
	{
		get { return _cost; }
		set { _cost = value; }
	}	
}
