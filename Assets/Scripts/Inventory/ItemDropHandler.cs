using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDropHandler : MonoBehaviour, IDropHandler 
{

	private RectTransform equipmentSlot;

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
        {
            Debug.Log ("Dropped object was: "  + eventData.pointerDrag);
        }

		if (RectTransformUtility.RectangleContainsScreenPoint(equipmentSlot, Input.mousePosition))
		{
			SwapSprites(eventData, ParseDropFromGameObjectToIndex(eventData), ParseDragFromGameObjectToIndex(eventData));
			InventoryManager.EquipItem(InventoryManager._inventory[ParseDragFromGameObjectToIndex(eventData)].ItemID);
		}
	}

	// Use this for initialization
	void Start () 
	{
		equipmentSlot = gameObject.GetComponent<RectTransform>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private int ParseDragFromGameObjectToIndex(PointerEventData eventData)
	{
		for (int i = 0; i < 16; i++) 
		{
			if (eventData.pointerDrag == InventoryManager._inventorySlotIcons[i])
			{
				return i;
			}
		}
		return 0;
	}

	private int ParseDropFromGameObjectToIndex(PointerEventData eventData)
	{
		if (gameObject.name == "Head_Slot")
		{
			return 0;
		} else if (gameObject.name == "Body_Slot")
		{
			return 1;
		} else if (gameObject.name == "Weapon_Slot")
		{
			return 2;
		} else if (gameObject.name == "Accessory_Slot")
		{
			return 3;
		} else if (gameObject.name == "Feet_Slot")
		{
			return 4;
		}

		return 0;
	}

	private void SwapSprites(PointerEventData eventData, int equipmentSlotIndex, int inventoryIndex)
	{
		if (CheckIfValidSwap(eventData, inventoryIndex))
		{
			InventoryManager._equipmentSlotIcons[equipmentSlotIndex].GetComponent<Image>().sprite = InventoryManager._inventorySlotIcons[inventoryIndex].GetComponent<Image>().sprite;
		} else 
		{
			return;	
		}
	}

	private bool CheckIfValidSwap(PointerEventData eventData, int inventoryIndex)
	{
		if (InventoryManager._inventory[inventoryIndex].ItemType == BaseItem.ItemTypes.EQUIPMENT ||
			InventoryManager._inventory[inventoryIndex].ItemType == BaseItem.ItemTypes.WEAPON)
		{
			return true;
		} else 
		{
			return false;
		}
	}
}
