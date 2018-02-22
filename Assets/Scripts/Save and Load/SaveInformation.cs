using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInformation
{

	public static void SaveAllInformation()
    {

        PlayerPrefs.SetString("PLAYER_NAME", GameInformation.PlayerName);
        PlayerPrefs.SetInt("PLAYER_XP", GameInformation.PlayerXP);
        PlayerPrefs.SetInt("PLAYER_MONEY", GameInformation.PlayerMoney);
        PlayerPrefs.SetInt("PLAYER_FOLLOWERS", GameInformation.PlayerXP);

        if (GameInformation.PlayerClass != null)
        {
            PPSerialization.Save("PLAYER_CLASS", GameInformation.PlayerClass);
        }

        if (GameInformation.PlayerStats != null)
        {
            PPSerialization.Save("PLAYER_STATS", GameInformation.PlayerStats);
        }

        if (GameInformation.PlayerCompletedQuests != null)
    	{
    		PPSerialization.Save("PLAYER_COMPLETED_QUESTS", GameInformation.PlayerCompletedQuests);
    	}

        if (GameInformation.PlayerEquippedItems != null)
        {
            PPSerialization.Save("PLAYER_EQUIPPED_ITEMS", GameInformation.PlayerEquippedItems);
        }

        if (GameInformation.PlayerInventory != null)
        {
            PPSerialization.Save("PLAYER_INVENTORY", GameInformation.PlayerInventory);
        }

        if (GameInformation.PlayerPortrait != null)
        {
            PPSerialization.Save("PLAYER_PORTRAIT", GameInformation.PlayerPortrait);
        }
        
        Debug.Log("SAVED ALL INFORMATION.");
        Debug.Log(GameInformation.PlayerClass.ClassName);
        Debug.Log(GameInformation.PlayerName);
    }
}
