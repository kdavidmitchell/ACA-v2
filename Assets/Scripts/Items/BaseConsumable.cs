using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseConsumable : BaseItem 
{

	private int _power;

	public BaseConsumable()
	{
		//constructor
	}

	public int Power
	{
		get { return _power; }
		set { _power = value; }
	}
}
