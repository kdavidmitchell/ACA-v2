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
	}
}
