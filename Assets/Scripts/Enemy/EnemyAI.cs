using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI 
{

	private BaseAbility _ability;
	private BaseEnemy _enemy;
	private BattleScreenManager _bsm;

	public BaseAbility ChooseAbility()
	{
		_bsm = GameObject.Find("BattleScreenManager").GetComponent<BattleScreenManager>();

		_enemy = GameInformation.Enemy;

		int temp = Random.Range(0,2);
		_ability = _enemy.EnemyClass.ClassAbilities[temp];

		if (_ability.AbilityCost[_enemy.EnemyDifficulty - 1] > _bsm._enemyAmbition)
		{
			ChooseAbility();
		}
		
		return _ability; 
	}
}
