using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseEquipment : BaseItem 
{

	private EquipmentTypes _type;

	public enum EquipmentTypes
	{
		BODY,
		HEAD,
		FEET,
		ACCESSORY
	}

	public EquipmentTypes EquipmentType
	{
		get { return _type; }
		set { _type = value; }
	}
}
