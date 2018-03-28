using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour 
{

	public GameObject shopPanel;
	public GameObject itemPrefab;
	public GameObject shopInventoryPanel;

	public static ShopManager instance = null;
	public static Text shopDialogue;
	public static List<BaseItem> _shopItems = new List<BaseItem>();
	public static List<GameObject> _shopitemPrefabs = new List<GameObject>();

	// Use this for initialization
	void Awake () 
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

	void Start()
	{
		shopDialogue = GameObject.Find("Shopkeeper_Dialogue").GetComponent<Text>();
		StockShop();
		shopPanel.SetActive(false);
	}
	
	public void OpenShop()
	{
		shopPanel.SetActive(true);
	}

	public void CloseShop()
	{
		shopPanel.SetActive(false);
	}

	private void StockShop()
	{
		//select 5 random items from itemDB to stock the shop with
		for (int i = 0; i < 5; i++) 
		{
			_shopItems.Add(ItemDB.items[Random.Range(0,17)]);	
		}

		//create the prefabs for each item
		foreach (BaseItem item in _shopItems)
		{
			GameObject itemToBeInstantiated = Instantiate(itemPrefab, shopInventoryPanel.transform.position, Quaternion.identity);
			itemToBeInstantiated.transform.parent = shopInventoryPanel.transform;

			_shopitemPrefabs.Add(itemToBeInstantiated);

			//set the price for each item
			Text price = itemToBeInstantiated.GetComponentInChildren<Text>();
			price.text += item.ItemValue;

			//set the icons for each item
			Image icon = itemToBeInstantiated.transform.Find("Shop_Item_Icon").GetComponent<Image>();
			icon.sprite = IconDB._icons[item.ItemIcon];

			//add the buy functionality to each item prefab
			Button buyButton = itemToBeInstantiated.GetComponentInChildren<Button>();
			buyButton.onClick.AddListener(() => BuyItem(itemToBeInstantiated, item));
		}
	}

	private void BuyItem(GameObject selectedItemPrefab, BaseItem item)
	{
		//if player has enough money to buy the item
		if (GameInformation.PlayerMoney >= item.ItemValue)
		{
			//remove the item from the shop inventory
			_shopItems.Remove(item);

			//remove the prefab associated with the item
			_shopitemPrefabs.Remove(selectedItemPrefab);

			//add the item to the player's inventory
			GameInformation.PlayerInventory.Add(item);

			//decrease the player's currency by the price
			GameInformation.PlayerMoney -= item.ItemValue;

			//save all information
			SaveInformation.SaveAllInformation();

			//destroy the prefab
			Destroy(selectedItemPrefab);
		} else 
		{
			Debug.Log("Not enough money!");	
		}
	}

	public static void UpdateInformation(BaseItem item)
	{
		shopDialogue.text = item.ItemName + "\n\n";
		shopDialogue.text += item.ItemDescription + "\n\n";
		shopDialogue.text += item.ItemUseText + "\n";

		for (int i = 0; i < item.ItemStats.Count; i++) 
		{
			shopDialogue.text += "\n" + item.ItemModifiers[i] + " " + item.ItemStats[i].StatName; 
		}
	}

	public static BaseItem Parse(GameObject itemPrefab)
	{
		int index = 0;

		foreach (GameObject prefab in _shopitemPrefabs)
		{
			if (prefab == itemPrefab)
			{
				index = _shopitemPrefabs.IndexOf(itemPrefab);
			}
		}

		return _shopItems[index];
	}
}
