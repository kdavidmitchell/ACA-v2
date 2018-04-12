using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatStateMachine : MonoBehaviour 
{

	private BattleStateStart battleStateStart = new BattleStateStart();
	private BattleStateEnemyTurn battleStateEnemyTurn = new BattleStateEnemyTurn();
	private BattleCalculations battleCalculations = new BattleCalculations();

	//status effect management
	private int _startTurn;
	private int _endTurn;
	private int _damage = 0;
	private bool _hasHarass;
	private bool _hasStun;
	private bool _hasSleep;
	private SoundManager sm;

	public BattleScreenManager battleScreenManager;

	public static int totalTurnCount = 0;
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

		sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
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

				if (!_hasStun && !_hasSleep)
				{
					currentTurnOwner = BattleStates.ENEMY_TURN;
					battleStateEnemyTurn.TakeTurn();
				} else 
				{
					CheckForStatusEffect();	
				}
				//enemyCompletedTurn = true;
				//CheckTurnOwner ();
				break;
			case (BattleStates.CALCULATE_DAMAGE):
				sm.PlaySingleEfx(1);
				if (currentTurnOwner == BattleStates.PLAYER_TURN) 
				{
					if (battleCalculations.GetPlayerAbilityCost(playerAbility) <= battleScreenManager._playerAmbition)
					{
						ApplyStatusEffect(playerAbility.AbilityStatusEffect);

						battleScreenManager._enemyHealth -= battleCalculations.CalculateTotalPlayerDamage (playerAbility);
						battleScreenManager._playerAmbition -= battleCalculations.GetPlayerAbilityCost (playerAbility);
					}

					if (_hasStun || _hasSleep)
					{
						enemyCompletedTurn = true;
					}
					
					if (battleScreenManager._enemyHealth <= 0)
					{
						currentState = BattleStates.WIN;
						Debug.Log("Won the battle!");
						break;
					}
				}
				if (currentTurnOwner == BattleStates.ENEMY_TURN) 
				{

					if (!_hasStun && !_hasSleep)
					{
						battleScreenManager._playerHealth -= battleCalculations.CalculateTotalEnemyDamage (enemyAbility);
						battleScreenManager._enemyAmbition -= battleCalculations.GetEnemyAbilityCost (enemyAbility);
					} else 
					{
						break;	
					}

					if (battleScreenManager._playerHealth <= 0)
					{
						currentState = BattleStates.LOSE;
						battleScreenManager.LoseDebate();
						break;
					}
				}
				CheckTurnOwner();	
				break;
			// case (BattleStates.ADD_STATUS_EFFECTS):
			// 	battleStateAddStatusEffectsScript.CheckAbilityForStatusEffect (playerUsedAbility);
			// 	break;
			case (BattleStates.END_TURN):
				totalTurnCount = totalTurnCount + 1;
				Debug.Log(totalTurnCount);
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
				Debug.Log(BattleScreenManager.isQuest);
                if (BattleScreenManager.isQuest)
                {
                	battleScreenManager.WinBattleFromQuest();
                } else 
                {
                	battleScreenManager.WinBattleFromEvent();	
                }
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

	private void ApplyStatusEffect(string name)
	{
		if (name != "EMPTY")
		{
			if (name == "HARASS")
			{
				_hasHarass = true;
				_startTurn = totalTurnCount;
				_endTurn = totalTurnCount + 3;
				_damage = 3;
			} else if (name == "STUN")
			{
				_hasStun = true;
				_startTurn = totalTurnCount;
				_endTurn = totalTurnCount + 2;
				_damage = 0;
			} else if (name == "SLEEP")
			{
				_hasSleep = true;
				_startTurn = totalTurnCount;
				_endTurn = totalTurnCount + 3;
				_damage = 0;
			}
		} else 
		{
			return;		
		}
	}

	private void CheckForStatusEffect()
	{
		if (_hasHarass)
		{
			battleScreenManager._enemyHealth -= _damage;

			if (totalTurnCount == _endTurn)
			{
				_hasHarass = false;
			}
		} else if (_hasStun)
		{
			currentState = BattleStates.PLAYER_TURN;
			currentTurnOwner = BattleStates.PLAYER_TURN;
			playerCompletedTurn = false;

			if (totalTurnCount == _endTurn)
			{
				_hasStun = false;
			}
		} else if (_hasSleep)
		{
			currentState = BattleStates.PLAYER_TURN;
			currentTurnOwner = BattleStates.PLAYER_TURN;
			playerCompletedTurn = false;

			if (totalTurnCount == _endTurn)
			{
				_hasSleep = false;
			}
		}
	}
}
