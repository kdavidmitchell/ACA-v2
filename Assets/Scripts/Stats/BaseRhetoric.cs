using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseRhetoric : BaseStat 
{

	public BaseRhetoric()
	{
		StatName = "Rhetoric";
		StatDescription = "It's how you win arguments.";
		StatType = StatTypes.RHETORIC;
		StatBaseValue = 0;
		StatModifiedValue = 0;
		StatCost = new List<int>();

		for (int i = 1; i < 4; i++) 
		{
			StatCost.Add(20 * i);
		}
	}
}
