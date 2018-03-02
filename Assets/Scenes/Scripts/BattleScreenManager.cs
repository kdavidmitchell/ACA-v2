using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScreenManager : MonoBehaviour 
{

	private string _playerName;
	private List<BaseAbility> _playerAbilities = new List<BaseAbility>();
	private int _playerMaxHealth;
	private int _playerMaxAmbition;

	private BaseEnemy _enemy;
	private string _enemyName;
	private List<BaseAbility> _enemyAbilities = new List<BaseAbility>();
	private int _enemyMaxHealth;
	private int _enemyMaxAmbition;

	public Text playerName;
	public Text enemyName;
	public Image playerHealthBar;
	public Image playerAmbitionBar;
	public Image enemyHealthBar;
	public Image enemyAmbitionBar;

	public int _playerHealth;
	public int _playerAmbition;
	public int _enemyHealth;
	public int _enemyAmbition;
	
	// Use this for initialization
	void Start () 
	{
		LoadInformation.LoadAllInformation();	
		_playerName = GameInformation.PlayerName;
		_playerMaxHealth = GameInformation.PlayerClass.ClassStats[3].StatModifiedValue;
		_playerMaxAmbition = GameInformation.PlayerClass.ClassStats[4].StatModifiedValue;
		_playerHealth = _playerMaxHealth;
		_playerAmbition = _playerMaxAmbition;

		_enemy = GameInformation.Enemy;
		_enemyName = _enemy.EnemyName;
		_enemyMaxHealth = _enemy.EnemyClass.ClassStats[3].StatModifiedValue * _enemy.EnemyDifficulty;
		_enemyMaxAmbition = _enemy.EnemyClass.ClassStats[4].StatModifiedValue * _enemy.EnemyDifficulty;
		_enemyHealth = _enemyMaxHealth;
		_enemyAmbition = _enemyMaxAmbition;

		playerName.text = _playerName;
		enemyName.text = _enemyName;
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerHealthBar.fillAmount = _playerHealth / _playerMaxHealth;
		playerAmbitionBar.fillAmount = _playerAmbition / _playerMaxAmbition;
		enemyHealthBar.fillAmount = _enemyHealth / _enemyMaxHealth;
		enemyAmbitionBar.fillAmount = _enemyAmbition / _enemyMaxAmbition;
	}

	public void NormalAttack()
	{
		CombatStateMachine.playerAbility = GameInformation.PlayerClass.ClassAbilities[0];
		CombatStateMachine.currentState = CombatStateMachine.BattleStates.CALCULATE_DAMAGE;
	}

	public void ActiveAbility1()
	{
		CombatStateMachine.playerAbility = GameInformation.PlayerClass.ClassAbilities[1];
		CombatStateMachine.currentState = CombatStateMachine.BattleStates.CALCULATE_DAMAGE;
	}

	public void OpenItemMenu()
	{

	}

	public void Capitulate()
	{

	}
}
