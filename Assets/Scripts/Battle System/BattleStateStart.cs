using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateStart
{

	private BaseEnemy _enemy;
	public int _playerEloquence;
	public int _enemyEloquence;

	public void PrepareBattle()
	{
		_enemy = GameInformation.Enemy;
		_playerEloquence = GameInformation.PlayerClass.ClassStats[5].StatModifiedValue;
		_enemyEloquence = _enemy.EnemyClass.ClassStats[5].StatBaseValue * _enemy.EnemyDifficulty;

		if (_playerEloquence > _enemyEloquence)
		{
			CombatStateMachine.currentState = CombatStateMachine.BattleStates.PLAYER_TURN;
		} else 
		{
			CombatStateMachine.currentState = CombatStateMachine.BattleStates.ENEMY_TURN;	
		}
	}
}
