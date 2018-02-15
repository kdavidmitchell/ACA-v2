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

	public BaseEquipment(Dictionary<string,string> itemDictionary) : base(itemDictionary)
	{
		_type = (EquipmentTypes)System.Enum.Parse(typeof(BaseItem.ItemTypes), itemDictionary["Type"].ToString());
	}

	public EquipmentTypes EquipmentType
	{
		get { return _type; }
		set { _type = value; }
	}
}
