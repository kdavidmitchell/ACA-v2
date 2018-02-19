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

	public enum ClassTypes
	{
		GLADHANDER,
		CHIEF,
		SOPHIST
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

		string[] tempStats = classDictionary["Stats"].Split(delimiter, StringSplitOptions.None);
		for (int i = 0; i < tempStats.Length; i++)
		{
			_stats[i].StatBaseValue = int.Parse(tempStats[i]);	
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

}
