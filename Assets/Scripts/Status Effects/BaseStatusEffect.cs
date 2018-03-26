using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseStatusEffect
{

	private string _name;
	private string _description;
	private int _ID;
	private StatusEffectTypes _type;
	private int _duration;
	private int _damageOverTime;

	public enum StatusEffectTypes
	{
		HARASS,
		SLEEP,
		STUN
	}

	public BaseStatusEffect(Dictionary<string, string> effectDictionary)
	{
		_name = effectDictionary["Name"];
		_description = effectDictionary["Description"];
		_ID = int.Parse(effectDictionary["ID"]);
		_type = (StatusEffectTypes)System.Enum.Parse(typeof(BaseStatusEffect.StatusEffectTypes), effectDictionary["Type"].ToString());
		_duration = int.Parse(effectDictionary["Duration"]);
		_damageOverTime = int.Parse(effectDictionary["Damage"]);
	}

	public string EffectName
	{
		get { return _name; }
		set { _name = value; }
	}

	public string EffectDescription
	{
		get { return _description; }
		set { _description = value; }
	}

	public int EffectID
	{
		get { return _ID; }
		set { _ID = value; }
	}

	public StatusEffectTypes EffectType
	{
		get { return _type; }
		set { _type = value; }
	}

	public int EffectDuration
	{
		get { return _duration; }
		set { _duration = value; }
	}

	public int EffectDOT
	{
		get { return _damageOverTime; }
		set { _damageOverTime = value; }
	}
}
