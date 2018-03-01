using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScreenManager : MonoBehaviour 
{

	private string _playerName;
	private int _playerHealth;
	private int _playerAmbition;
	private List<BaseAbility> _playerAbilities = new List<BaseAbility>();

	public Text playerName;
	public Text enemyName;


	// Use this for initialization
	void Start () 
	{
		LoadInformation.LoadAllInformation();	
		_playerName = GameInformation.PlayerName;
		_playerHealth = GameInformation.PlayerClass.ClassStats[3].StatModifiedValue;
		_playerAmbition = GameInformation.PlayerClass.ClassStats[4].StatModifiedValue;

		playerName.text = _playerName;
		//enemyName.text = _enemyName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NormalAttack()
	{

	}

	public void ActiveAbility1()
	{

	}

	public void OpenItemMenu()
	{

	}

	public void Capitulate()
	{

	}
}
