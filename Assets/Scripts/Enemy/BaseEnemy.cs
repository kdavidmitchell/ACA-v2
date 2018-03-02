using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseEnemy 
{

	private string _name;
	private int _ID;
	private BaseClass _class;
	private BaseClass.ClassTypes _type;
	private int _difficulty;

	public BaseEnemy(Dictionary<string, string> enemyDictionary)
	{
		_name = enemyDictionary["Name"];
		_ID = int.Parse(enemyDictionary["ID"]);
		_type = (BaseClass.ClassTypes)System.Enum.Parse(typeof(BaseClass.ClassTypes), enemyDictionary["Class"].ToString());
		_class = new BaseClass(_type, ClassDB.classes);
		_difficulty = int.Parse(enemyDictionary["Difficulty"]);
	}

	public string EnemyName
	{
		get { return _name; }
		set { _name = value; }
	}
	
	public int EnemyID
	{
		get { return _ID; }
		set { _ID = value; }
	}
	
	public BaseClass EnemyClass
	{
		get { return _class; }
		set { _class = value; }
	}

	public int EnemyDifficulty
	{
		get { return _difficulty; }
		set { _difficulty = value; }
	}
}
