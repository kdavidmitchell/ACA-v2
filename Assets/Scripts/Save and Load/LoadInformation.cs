using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInformation
{

	public static void LoadAllInformation()
    {

        GameInformation.PlayerName = PlayerPrefs.GetString("PLAYER_NAME");
        GameInformation.PlayerXP = PlayerPrefs.GetInt("PLAYER_XP");
        GameInformation.PlayerMoney = PlayerPrefs.GetInt("PLAYER_MONEY");
        GameInformation.PlayerFollowers = PlayerPrefs.GetInt("PLAYER_FOLLOWERS");

        if (PlayerPrefs.GetString("PLAYER_CLASS") != null)
        {
            GameInformation.PlayerClass = (BaseClass)PPSerialization.Load("PLAYER_CLASS");
        }

        if (PlayerPrefs.GetString("PLAYER_STATS") != null)
        {
        	GameInformation.PlayerStats = (List<BaseStat>)PPSerialization.Load("PLAYER_STATS");
        }

        if (PlayerPrefs.GetString("PLAYER_COMPLETED_QUESTS") != null)
        {
        	GameInformation.PlayerCompletedQuests = (List<Quest>)PPSerialization.Load("PLAYER_COMPLETED_QUESTS");
        }

        if (PlayerPrefs.GetString("PLAYER_EQUIPPED_ITEMS") != null)
        {
        	GameInformation.PlayerEquippedItems = (List<BaseItem>)PPSerialization.Load("PLAYER_EQUIPPED_ITEMS");
        }

        if (PlayerPrefs.GetString("PLAYER_INVENTORY") != null)
        {
        	GameInformation.PlayerInventory = (List<BaseItem>)PPSerialization.Load("PLAYER_INVENTORY");
        }

        if (PlayerPrefs.GetString("PLAYER_BOOSTS") != null)
        {
            GameInformation.PlayerBoosts = (int[])PPSerialization.Load("PLAYER_BOOSTS");
        }

        if (PlayerPrefs.GetString("ENEMY") != null)
        {
            GameInformation.Enemy = (BaseEnemy)PPSerialization.Load("ENEMY");
        }
    }
}
