using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatStateMachine : MonoBehaviour 
{

	private BattleStateStart battleStateStart = new BattleStateStart();
	private BattleStateEnemyTurn battleStateEnemyTurn = new BattleStateEnemyTurn();
	private BattleCalculations battleCalculations = new BattleCalculations();

	public BattleScreenManager battleScreenManager;

	//public static int totalTurnCount;
	public static bool playerCompletedTurn;
	public static bool enemyCompletedTurn;
	public static BattleStates currentTurnOwner;
	public static BaseAbility playerAbility;
	public static BaseAbility enemyAbility;

	public enum BattleStates
	{
		START,
		PLAYER_TURN,
		ENEMY_TURN,
		CALCULATE_DAMAGE,
		//ADD_STATUS_EFFECTS,
		END_TURN,
		LOSE,
		WIN
	}

	public static BattleStates currentState;

	// Use this for initialization
	void Awake () 
	{
		LoadInformation.LoadAllInformation();
		currentState = BattleStates.START;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (currentState)
		{
			case (BattleStates.START):
				battleStateStart.PrepareBattle();
				break;
			case (BattleStates.PLAYER_TURN):
				currentTurnOwner = BattleStates.PLAYER_TURN;
				break;
			case (BattleStates.ENEMY_TURN):
				currentTurnOwner = BattleStates.ENEMY_TURN;
				battleStateEnemyTurn.TakeTurn();
				//enemyCompletedTurn = true;
				//CheckTurnOwner ();
				break;
			case (BattleStates.CALCULATE_DAMAGE):
				if (currentTurnOwner == BattleStates.PLAYER_TURN) 
				{
					battleScreenManager._enemyHealth -= battleCalculations.CalculateTotalPlayerDamage (playerAbility);
					battleScreenManager._playerAmbition -= battleCalculations.GetPlayerAbilityCost (playerAbility);
					
					if (battleScreenManager._enemyHealth <= 0)
					{
						currentState = BattleStates.WIN;
						Debug.Log("Won the battle!");
						break;
					}
				}
				if (currentTurnOwner == BattleStates.ENEMY_TURN) 
				{
					battleScreenManager._playerHealth -= battleCalculations.CalculateTotalEnemyDamage (enemyAbility);
					battleScreenManager._enemyAmbition -= battleCalculations.GetEnemyAbilityCost (enemyAbility);

					if (battleScreenManager._playerHealth <= 0)
					{
						currentState = BattleStates.LOSE;
						Debug.Log("Lost the battle!");
						break;
					}
				}
				CheckTurnOwner();	
				break;
			// case (BattleStates.ADD_STATUS_EFFECTS):
			// 	battleStateAddStatusEffectsScript.CheckAbilityForStatusEffect (playerUsedAbility);
			// 	break;
			case (BattleStates.END_TURN):
				//totalTurnCount++;
				playerCompletedTurn = false;
				enemyCompletedTurn = false;

				if (battleStateStart._playerEloquence > battleStateStart._enemyEloquence)
				{
					currentState = BattleStates.PLAYER_TURN;
				} else
				{
					currentState = BattleStates.ENEMY_TURN;
				}
				break;
			case (BattleStates.LOSE):
				//battleScreenManager.LoseBattle();
				break;
			case (BattleStates.WIN):
                //battleScreenManager.WinBattle();
				break;
		}	
	}

	private void CheckTurnOwner()
	{
		if (playerCompletedTurn && !enemyCompletedTurn) {
			//enemy turn
			currentState = BattleStates.ENEMY_TURN;
		} else if (!playerCompletedTurn && enemyCompletedTurn) {
			//player turn
			currentState = BattleStates.PLAYER_TURN;
		} else if (playerCompletedTurn && enemyCompletedTurn) {
			//switch to end turn state
			currentState = BattleStates.END_TURN;
		}
	}
}
