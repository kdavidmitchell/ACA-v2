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

	// Use this for initialization
	void Start () 
	{
		enhancementPanel.SetActive(false);
		_enhancementIsActive = false;

		GameInformation.PlayerXP += 100;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			_enhancementIsActive = !_enhancementIsActive;
			enhancementPanel.SetActive(_enhancementIsActive);
		}

		if (_enhancementIsActive)
		{
			playerName.text = GameInformation.PlayerName;
			playerClass.text = GameInformation.PlayerClass.ClassName;
			experienceLabel.text = GameInformation.PlayerXP.ToString();
			rhetoricLabel.text = GameInformation.PlayerStats[0].StatBaseValue.ToString();
			imageLabel.text = GameInformation.PlayerStats[1].StatBaseValue.ToString();
			diplomacyLabel.text = GameInformation.PlayerStats[2].StatBaseValue.ToString();
			healthLabel.text = GameInformation.PlayerStats[3].StatBaseValue.ToString();
			ambitionLabel.text = GameInformation.PlayerStats[4].StatBaseValue.ToString();
			eloquenceLabel.text = GameInformation.PlayerStats[5].StatBaseValue.ToString();

			rhetoricCost.text = GameInformation.PlayerStats[0].StatCost[_rhetoricBoosts].ToString();
			imageCost.text = GameInformation.PlayerStats[1].StatCost[_imageBoosts].ToString();
			diplomacyCost.text = GameInformation.PlayerStats[2].StatCost[_diplomacyBoosts].ToString();
			healthCost.text = GameInformation.PlayerStats[3].StatCost[_healthBoosts].ToString();
			ambitionCost.text = GameInformation.PlayerStats[4].StatCost[_ambitionBoosts].ToString();
			eloquenceCost.text = GameInformation.PlayerStats[5].StatCost[_eloquenceBoosts].ToString();
		}	
	}

	public void IncreaseStatScore(int ID)
	{
		if (ID == 0)
		{
			GameInformation.PlayerStats[0].StatBaseValue++;
			GameInformation.PlayerXP -= GameInformation.PlayerStats[0].StatCost[_rhetoricBoosts];
			_rhetoricBoosts++;
		} else if (ID == 1) 
		{
			GameInformation.PlayerStats[1].StatBaseValue++;
			GameInformation.PlayerXP -= GameInformation.PlayerStats[1].StatCost[_imageBoosts];
			_imageBoosts++;
		} else if (ID == 2) 
		{
			GameInformation.PlayerStats[2].StatBaseValue++;
			GameInformation.PlayerXP -= GameInformation.PlayerStats[2].StatCost[_diplomacyBoosts];
			_diplomacyBoosts++;
		} else if (ID == 3) 
		{
			GameInformation.PlayerStats[3].StatBaseValue += 15;
			GameInformation.PlayerXP -= GameInformation.PlayerStats[3].StatCost[_healthBoosts];
			_healthBoosts++;
		} else if (ID == 4) 
		{
			GameInformation.PlayerStats[4].StatBaseValue += 10;
			GameInformation.PlayerXP -= GameInformation.PlayerStats[4].StatCost[_ambitionBoosts];
			_ambitionBoosts++;
		} else if (ID == 5) 
		{
			GameInformation.PlayerStats[5].StatBaseValue++;
			GameInformation.PlayerXP -= GameInformation.PlayerStats[5].StatCost[_eloquenceBoosts];
			_eloquenceBoosts++;
		}
		

		SaveInformation.SaveAllInformation();
	}
}
