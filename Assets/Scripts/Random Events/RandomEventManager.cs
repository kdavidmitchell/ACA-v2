using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomEventManager : MonoBehaviour 
{

	private RandomEvent _event;
	private bool _hasCombat = false;
	private Queue<string> _options = new Queue<string>();
	private Queue<int> _checks = new Queue<int>();
	private string _resolution;

	private bool _passedCheck = false;
	private string _playerPassiveName;
	private int _playerPassiveRank;

	private int _xpReward;
	private int _moneyReward;
	private int _followerReward;
	private BaseItem _itemReward;

	private SoundManager sm;

	public GameObject questFrame;
	public Text questTitle;
	public Text questText;
	public Button buttonPrefab;
	public Text moneyLabel;
	public Text followerLabel;

	public static RandomEventManager instance = null;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		} else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () 
	{
		_playerPassiveName = GameInformation.PlayerClass.ClassAbilities[2].AbilityName;
		_playerPassiveRank = GameInformation.PlayerClass.ClassAbilities[2].AbilityCurrentRank;

		sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		_playerPassiveRank = GameInformation.PlayerClass.ClassAbilities[2].AbilityCurrentRank;
	}

	public void ChooseAndLoadRandomEvent()
	{
		_passedCheck = false;

		int temp = Random.Range(0,MapManager._events.Count);
		_event = MapManager._events[temp];

		questFrame.SetActive(true);
		questTitle.text = _event.EventTitle;
		questText.text = _event.EventDescription;
		sm.PlaySingleEfx(2);

		EnqueueOptions();
		EnqueueChecks();

		if (_event.EventType == RandomEvent.EventTypes.CHALLENGE)
		{
			_hasCombat = true;
		}

		DestroyButtons();
		CreateButtons(_hasCombat, 2, _options, _checks);
	}

	private void EnqueueOptions()
	{
		_options.Enqueue(_event.EventOption1);
		_options.Enqueue(_event.EventOption2);
	}

	private void EnqueueChecks()
	{
		_checks.Enqueue(_event.EventCheck1);
		_checks.Enqueue(_event.EventCheck2);	
	}

	private void CreateButtons(bool hasCombat, int num, Queue<string> options, Queue<int> checks)
	{
		for (int i = 1; i < num + 1; i++)
		{
			int tempCheck = checks.Peek();

			Button button = Instantiate(buttonPrefab);
			//button.transform.parent = questFrame.transform;
			button.transform.SetParent(questFrame.transform, false);
			
			Vector2 temp = new Vector2();
			RectTransform rt = button.GetComponent<RectTransform>();
			temp.y = questFrame.transform.position.y - 40 - ((rt.rect.height + 40) * i);
			temp.x = questFrame.transform.position.x;
			button.transform.position = temp;
			button.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

			Text buttonText = button.GetComponentInChildren<Text>();
			buttonText.fontSize = 8;

			if (tempCheck != 0)
			{
				buttonText.text = options.Dequeue() + " " + "(" + _playerPassiveName + " " + checks.Dequeue() + ")";
				
				if (_playerPassiveRank < tempCheck)
				{
					button.interactable = false;
				} else
				{
					button.interactable = true;
					button.onClick.AddListener(() => _passedCheck = true);
					button.onClick.AddListener(() => _resolution = _event.EventResolution2);
				}
			} else if (tempCheck == 0)
			{
				buttonText.text = options.Peek();
				checks.Dequeue();

				if (_hasCombat && options.Peek() == "DEBATE!")
				{
					button.onClick.AddListener(() => DisableQuest());
					button.onClick.AddListener(() => MapManager.RemoveEventFromActiveList(_event.EventID));
					button.onClick.AddListener(() => LoadDebate(_event.EventEnemy, _event.EventXPReward, _event.EventFollowersReward));
				} else 
				{
					button.onClick.AddListener(() => _resolution = _event.EventResolution1);
				}

				options.Dequeue();
			}

			button.onClick.AddListener(() => Next(_resolution));
		}
	}

	private void Next(string resolution)
	{
		DestroyButtons();

		if (resolution != "N/A")
		{
			questText.text = resolution + "\n\n";
		} else 
		{
			questText.text = "";
		}

		CalculateRewards(_passedCheck);

		if (_passedCheck && !_hasCombat)
		{
			questText.text += "Wow! You've earned: " + _xpReward + " XP, " + _followerReward + " followers, " + _moneyReward + " dollars";
			if (_itemReward != null)
			{
				questText.text += ", and a " + _itemReward.ItemName + "!";
			}
		} else if (_passedCheck && _hasCombat)
		{
			questText.text += "Wow! You've earned: " + _xpReward + " XP, and " + _followerReward + " followers!";
			if (_itemReward != null)
			{
				questText.text += ", and a " + _itemReward.ItemName + "!";
			}
		} else if (!_passedCheck && !_hasCombat)
		{
			questText.text += "You feel like you might have gotten more from this had you been more skilled. But hey, " + _moneyReward + " bucks ain't bad.";
		}

		Button exitButton = Instantiate(buttonPrefab);
		//exitButton.transform.parent = questFrame.transform;
		exitButton.transform.SetParent(questFrame.transform, false);
			
		Vector2 temp = new Vector2();
		temp.y = questFrame.transform.position.y - 65;
		temp.x = questFrame.transform.position.x;
		exitButton.transform.position = temp;
		exitButton.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

		Text buttonText = exitButton.GetComponentInChildren<Text>();
		buttonText.fontSize = 8;
		buttonText.text = "Moving on!";

		sm.PlaySingleEfx(0);

		exitButton.onClick.AddListener(() => SaveAndUpdateHUD());
		exitButton.onClick.AddListener(() => MapManager.RemoveEventFromActiveList(_event.EventID));
		exitButton.onClick.AddListener(() => DisableQuest());
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

	private void CalculateRewards(bool passedCheck)
	{
		if (passedCheck)
		{
			_xpReward = _event.EventXPReward;
			_moneyReward = _event.EventMoneyReward;
			_followerReward = _event.EventFollowersReward;
			if (_event.EventItemReward != 0)
			{
				_itemReward = ItemDB.items[Random.Range(0, ItemDB.items.Count)];
			} else 
			{
				_itemReward = null;		
			}
		} else
		{
			_xpReward = 0;
			_followerReward = 0;
			_moneyReward = _event.EventMoneyReward;
			_itemReward = null;
		}
	}

	private void SaveAndUpdateHUD()
	{
		GameInformation.PlayerXP += _xpReward;
		GameInformation.PlayerMoney += _moneyReward;
		GameInformation.PlayerFollowers += _followerReward;

		if (_itemReward != null)
		{
			GameInformation.PlayerInventory.Add(_itemReward);
		}

		SaveInformation.SaveAllInformation();

		followerLabel.text = GameInformation.PlayerFollowers.ToString();
		moneyLabel.text = GameInformation.PlayerMoney.ToString();
	}

	private void DisableQuest()
	{
		questFrame.SetActive(false);
	}

	private void LoadDebate(int enemyIndex, int xpReward, int followerReward)
	{
		GameInformation.Enemy = EnemyDB.enemies[enemyIndex - 1];
		GameInformation.EventXPReward = xpReward;
		GameInformation.EventFollowersReward = followerReward;
		GameInformation.EventItemReward = ItemDB.items[Random.Range(0, ItemDB.items.Count)];

		SaveInformation.SaveAllInformation();

		SceneManager.LoadScene(3);
	}
}
