using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class BaseClass 
{

	private string _name;
	private string _description;
	private int _ID;
	private ClassTypes _type;
	private List<BaseStat> _stats = new List<BaseStat>();
	private List<BaseAbility> _abilities = new List<BaseAbility>();

	public enum ClassTypes
	{
		GLADHANDER,
		CHIEF,
		SOPHIST,
		NULL
	}

	public BaseClass(Dictionary<string, string> classDictionary)
	{
		string[] delimiter = new string[] {" "};

		_name = classDictionary["Name"];
		_description = classDictionary["Description"];
		_ID = int.Parse(classDictionary["ID"]);
		_type = (ClassTypes)System.Enum.Parse(typeof(BaseClass.ClassTypes), classDictionary["Type"].ToString());
		_stats.Add(new BaseRhetoric());
		_stats.Add(new BaseImage());
		_stats.Add(new BaseDiplomacy());
		_stats.Add(new BaseHealth());
		_stats.Add(new BaseAmbition());
		_stats.Add(new BaseEloquence());

		string[] tempStats = classDictionary["Stats"].Split(delimiter, StringSplitOptions.None);
		for (int i = 0; i < tempStats.Length; i++)
		{
			_stats[i].StatBaseValue = int.Parse(tempStats[i]);
			_stats[i].StatModifiedValue = int.Parse(tempStats[i]);	
		}

		string[] tempAbilities = classDictionary["Abilities"].Split(delimiter, StringSplitOptions.None);
		for (int i = 0; i < tempAbilities.Length; i++)
		{
			_abilities.Add(AbilityDB.abilities[int.Parse(tempAbilities[i]) - 1]);
		}
	}

	public BaseClass()
	{
		_name = "Default";
		_description = "Default";
		_ID = 0;
		_type = ClassTypes.NULL;
		_stats = null;
		_abilities = null;
	}

	public BaseClass(ClassTypes type, List<BaseClass> classes)
	{
		if (type == ClassTypes.GLADHANDER)
		{
			_name = classes[0].ClassName;
			_description = classes[0].ClassDescription;
			_ID = classes[0].ClassID;
			_type = type;
			_stats = classes[0].ClassStats;
			_abilities = classes[0].ClassAbilities;
		}

		if (type == ClassTypes.CHIEF)
		{
			_name = classes[1].ClassName;
			_description = classes[1].ClassDescription;
			_ID = classes[1].ClassID;
			_type = type;
			_stats = classes[1].ClassStats;
			_abilities = classes[1].ClassAbilities;
		}

		if (type == ClassTypes.SOPHIST)
		{
			_name = classes[2].ClassName;
			_description = classes[2].ClassDescription;
			_ID = classes[2].ClassID;
			_type = type;
			_stats = classes[2].ClassStats;
			_abilities = classes[2].ClassAbilities;
		}
	}

	public string ClassName
	{
		get { return _name; }
		set { _name = value; }
	}

	public string ClassDescription
	{
		get { return _description; }
		set { _description = value; }
	}

	public int ClassID
	{
		get { return _ID; }
		set { _ID = value; }
	}

	public ClassTypes ClassType
	{
		get { return _type; }
		set { _type = value; }
	}

	public List<BaseStat> ClassStats
	{
		get { return _stats; }
		set { _stats = value; }
	}

	public List<BaseAbility> ClassAbilities
	{
		get { return _abilities; }
		set { _abilities = value; }
	}

}
