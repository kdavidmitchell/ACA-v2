using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseEloquence : BaseStat
{

	public BaseEloquence()
	{
		StatName = "Eloquence";
		StatDescription = "A measure of how quick and to-the-point you can be.";
		StatType = StatTypes.ELOQUENCE;
		StatBaseValue = 0;
		StatModifiedValue = 0;
		StatCost = new List<int>();

		for (int i = 1; i < 4; i++) 
		{
			StatCost.Add(50 * i);
		}
	}
}
