using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class BaseAbility
{

	private string _name;
	private string _description;
	private int _ID;
	private AbilityTypes _type;
	private List<int> _damage;
	private List<int> _cost;
	private int _currentRank;
	private int _maxRank;
	private List<int> _xpToLevel;

	public enum AbilityTypes
	{
		COMBAT,
		PASSIVE
	}

	public BaseAbility(Dictionary<string, string> abilityDictionary)
	{
		string[] delimiter = new string[] {" "};

		_name = abilityDictionary["Name"];
		_description = abilityDictionary["Description"];
		_ID = int.Parse(abilityDictionary["ID"]);
		_type = (AbilityTypes)System.Enum.Parse(typeof(BaseAbility.AbilityTypes), abilityDictionary["Type"].ToString());
		_currentRank = int.Parse(abilityDictionary["CurrentRank"]);
		_maxRank = int.Parse(abilityDictionary["MaxRank"]);

		string[] tempDamage = abilityDictionary["Damage"].Split(delimiter, StringSplitOptions.None);
		for (int i = 0; i < tempDamage.Length; i++)
		{
			_damage.Add(int.Parse(tempDamage[i]));	
		}

		string[] tempCost = abilityDictionary["Cost"].Split(delimiter, StringSplitOptions.None);
		for (int i = 0; i < tempCost.Length; i++)
		{
			_cost.Add(int.Parse(tempCost[i]));
		}

		string[] tempXPToLevel = abilityDictionary["XPToLevel"].Split(delimiter, StringSplitOptions.None);
		for (int i = 0; i < tempXPToLevel.Length; i++)
		{
			_xpToLevel.Add(int.Parse(tempXPToLevel[i]));
		}
	}

	public string AbilityName
	{
		get { return _name; }
		set { _name = value; }
	}

	public string AbilityDescription
	{
		get { return _description; }
		set { _description = value; }
	}

	public int AbilityID
	{
		get { return _ID; }
		set { _ID = value; }
	}

	public AbilityTypes AbilityType
	{
		get { return _type; }
		set { _type = value; }
	}

	public List<int> AbilityDamage
	{
		get { return _damage; }
		set { _damage = value; }
	}

	public List<int> AbilityCost
	{
		get { return _cost; }
		set { _cost = value; }
	}

	public int AbilityCurrentRank
	{
		get { return _currentRank; }
		set { _currentRank = value; }
	}

	public int AbilityMaxRank
	{
		get { return _maxRank; }
		set { _maxRank = value; }
	}

	public List<int> AbilityXPToLevel
	{
		get { return _xpToLevel; }
		set { _xpToLevel = value; }
	}
}
