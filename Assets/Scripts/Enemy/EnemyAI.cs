using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI 
{

	private BaseAbility _ability;
	private BaseEnemy _enemy;

	public BaseAbility ChooseAbility()
	{
		_enemy = GameInformation.Enemy;

		int temp = Random.Range(0,1);
		_ability = _enemy.EnemyClass.ClassAbilities[temp];

		return _ability; 
	}
}
