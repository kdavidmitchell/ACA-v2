using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseConsumable : BaseItem 
{

	private int _power;

	public BaseConsumable(Dictionary<string,string> itemDictionary) : base(itemDictionary)
	{
		_power = base.ItemModifiers[0];
	}

	public int Power
	{
		get { return _power; }
		set { _power = value; }
	}
}
