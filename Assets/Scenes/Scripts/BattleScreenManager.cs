using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleScreenManager : MonoBehaviour 
{

	private string _playerName;
	private List<BaseAbility> _playerAbilities = new List<BaseAbility>();
	public int _playerMaxHealth;
	public int _playerMaxAmbition;

	private BaseEnemy _enemy;
	private string _enemyName;
	private List<BaseAbility> _enemyAbilities = new List<BaseAbility>();
	private int _enemyMaxHealth;
	private int _enemyMaxAmbition;

	private Quest _quest;
	private int _passedChecks;
	private int _xpReward;
	private int _followerReward;
	private BaseItem _itemReward;

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

	public GameObject capitulateScreen;
	public Text capitulateText;
	public GameObject winScreen;
	public Text winText;
	public Text playerHealthLabel;
	public Text playerAmbitionLabel;

	public static bool isQuest;
	
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

		_quest = GameInformation.CurrentQuest;
		_passedChecks = GameInformation.PassedChecks;

		playerName.text = _playerName;
		enemyName.text = _enemyName;

		capitulateScreen.SetActive(false);
		winScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerHealthBar.fillAmount = (float)_playerHealth / _playerMaxHealth;
		playerAmbitionBar.fillAmount = (float)_playerAmbition / _playerMaxAmbition;
		enemyHealthBar.fillAmount = (float)_enemyHealth / _enemyMaxHealth;
		enemyAmbitionBar.fillAmount = (float)_enemyAmbition / _enemyMaxAmbition;

		playerHealthLabel.text = _playerHealth.ToString();
		playerAmbitionLabel.text = _playerAmbition.ToString();
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
		capitulateScreen.SetActive(true);
		capitulateText.text = "You're going to lose " + (int)(0.1f * GameInformation.PlayerXP) + " XP and " + (int)(0.1f * GameInformation.PlayerMoney) + " dollars, but you'll keep yourself in the race, I guess.";
	}

	public void ConfirmCapitulation()
	{
		Debug.Log("lose screen");
		GameInformation.PlayerXP -= (int)(0.1f * GameInformation.PlayerXP);
		GameInformation.PlayerMoney -= (int)(0.1f * GameInformation.PlayerMoney);

		SaveInformation.SaveAllInformation();

		ReturnToMap();

	}

	public void LoseDebate()
	{
		capitulateScreen.SetActive(true);
		capitulateText.text = "You... actually lost. That's " + (int)(0.1f * GameInformation.PlayerXP) + " XP and " + (int)(0.1f * GameInformation.PlayerMoney) + " dollars down the drain. Oh well. Better luck next time.";
		GameObject.Find("Capitulate_Cancel").SetActive(false);
	}

	public void CancelCapitulation()
	{
		capitulateScreen.SetActive(false);
	}

	public void ReturnToMap()
	{
		SceneManager.LoadScene(2);
	}

	public void WinBattleFromQuest()
	{
		winScreen.SetActive(true);

		int xp = QuestManager.CalculateXPReward(_quest, _passedChecks);
		int followers = QuestManager.CalculateFollowerReward(_quest, _passedChecks);
		Debug.Log(followers);
		winText.text = "Congratulations! You've earned: " + xp + " XP, and " + followers + " followers!";
	}

	public void WinBattleFromEvent()
	{
		winScreen.SetActive(true);
		int xp = GameInformation.EventXPReward;
		int followers = GameInformation.EventFollowersReward;
		BaseItem item = GameInformation.EventItemReward;
		winText.text = "Congratulations! You've earned: " + xp + " XP, " + followers + " followers, and a " + item.ItemName + "!";
	}

	public void UpdateInformationFromQuestAndReturn()
	{
		int xp = QuestManager.CalculateXPReward(_quest, _passedChecks);
		int followers = QuestManager.CalculateFollowerReward(_quest, _passedChecks);

		GameInformation.PlayerXP += xp;
		Debug.Log(followers);
		Debug.Log(GameInformation.PlayerFollowers);
		GameInformation.PlayerFollowers += followers;
		Debug.Log(GameInformation.PlayerFollowers);
		SaveInformation.SaveAllInformation();

		ReturnToMap();
	}

	public void UpdateInformationFromEventAndReturn()
	{
		int xp = GameInformation.EventXPReward;
		int followers = GameInformation.EventFollowersReward;
		BaseItem item = GameInformation.EventItemReward;

		GameInformation.PlayerXP += xp;
		GameInformation.PlayerFollowers += followers;
		GameInformation.PlayerInventory.Add(item);
		SaveInformation.SaveAllInformation();

		ReturnToMap();
	}

	public void DetermineIfQuestAndExit()
	{
		if (isQuest)
		{
			UpdateInformationFromQuestAndReturn();
		} else 
		{
			UpdateInformationFromEventAndReturn();	
		}
	}
}
