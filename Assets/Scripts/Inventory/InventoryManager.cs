using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour 
{

	private bool _inventoryIsActive;
	
	public static List<BaseItem> _equippedItems = new List<BaseItem>();
	public static List<BaseItem> _inventory = new List<BaseItem>();
	public static List<GameObject> _inventorySlots = new List<GameObject>();
	public static List<GameObject> _inventorySlotIcons = new List<GameObject>();
	public static List<GameObject> _equipmentSlotIcons = new List<GameObject>();
	public GameObject inventoryPanel;

	public static Text itemName;
	public static Text itemDescription;
	public static Text itemUseText;

	public static InventoryManager instance = null;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		} else if (instance != null)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () 
	{

		for (int i = 0; i < 16; i++) 
		{
			_inventorySlots.Add(GameObject.Find("Inventory_Slot_" + i));
			_inventorySlotIcons.Add(GameObject.Find("Inventory_Slot_" + i + "_Icon"));
		}

		_equipmentSlotIcons.Add(GameObject.Find("Head_Slot_Item_Icon"));
		_equipmentSlotIcons.Add(GameObject.Find("Body_Slot_Item_Icon"));
		_equipmentSlotIcons.Add(GameObject.Find("Weapon_Slot_Item_Icon"));
		_equipmentSlotIcons.Add(GameObject.Find("Accessory_Slot_Item_Icon"));
		_equipmentSlotIcons.Add(GameObject.Find("Feet_Slot_Item_Icon"));

		itemName = GameObject.Find("Item_Name").GetComponent<Text>();
		itemDescription = GameObject.Find("Item_Description").GetComponent<Text>();
		itemUseText = GameObject.Find("Item_Use_Text").GetComponent<Text>();

		inventoryPanel.SetActive(false);
		_inventoryIsActive = false;
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
			UpdateInventory();
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
		if (index >= _inventory.Count)
		{
			return;
		} else 
		{
			if (_inventory[index].ItemType != BaseItem.ItemTypes.CONSUMABLE)
			{
				InventoryManager.itemDescription.text = _inventory[index].ItemDescription;
				InventoryManager.itemUseText.text = _inventory[index].ItemUseText;
				InventoryManager.itemName.text = _inventory[index].ItemName;

				for (int i = 0; i < _inventory[index].ItemStats.Count; i++) 
				{
					InventoryManager.itemUseText.text += "\n" + _inventory[index].ItemModifiers[i] + " " + _inventory[index].ItemStats[i].StatName; 
				}
			} else 
			{
				InventoryManager.itemDescription.text = _inventory[index].ItemDescription;
				InventoryManager.itemUseText.text = _inventory[index].ItemUseText;
				InventoryManager.itemName.text = _inventory[index].ItemName;
			}	
		}
	}

	public static void EquipItem(int id)
	{
		InventoryManager._equippedItems.Add(InventoryManager._inventory[FindItemIndexFromID(id)]);
		GameInformation.PlayerEquippedItems = InventoryManager._equippedItems;
		
		AddItemBonusesToPlayerStats(InventoryManager._inventory[FindItemIndexFromID(id)]);
		
		InventoryManager._inventory.RemoveAt(FindItemIndexFromID(id));
		GameInformation.PlayerInventory = InventoryManager._inventory;

		SaveInformation.SaveAllInformation();
		UpdateInventory();
	}

	public static int FindItemIndexFromID(int id)
	{
		foreach (BaseItem item in InventoryManager._inventory)
		{
			if (item.ItemID == id)
			{
				return InventoryManager._inventory.IndexOf(item);
			}
		}
		return 0;
	}

	public static void UpdateInventory()
	{
		LoadInformation.LoadAllInformation();
		InventoryManager._inventory = GameInformation.PlayerInventory;

		if (InventoryManager._inventory.Count != 0)
		{
			for (int i = 0; i < InventoryManager._inventory.Count; i++) 
			{
				if (InventoryManager._inventory[i] != null)
				{
					Color c;
					Image itemImage = InventoryManager._inventorySlotIcons[i].GetComponent<Image>();
					c = itemImage.color;
					c.a = 1;
					itemImage.color = c;
					itemImage.sprite = IconDB._icons[InventoryManager._inventory[i].ItemIcon];
				}
			}
		}

		for (int i = InventoryManager._inventory.Count; i < InventoryManager._inventorySlots.Count; i++) 
		{
			Color c;
			Image itemImage = _inventorySlotIcons[i].GetComponent<Image>();
			c = itemImage.color;
			c.a = 0;
			itemImage.color = c;
		}

		SaveInformation.SaveAllInformation();
	}

	public static void AddItemBonusesToPlayerStats(BaseItem item)
	{
		for (int i = 0; i < item.ItemStats.Count; i++) 
		{
			BaseStat statToBeModified = item.ItemStats[i];
			int modifier = item.ItemModifiers[i];

			for (int j = 0; j < GameInformation.PlayerStats.Count; j++) 
			{
				if (statToBeModified.StatName == GameInformation.PlayerStats[j].StatName)
				{
					Debug.Log(GameInformation.PlayerStats[j].StatModifiedValue);
					GameInformation.PlayerStats[j].StatModifiedValue += modifier;
					Debug.Log(GameInformation.PlayerStats[j].StatModifiedValue);
				}
			}
		}
	}
}
