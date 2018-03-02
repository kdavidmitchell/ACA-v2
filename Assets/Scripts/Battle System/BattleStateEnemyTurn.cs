using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateEnemyTurn 
{

	private EnemyAI _AI = new EnemyAI();

	public void TakeTurn()
	{
		CombatStateMachine.enemyAbility = _AI.ChooseAbility();
		CombatStateMachine.currentState = CombatStateMachine.BattleStates.CALCULATE_DAMAGE;
	}
}
