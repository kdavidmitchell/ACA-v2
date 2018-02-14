using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class ItemDB : MonoBehaviour 
{

	private List<Dictionary<string, string>> itemDictionaries = new List<Dictionary<string, string>>();
	private Dictionary<string, string> itemDictionary = new Dictionary<string, string>();

	public TextAsset itemDatabase;
	public static List<BaseItem> items;

	void Awake()
	{
		ReadItemsFromDatabase();

		for (int i = 0; i < itemDictionaries.Count; i++)
		{
			items.Add(new BaseItem(itemDictionaries[i]));
		}
	}

	public void ReadItemsFromDatabase()
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(itemDatabase.text);
		XmlNodeList itemList = xmlDocument.GetElementsByTagName("Item");

		foreach (XmlNode itemInfo in itemList)
		{
			XmlNodeList itemContent = itemInfo.ChildNodes;
			itemDictionary = new Dictionary<string, string>();

			foreach (XmlNode content in itemContent)
			{
				switch(content.Name)
				{
					case "Name":
						itemDictionary.Add("Name", content.InnerText);
						break;
					case "ID":
						itemDictionary.Add("ID", content.InnerText);
						break;
					case "Type":
						itemDictionary.Add("Type", content.InnerText);
						break;
					case "UseText":
						itemDictionary.Add("UseText", content.InnerText);
						break;
					case "Description":
						itemDictionary.Add("Description", content.InnerText);
						break;
					case "Value":
						itemDictionary.Add("Value", content.InnerText);
						break;
					case "Stats":
						itemDictionary.Add("Stats", content.InnerText);
						break;
					case "Modifier":
						itemDictionary.Add("Modifier", content.InnerText);
						break;			
				}
			}

			itemDictionaries.Add(inventoryDictionary);
		}
	}

}
