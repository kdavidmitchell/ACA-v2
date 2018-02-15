using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseWeapon : BaseItem 
{

	private WeaponTypes _type;

	public enum WeaponTypes
	{
		MICROPHONE,
		BRIEFCASE,
		PIPE
	}

	public BaseWeapon(Dictionary<string,string> itemDictionary) : base(itemDictionary)
	{
		_type = (WeaponTypes)System.Enum.Parse(typeof(BaseItem.ItemTypes), itemDictionary["Type"].ToString());
	}

	public WeaponTypes WeaponType
	{
		get { return _type; }
		set { _type = value; }
	}
}
