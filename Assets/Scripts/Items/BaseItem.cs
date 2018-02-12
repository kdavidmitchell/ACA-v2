using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseItem 
{

	private string _name;
	private string _description;
	private int _ID;
	private int _value;
	private List<BaseStat> _stats;
	private ItemTypes _type;

	public BaseItem()
	{
		//constructor
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

	public ItemTypes ItemType
	{
		get { return _type; }
		set { _type = value;}
	}
}
