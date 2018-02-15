using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseAmbition : BaseStat 
{

	public BaseAmbition()
	{
		StatName = "Ambition";
		StatDescription = "A measure of your political aptitude.";
		StatType = StatTypes.AMBITION;
		StatBaseValue = 0;
		StatModifiedValue = 0;
	}
}
