using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour 
{

	private BattleScreenManager _bsm;

	void Start()
	{
		_bsm = GameObject.Find("BattleScreenManager").GetComponent<BattleScreenManager>();
	}

	public void UseCombatItem(int index)
	{
		if (index == 0)
		{
			_bsm._playerAmbition += 10;
		} else if (index == 1)
		{
			_bsm._playerHealth += 10;
		}
	}
}
