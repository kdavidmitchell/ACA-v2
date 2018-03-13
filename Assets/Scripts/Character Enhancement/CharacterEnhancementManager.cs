using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterEnhancementManager : MonoBehaviour 
{

	private bool _enhancementIsActive;
	private int _rhetoricBoosts = 0;
	private int _imageBoosts = 0;
	private int _diplomacyBoosts = 0;
	private int _healthBoosts = 0;
	private int _ambitionBoosts = 0;
	private int _eloquenceBoosts = 0;
	private int _activeBoosts = 0;
	private int _passiveBoosts = 0;

	public GameObject enhancementPanel;
	public Text playerName;
	public Text playerClass;
	public Text experienceLabel;
	public Text rhetoricLabel;
	public Text imageLabel;
	public Text diplomacyLabel;
	public Text healthLabel;
	public Text ambitionLabel;
	public Text eloquenceLabel;

	public Text rhetoricCost;
	public Text imageCost;
	public Text diplomacyCost;
	public Text healthCost;
	public Text ambitionCost;
	public Text eloquenceCost;

	public Text activeAbilityName;
	public Text passiveAbilityName;
	public Text activeAbilityCost;
	public Text passiveAbilityCost;
	public Text activeAbilityRank;
	public Text passiveAbilityRank;

	public static CharacterEnhancementManager instance = null;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		} else if (instance != null)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () 
	{
		enhancementPanel.SetActive(false);
		_enhancementIsActive = false;

		_rhetoricBoosts = GameInformation.PlayerBoosts[0];
		_imageBoosts = GameInformation.PlayerBoosts[1];
		_diplomacyBoosts = GameInformation.PlayerBoosts[2];
		_healthBoosts = GameInformation.PlayerBoosts[3];
		_ambitionBoosts = GameInformation.PlayerBoosts[4];
		_eloquenceBoosts = GameInformation.PlayerBoosts[5];
		_activeBoosts = GameInformation.PlayerBoosts[6];
		_passiveBoosts = GameInformation.PlayerBoosts[7];	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			_enhancementIsActive = !_enhancementIsActive;
			enhancementPanel.SetActive(_enhancementIsActive);

			LoadInformation.LoadAllInformation();
		}

		if (_enhancementIsActive)
		{
			playerName.text = GameInformation.PlayerName;
			playerClass.text = GameInformation.PlayerClass.ClassName;
			experienceLabel.text = GameInformation.PlayerXP.ToString();
			rhetoricLabel.text = GameInformation.PlayerStats[0].StatBaseValue.ToString() + " (" + GameInformation.PlayerStats[0].StatModifiedValue.ToString() + ")";
			imageLabel.text = GameInformation.PlayerStats[1].StatBaseValue.ToString() + " (" + GameInformation.PlayerStats[1].StatModifiedValue.ToString() + ")";
			diplomacyLabel.text = GameInformation.PlayerStats[2].StatBaseValue.ToString() + " (" + GameInformation.PlayerStats[2].StatModifiedValue.ToString() + ")";
			healthLabel.text = GameInformation.PlayerStats[3].StatBaseValue.ToString() + " (" + GameInformation.PlayerStats[3].StatModifiedValue.ToString() + ")";
			ambitionLabel.text = GameInformation.PlayerStats[4].StatBaseValue.ToString() + " (" + GameInformation.PlayerStats[4].StatModifiedValue.ToString() + ")";
			eloquenceLabel.text = GameInformation.PlayerStats[5].StatBaseValue.ToString() + " (" + GameInformation.PlayerStats[5].StatModifiedValue.ToString() + ")";

			rhetoricCost.text = GameInformation.PlayerStats[0].StatCost[_rhetoricBoosts].ToString();
			imageCost.text = GameInformation.PlayerStats[1].StatCost[_imageBoosts].ToString();
			diplomacyCost.text = GameInformation.PlayerStats[2].StatCost[_diplomacyBoosts].ToString();
			healthCost.text = GameInformation.PlayerStats[3].StatCost[_healthBoosts].ToString();
			ambitionCost.text = GameInformation.PlayerStats[4].StatCost[_ambitionBoosts].ToString();
			eloquenceCost.text = GameInformation.PlayerStats[5].StatCost[_eloquenceBoosts].ToString();

			activeAbilityName.text = GameInformation.PlayerClass.ClassAbilities[1].AbilityName;
			passiveAbilityName.text = GameInformation.PlayerClass.ClassAbilities[2].AbilityName;
			activeAbilityRank.text = GameInformation.PlayerClass.ClassAbilities[1].AbilityCurrentRank.ToString();
			passiveAbilityRank.text = GameInformation.PlayerClass.ClassAbilities[2].AbilityCurrentRank.ToString();
			activeAbilityCost.text = GameInformation.PlayerClass.ClassAbilities[1].AbilityXPToLevel[_activeBoosts].ToString();
			passiveAbilityCost.text = GameInformation.PlayerClass.ClassAbilities[2].AbilityXPToLevel[_passiveBoosts].ToString();
		}	
	}

	public void IncreaseStatScore(int ID)
	{
		if (ID == 0)
		{
			if (_rhetoricBoosts < 2 && GameInformation.PlayerXP >= GameInformation.PlayerStats[0].StatCost[_rhetoricBoosts])
			{
				GameInformation.PlayerStats[0].StatBaseValue++;
				GameInformation.PlayerStats[0].StatModifiedValue++;
				GameInformation.PlayerXP -= GameInformation.PlayerStats[0].StatCost[_rhetoricBoosts];
				_rhetoricBoosts++;
				GameInformation.PlayerBoosts[0] = _rhetoricBoosts;
			} else 
			{
				Debug.Log("max rank reached or not enough xp");	
			}
		} else if (ID == 1) 
		{
			if (_imageBoosts < 2 && GameInformation.PlayerXP >= GameInformation.PlayerStats[1].StatCost[_imageBoosts])
			{
				GameInformation.PlayerStats[1].StatBaseValue++;
				GameInformation.PlayerStats[1].StatModifiedValue++;
				GameInformation.PlayerXP -= GameInformation.PlayerStats[1].StatCost[_imageBoosts];
				_imageBoosts++;
				GameInformation.PlayerBoosts[1] = _imageBoosts;
			} else 
			{
				Debug.Log("max rank reached or not enough xp");	
			}
		} else if (ID == 2) 
		{
			if (_diplomacyBoosts < 2 && GameInformation.PlayerXP >= GameInformation.PlayerStats[2].StatCost[_diplomacyBoosts])
			{
				GameInformation.PlayerStats[2].StatBaseValue++;
				GameInformation.PlayerStats[2].StatModifiedValue++;
				GameInformation.PlayerXP -= GameInformation.PlayerStats[2].StatCost[_diplomacyBoosts];
				_diplomacyBoosts++;
				GameInformation.PlayerBoosts[2] = _diplomacyBoosts;
			} else 
			{
				Debug.Log("max rank reached or not enough xp");	
			}
		} else if (ID == 3) 
		{
			if (_healthBoosts < 2 && GameInformation.PlayerXP >= GameInformation.PlayerStats[3].StatCost[_healthBoosts])
			{
				GameInformation.PlayerStats[3].StatBaseValue++;
				GameInformation.PlayerStats[3].StatModifiedValue++;
				GameInformation.PlayerXP -= GameInformation.PlayerStats[3].StatCost[_healthBoosts];
				_healthBoosts++;
				GameInformation.PlayerBoosts[3] = _healthBoosts;
			} else 
			{
				Debug.Log("max rank reached or not enough xp");	
			}
		} else if (ID == 4) 
		{
			if (_ambitionBoosts < 2 && GameInformation.PlayerXP >= GameInformation.PlayerStats[4].StatCost[_ambitionBoosts])
			{
				GameInformation.PlayerStats[4].StatBaseValue++;
				GameInformation.PlayerStats[4].StatModifiedValue++;
				GameInformation.PlayerXP -= GameInformation.PlayerStats[4].StatCost[_ambitionBoosts];
				_ambitionBoosts++;
				GameInformation.PlayerBoosts[4] = _ambitionBoosts;
			} else 
			{
				Debug.Log("max rank reached or not enough xp");	
			}
		} else if (ID == 5) 
		{
			if (_eloquenceBoosts < 2 && GameInformation.PlayerXP >= GameInformation.PlayerStats[5].StatCost[_eloquenceBoosts])
			{
				GameInformation.PlayerStats[5].StatBaseValue++;
				GameInformation.PlayerStats[5].StatModifiedValue++;
				GameInformation.PlayerXP -= GameInformation.PlayerStats[5].StatCost[_eloquenceBoosts];
				_eloquenceBoosts++;
				GameInformation.PlayerBoosts[5] = _eloquenceBoosts;
			} else 
			{
				Debug.Log("max rank reached or not enough xp");	
			}
		}
		
		SaveInformation.SaveAllInformation();
	}

	public void IncreaseAbilityScore(int ID)
	{
		if (ID == 1)
		{
			if (_activeBoosts < GameInformation.PlayerClass.ClassAbilities[1].AbilityMaxRank && 
				GameInformation.PlayerXP >= GameInformation.PlayerClass.ClassAbilities[1].AbilityXPToLevel[_activeBoosts])
			{
				GameInformation.PlayerClass.ClassAbilities[1].AbilityCurrentRank++;
				GameInformation.PlayerXP -= GameInformation.PlayerClass.ClassAbilities[1].AbilityXPToLevel[_activeBoosts];
				_activeBoosts++;
				GameInformation.PlayerBoosts[6] = _activeBoosts;
			} else 
			{
				Debug.Log("max rank reached or not enough xp");	
			}
		} else if (ID == 2)
		{
			if (_passiveBoosts < GameInformation.PlayerClass.ClassAbilities[2].AbilityMaxRank && 
				GameInformation.PlayerXP >= GameInformation.PlayerClass.ClassAbilities[2].AbilityXPToLevel[_passiveBoosts])
			{
				GameInformation.PlayerClass.ClassAbilities[2].AbilityCurrentRank++;
				GameInformation.PlayerXP -= GameInformation.PlayerClass.ClassAbilities[2].AbilityXPToLevel[_passiveBoosts];
				_passiveBoosts++;
				GameInformation.PlayerBoosts[7] = _passiveBoosts;
			} else 
			{
				Debug.Log("max rank reached or not enough xp");	
			}
		}

		SaveInformation.SaveAllInformation();
	}
}
