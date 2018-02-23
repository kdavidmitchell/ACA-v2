using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCManager : MonoBehaviour 
{
	private BasePlayer _newPlayer = new BasePlayer();
	
	private Image _selectedPortrait;

	public GameObject _question1;
	public GameObject _confirmation1;
	public GameObject _portraitHolder;
	
	public GameObject _question2;
	public GameObject _classesHolder;
	public GameObject _confirmation2;

	public GameObject _question3;
	public InputField _inputField;
	public GameObject _confirmation3;

	// Use this for initialization
	void Start () 
	{
		_confirmation1.SetActive(false);
		_question2.SetActive(false);
		_classesHolder.SetActive(false);
		_confirmation2.SetActive(false);
		_question3.SetActive(false);
		_confirmation3.SetActive(false);
	}

	public void DeterminePlayerPortrait(int index)
	{
		_selectedPortrait = GameObject.Find("Image_" + index).GetComponent<Image>();
		_newPlayer.PlayerPortrait = _selectedPortrait;
		GameInformation.PlayerPortrait = _selectedPortrait;

		_confirmation1.SetActive(true);
	}

	public void EnableQuestion2()
	{
		_question1.SetActive(false);
		_portraitHolder.SetActive(false);
		_question2.SetActive(true);
		_classesHolder.SetActive(true);
		_confirmation1.SetActive(false);

		DisplayClasses();
	}

	public void DisplayClasses()
	{
		for (int i = 0; i < ClassDB.classes.Count; i++) 
		{
			Text classTitle = GameObject.Find("Class_" + (i+1) + "_Title").GetComponent<Text>();
			classTitle.text = ClassDB.classes[i].ClassName;
			
			Text classDescription = GameObject.Find("Class_" + (i+1) + "_Description").GetComponent<Text>();
			classDescription.text = ClassDB.classes[i].ClassDescription;
			
			classDescription.text += "\n\n";
			foreach (BaseStat stat in ClassDB.classes[i].ClassStats)
			{
				classDescription.text += stat.StatName + ": " + stat.StatBaseValue + "\n";
			}

			classDescription.text += "\n\nAbilities: ";
			foreach (BaseAbility ability in ClassDB.classes[i].ClassAbilities)
			{
				classDescription.text += "\n" + ability.AbilityName;
			}
		}
	}

	public void DeterminePlayerClass(int index)
	{
		_newPlayer.PlayerClass = ClassDB.classes[index];
		_newPlayer.PlayerStats = _newPlayer.PlayerClass.ClassStats;
		GameInformation.PlayerClass = _newPlayer.PlayerClass;
		GameInformation.PlayerStats = _newPlayer.PlayerStats;

		_confirmation2.SetActive(true);
	}

	public void EnableQuestion3()
	{
		_question2.SetActive(false);
		_classesHolder.SetActive(false);
		_confirmation2.SetActive(false);
		_question3.SetActive(true);
	}

	public void EnableNameConfirmation()
	{
		_confirmation3.SetActive(true);
	}

	public void FinalizeCharacterCreation()
	{
		_newPlayer.PlayerName = _inputField.text;
		_newPlayer.PlayerXP = 0;
		_newPlayer.PlayerFollowers = 0;
		_newPlayer.PlayerMoney = 0;

		GameInformation.PlayerName = _newPlayer.PlayerName;
		GameInformation.PlayerXP = _newPlayer.PlayerXP;
		GameInformation.PlayerFollowers = _newPlayer.PlayerFollowers;
		GameInformation.PlayerMoney = _newPlayer.PlayerMoney;

		SaveInformation.SaveAllInformation();
	}
}
