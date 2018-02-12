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

	public WeaponTypes WeaponType
	{
		get { return _type; }
		set { _type = value; }
	}
}
