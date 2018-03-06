using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCalculations 
{

	private BaseEnemy _enemy;
	private int _baseAbilityDamage;
	private int _playerWeaponDamage;
	private int _totalPlayerDamage;
	private int _enemyDamageModifier;
	private int _ambitionCost;

	public int CalculateTotalPlayerDamage(BaseAbility ability)
	{

		//testing purposes only - UNTIL INVENTORY SYSTEM IS IMPLEMENTED
		_playerWeaponDamage = 3;
		_baseAbilityDamage = ability.AbilityDamage[ability.AbilityCurrentRank - 1];

		_totalPlayerDamage = _playerWeaponDamage + _baseAbilityDamage;
		CombatStateMachine.playerCompletedTurn = true;

		return _totalPlayerDamage;
	}

	public int CalculateTotalEnemyDamage(BaseAbility ability)
	{

		_enemy = GameInformation.Enemy;
		_enemyDamageModifier = _enemy.EnemyDifficulty * 2;

		_totalPlayerDamage = ability.AbilityDamage[_enemy.EnemyDifficulty];
		CombatStateMachine.enemyCompletedTurn = true;

		return _totalPlayerDamage;
	}

	public int GetPlayerAbilityCost(BaseAbility ability)
	{
		return _ambitionCost = ability.AbilityCost[ability.AbilityCurrentRank - 1];
	}

	public int GetEnemyAbilityCost(BaseAbility ability)
	{
		if (ability.AbilityCost[0] == 0)
		{
			return _ambitionCost = 0;
		}
		else 
		{
			return _ambitionCost = ability.AbilityCost[_enemy.EnemyDifficulty - 1];
		}
	}
}
