using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour 
{

	private bool _inventoryIsActive;
	private List<BaseItem> _equippedItems = new List<BaseItem>();
	
	public static List<BaseItem> _inventory = new List<BaseItem>();
	public static List<GameObject> _inventorySlots = new List<GameObject>();
	public GameObject inventoryPanel;

	public static Text itemDescription;
	public static Text itemUseText;
	public static Button useButton;

	// Use this for initialization
	void Start () 
	{

		for (int i = 0; i < 16; i++) 
		{
			_inventorySlots.Add(GameObject.Find("Inventory_Slot_" + i));
		}

		itemDescription = GameObject.Find("Item_Description").GetComponent<Text>();
		itemUseText = GameObject.Find("Item_Use_Text").GetComponent<Text>();
		useButton = GameObject.Find("Use_Button").GetComponent<Button>();

		inventoryPanel.SetActive(false);
		_inventoryIsActive = false;

		GameInformation.PlayerInventory = new List<BaseItem>();
		GameInformation.PlayerInventory.Add(ItemDB.items[0]);
		GameInformation.PlayerInventory.Add(ItemDB.items[2]);
		GameInformation.PlayerInventory.Add(ItemDB.items[5]);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			_inventoryIsActive = !_inventoryIsActive;
			inventoryPanel.SetActive(_inventoryIsActive);
		}

		if (_inventoryIsActive)
		{
			_equippedItems = GameInformation.PlayerEquippedItems;
			_inventory = GameInformation.PlayerInventory;
		}
	}

	public static int Parse(string name)
	{
		for (int i = 0; i < 16; i++) 
		{
			if (name == _inventorySlots[i].name)
			{
				return i;
			}
		}
		return 0;
	}

	public static void UpdateInformation(int index)
	{
		InventoryManager.itemDescription.text = _inventory[index].ItemDescription;
		InventoryManager.itemUseText.text = _inventory[index].ItemUseText;

		if (_inventory[index].ItemType == BaseItem.ItemTypes.CONSUMABLE)
		{
			useButton.interactable = true;
		} else 
		{
			useButton.interactable = false;
		}
	}
}
