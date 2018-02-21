using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
