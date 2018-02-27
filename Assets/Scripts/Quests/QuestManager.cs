using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour 
{

	private Quest _quest = new Quest();
	private Queue<string> _questText = new Queue<string>();
	private Queue<string> _questResponses1 = new Queue<string>();
	private Queue<string> _questResponses2 = new Queue<string>();
	private Queue<string> _questResponses3 = new Queue<string>();
	private Queue<int> _questChecks1 = new Queue<int>();
	private Queue<int> _questChecks2 = new Queue<int>();
	private Queue<int> _questChecks3 = new Queue<int>();

	private int _passedChecks = 0;
	private string _playerPassiveName;
	private int _playerPassiveRank;

	private int _nextCounter = 1;

	private int _xpReward;
	private int _followerReward;

	public GameObject questFrame;
	public Text questTitle;
	public Text questText;
	public Button buttonPrefab;
	public Text moneyLabel;
	public Text followerLabel;

	// Use this for initialization
	void Start () 
	{
		questFrame.SetActive(false);
		_playerPassiveName = GameInformation.PlayerClass.ClassAbilities[2].AbilityName;
		_playerPassiveRank = GameInformation.PlayerClass.ClassAbilities[2].AbilityCurrentRank;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadQuest(int index)
	{
		_nextCounter = 1;
		_passedChecks = 0;
		_quest = QuestDB.quests[index];

		questFrame.SetActive(true);
		questTitle.text = _quest.QuestTitle;

		EnqueueQuestText();
		EnqueueQuestResponses();
		EnqueueQuestChecks();

		questText.text = _questText.Dequeue();

		DestroyButtons();
		CreateButtons(_quest.QuestResponses1.Count, _questResponses1, _questChecks1);
	}

	private void EnqueueQuestText()
	{
		_questText.Enqueue(_quest.QuestText1);
		_questText.Enqueue(_quest.QuestText2);
		_questText.Enqueue(_quest.QuestText3);
	}

	private void EnqueueQuestResponses()
	{
		foreach (string response in _quest.QuestResponses1)
		{
			_questResponses1.Enqueue(response);
		}

		foreach (string response in _quest.QuestResponses2)
		{
			_questResponses2.Enqueue(response);
		}

		foreach (string response in _quest.QuestResponses3)
		{
			_questResponses3.Enqueue(response);
		}
	}

	private void EnqueueQuestChecks()
	{
		foreach (int check in _quest.QuestChecks1)
		{
			_questChecks1.Enqueue(check);
		}

		foreach (int check in _quest.QuestChecks2)
		{
			_questChecks2.Enqueue(check);
		}

		foreach (int check in _quest.QuestChecks3)
		{
			_questChecks3.Enqueue(check);
		}
	}

	private void CreateButtons(int num, Queue<string> responses, Queue<int> checks)
	{
		for (int i = 1; i < num + 1; i++) 
		{
			int tempCheck = checks.Peek();

			Button button = Instantiate(buttonPrefab);
			button.transform.parent = questFrame.transform;
			
			Vector2 temp = new Vector2();
			temp.y = questFrame.transform.position.y - 50 - (50 * i);
			temp.x = questFrame.transform.position.x;
			button.transform.position = temp;
			button.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

			Text buttonText = button.GetComponentInChildren<Text>();
			buttonText.fontSize = 8;
			if (tempCheck != 0)
			{
				buttonText.text = responses.Dequeue() + " " + "(" + _playerPassiveName + " " + checks.Dequeue() + ")";
				if (_playerPassiveRank < tempCheck)
				{
					button.interactable = false;
				} else
				{
					button.interactable = true;
					button.onClick.AddListener(() => _passedChecks++);
				}
			} else if (tempCheck == 0)
			{
				buttonText.text = responses.Dequeue();
				checks.Dequeue();
			}

			button.onClick.AddListener(() => Next());
		}
	}

	private void Next()
	{
		DestroyButtons();

		if (_nextCounter != 3)
		{
			questText.text = _questText.Dequeue();
		}

		if (_nextCounter == 1)
		{
			CreateButtons(_quest.QuestResponses2.Count, _questResponses2, _questChecks2);
		} else if (_nextCounter == 2)
		{
			CreateButtons(_quest.QuestResponses3.Count, _questResponses3, _questChecks3);
		} else 
		{
			CalculateXPReward();
			CalculateFollowerReward();
			DisplayRewards();	
		}

		_nextCounter++;
	}

	private void DestroyButtons()
	{
		GameObject[] buttons;
		buttons = GameObject.FindGameObjectsWithTag("Button");

		foreach (GameObject button in buttons)
		{
			Destroy(button);
		}
	}

	private void DisplayRewards()
	{
		questTitle.text = "Favor completed!";
		questText.text = "You've earned: " + _xpReward + " XP, " + _followerReward + " followers!";

		Button exitButton = Instantiate(buttonPrefab);
		exitButton.transform.parent = questFrame.transform;
			
		Vector2 temp = new Vector2();
		temp.y = questFrame.transform.position.y - 50;
		temp.x = questFrame.transform.position.x;
		exitButton.transform.position = temp;
		exitButton.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

		Text buttonText = exitButton.GetComponentInChildren<Text>();
		buttonText.fontSize = 8;
		buttonText.text = "Moving on!";
		exitButton.onClick.AddListener(() => SaveAndUpdateHUD());
		exitButton.onClick.AddListener(() => MapManager.RemovePinFromActiveList(_quest.QuestID));
		exitButton.onClick.AddListener(() => MapManager.EnableActivePins());
		exitButton.onClick.AddListener(() => DisableQuest());

	}

	private void CalculateXPReward()
	{
		if (_quest.QuestXPReward.Count > 1)
		{
			if (_passedChecks == 0)
			{
				_xpReward = _quest.QuestXPReward[2];
			} else if (_passedChecks == 1)
			{
				_xpReward = _quest.QuestXPReward[1];
			} else if (_passedChecks >= 2)
			{
				_xpReward = _quest.QuestXPReward[0];
			}
		}
	}

	private void CalculateFollowerReward()
	{
		if (_quest.QuestFollowerReward.Count > 1)
		{
			if (_passedChecks == 0)
			{
				_followerReward = _quest.QuestFollowerReward[2];
			} else if (_passedChecks == 1)
			{
				_followerReward = _quest.QuestFollowerReward[1];
			} else if (_passedChecks >= 2)
			{
				_followerReward = _quest.QuestFollowerReward[0];
			}
		}
	}

	private void SaveAndUpdateHUD()
	{
		GameInformation.PlayerXP += _xpReward;
		GameInformation.PlayerFollowers += _followerReward;

		SaveInformation.SaveAllInformation();

		followerLabel.text = GameInformation.PlayerFollowers.ToString();
		Debug.Log(GameInformation.PlayerXP);
	}

	private void DisableQuest()
	{
		questFrame.SetActive(false);
	}
}
