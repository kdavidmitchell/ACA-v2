using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameInformation : MonoBehaviour 
{

    private static string _playerName;
    private static BaseClass _playerClass;
    private static List<BaseStat> _playerStats;
    private static int _playerXP;
    private static int _playerMoney;
    private static int _playerFollowers;
    private static List<Quest> _playerCompletedQuests;
    private static List<BaseItem> _playerEquippedItems;
    private static List<BaseItem> _playerInventory;
    private static int _playerPortrait;
    private static int[] _boosts = new int[8];
    private static BaseEnemy _enemy;
    private static Quest _currentQuest;
    private static int _passedChecks;
    private static int _eventXPReward;
    private static int _eventFollowersReward;
    private static BaseItem _eventItemReward;

    public static string PlayerName
    {
        get { return _playerName; }
        set { _playerName = value; }
    }

    public static BaseClass PlayerClass
    {
        get { return _playerClass; }
        set { _playerClass = value; }
    }

    public static List<BaseStat> PlayerStats
    {
        get { return _playerStats; }
        set { _playerStats = value; }
    }

    public static int PlayerXP
    {
        get { return _playerXP; }
        set { _playerXP = value; }
    }

    public static int PlayerMoney
    {
        get { return _playerMoney; }
        set { _playerMoney = value; }
    }

    public static int PlayerFollowers
    {
        get { return _playerFollowers; }
        set { _playerFollowers = value; }
    }

	public static List<Quest> PlayerCompletedQuests
    {
        get { return _playerCompletedQuests; }
        set { _playerCompletedQuests = value; }
    }

    public static List<BaseItem> PlayerEquippedItems
    {
        get { return _playerEquippedItems; }
        set { _playerEquippedItems = value; }
    }

    public static List<BaseItem> PlayerInventory
    {
        get { return _playerInventory; }
        set { _playerInventory = value; }
    }

    public static int PlayerPortrait
    {
        get { return _playerPortrait; }
        set { _playerPortrait = value; }
    }

    public static int[] PlayerBoosts
    {
        get { return _boosts; }
        set { _boosts = value; }
    }

    public static BaseEnemy Enemy
    {
        get { return _enemy; }
        set { _enemy = value; }
    }

    public static Quest CurrentQuest
    {
        get { return _currentQuest; }
        set { _currentQuest = value; }
    }

    public static int PassedChecks
    {
        get { return _passedChecks; }
        set { _passedChecks = value; }
    }

    public static int EventXPReward
    {
        get { return _eventXPReward; }
        set { _eventXPReward = value; }
    }

    public static int EventFollowersReward
    {
        get { return _eventFollowersReward; }
        set { _eventFollowersReward = value; }
    }

    public static BaseItem EventItemReward
    {
        get { return _eventItemReward; }
        set { _eventItemReward = value; }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
