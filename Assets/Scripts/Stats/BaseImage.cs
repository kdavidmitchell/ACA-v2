using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseImage : BaseStat 
{

	public BaseImage()
	{
		StatName = "Image";
		StatDescription = "How good you look in the public eye.";
		StatType = StatTypes.IMAGE;
		StatBaseValue = 0;
		StatModifiedValue = 0;
	}
}
