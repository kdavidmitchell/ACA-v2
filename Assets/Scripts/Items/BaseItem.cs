using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class BaseItem 
{

	private string _name;
	private string _description;
	private string _useText;
	private int _ID;
	private int _value;
	private List<BaseStat> _stats = new List<BaseStat>();
	private List<int> _modifiers = new List<int>();
	private ItemTypes _type;

	public BaseItem(Dictionary<string,string> itemDictionary)
	{
		string[] delimiter = new string[] {" "};

		_name = itemDictionary["Name"];
		_description = itemDictionary["Description"];
		_useText = itemDictionary["UseText"];
		_ID = int.Parse(itemDictionary["ID"]);
		_value = int.Parse(itemDictionary["Value"]);
		_type = (ItemTypes)System.Enum.Parse(typeof(BaseItem.ItemTypes), itemDictionary["Type"].ToString());

		string[] tempStats = itemDictionary["Stats"].Split(delimiter, StringSplitOptions.None);
		for (int i = 0; i < tempStats.Length; i++)
		{
			_stats.Add(BaseStat.Parse(tempStats[i]));	
		}

		string[] tempModifiers = itemDictionary["Modifier"].Split(delimiter, StringSplitOptions.None);
		for (int i = 0; i < tempModifiers.Length; i++)
		{
			_modifiers.Add(int.Parse(tempModifiers[i]));
		}
	}

	public enum ItemTypes
	{
		EQUIPMENT,
		WEAPON,
		CONSUMABLE
	}

	public string ItemName
	{
		get { return _name; }
		set { _name = value;}
	}

	public string ItemDescription
	{
		get { return _description; }
		set { _description = value;}
	}

	public string ItemUseText
	{
		get { return _useText; }
		set { _useText = value;}
	}

	public int ItemID 
	{
		get { return _ID; }
		set { _ID = value;}
	}

	public int ItemValue
	{
		get { return _value; }
		set { _value = value;}
	}

	public List<BaseStat> ItemStats
	{
		get { return _stats; }
		set { _stats = value;}
	}

	public List<int> ItemModifiers
	{
		get { return _modifiers; }
		set { _modifiers = value;}
	}

	public ItemTypes ItemType
	{
		get { return _type; }
		set { _type = value;}
	}
}
