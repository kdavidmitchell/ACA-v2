using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InformationHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{

	private GameObject instance;
	private GameObject buttonInstance;
	private GameObject iconInstance;
	private List<GameObject> _buttons = new List<GameObject>();
	private List<GameObject> _icons = new List<GameObject>();
	private List<BaseItem> _combatInventory = new List<BaseItem>();
	private int _playerInventoryIndex;
	
	public GameObject hoverPrefab;
	public GameObject useButton;
	public GameObject itemIcon;
	public BattleScreenManager bsm;

	public void OnPointerEnter(PointerEventData eventData)
	{
		instance = Instantiate(hoverPrefab, transform.position + new Vector3(240, 0, 0), Quaternion.identity);
		instance.transform.parent = gameObject.transform;

		Text hoverText = instance.GetComponentInChildren<Text>();
		hoverText.text = Parse(name);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Destroy(instance);
		
		if (_buttons != null)
		{
			foreach (GameObject button in _buttons)
			{
				Destroy(button);
			}
		}

		if (_icons != null)
		{
			foreach (GameObject icon in _icons)
			{
				Destroy(icon);
			}
		}
	}

	// Use this for initialization
	void Start () 
	{
		LoadInformation.LoadAllInformation();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private string Parse(string name)
	{
		string result = "";

		if (name == "Attack_Button")
		{
			result = GameInformation.PlayerClass.ClassAbilities[0].AbilityName + ": " + GameInformation.PlayerClass.ClassAbilities[0].AbilityDescription + " Deals " +
			GameInformation.PlayerClass.ClassAbilities[0].AbilityDamage[GameInformation.PlayerClass.ClassAbilities[0].AbilityCurrentRank - 1].ToString() + " damage, plus weapon damage.";
		} else if (name == "Abilities_Button")
		{
			result = GameInformation.PlayerClass.ClassAbilities[1].AbilityName + ": " + GameInformation.PlayerClass.ClassAbilities[1].AbilityDescription + " Deals " +
			GameInformation.PlayerClass.ClassAbilities[1].AbilityDamage[GameInformation.PlayerClass.ClassAbilities[1].AbilityCurrentRank - 1].ToString() + " damage. " + "(" + 
			GameInformation.PlayerClass.ClassAbilities[1].AbilityCost[GameInformation.PlayerClass.ClassAbilities[1].AbilityCurrentRank - 1] + " " + "AP)";
		} else if (name == "Items_Button")
		{
			int count = 1;
			foreach (BaseItem item in GameInformation.PlayerInventory)
			{
				if (item.ItemType == BaseItem.ItemTypes.CONSUMABLE)
				{
					_combatInventory.Add(item);
					Debug.Log(item.ItemName);
					_playerInventoryIndex = GameInformation.PlayerInventory.IndexOf(item);

					iconInstance = Instantiate(itemIcon, transform.position + new Vector3((105 + (55*count)), 100, 0), Quaternion.identity);
					iconInstance.transform.parent = gameObject.transform;
					iconInstance.GetComponent<Image>().sprite = IconDB._icons[item.ItemIcon];
					_icons.Add(iconInstance);
					
					buttonInstance = Instantiate(useButton, transform.position + new Vector3((105 + (55*count)), 60, 0), Quaternion.identity);
					buttonInstance.transform.parent = gameObject.transform;
					_buttons.Add(buttonInstance);

					buttonInstance.GetComponent<Button>().onClick.AddListener(() => UseItem(item.ItemID));
					buttonInstance.GetComponent<Button>().onClick.AddListener(() => RemoveItemFromInventory(_playerInventoryIndex));

					count++;
				}
			}
		}

		return result;
	}

	private void UseItem(int itemID)
	{
		if (itemID == 1)
		{
			if (bsm._playerAmbition <= (bsm._playerMaxAmbition - 10))
			{
				bsm._playerAmbition += 10;
			} else if (bsm._playerAmbition > (bsm._playerMaxAmbition - 10))
			{
				bsm._playerAmbition = bsm._playerMaxAmbition;	
			}
		} else if (itemID == 2)
		{
			if (bsm._playerHealth <= (bsm._playerMaxHealth - 10))
			{
				bsm._playerHealth += 10;
			} else if (bsm._playerHealth > (bsm._playerMaxHealth - 10))
			{
				bsm._playerHealth = bsm._playerMaxHealth;	
			}
		}
	}

	private void RemoveItemFromInventory(int index)
	{
		GameInformation.PlayerInventory.RemoveAt(index);
		SaveInformation.SaveAllInformation();
	}
}
