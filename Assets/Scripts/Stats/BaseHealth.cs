using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseHealth : BaseStat 
{

	public BaseHealth()
	{
		StatName = "Health";
		StatDescription = "A measure of your political resilience.";
		StatType = StatTypes.HEALTH;
		StatBaseValue = 0;
		StatModifiedValue = 0;
		StatCost = new List<int>();

		for (int i = 1; i < 4; i++) 
		{
			StatCost.Add(30 * i);
		}
	}
	
}
