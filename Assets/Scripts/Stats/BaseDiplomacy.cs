﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseDiplomacy : BaseStat 
{

	public BaseDiplomacy()
	{
		StatName = "Diplomacy";
		StatDescription = "A measure of your fortitude and strength.";
		StatType = StatTypes.DIPLOMACY;
		StatBaseValue = 0;
		StatModifiedValue = 0;
		StatCost = new List<int>();

		for (int i = 1; i < 4; i++) 
		{
			StatCost.Add(20 * i);
		}
	}
}
