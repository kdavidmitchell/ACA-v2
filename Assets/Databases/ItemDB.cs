using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class ItemDB : MonoBehaviour 
{

	private List<Dictionary<string, string>> itemDictionaries = new List<Dictionary<string, string>>();
	private Dictionary<string, string> itemDictionary = new Dictionary<string, string>();
	private List<string> itemStats = new List<string>();
	private List<string> itemModifiers = new List<string>();


	public TextAsset itemDatabase;
	public static List<BaseItem> items;

	void Awake()
	{
		ReadItemsFromDatabase();

		for (int i = 0; i < itemDictionaries.Count; i++)
		{
			items.Add(new BaseItem(itemDictionaries[i]));
		}

		foreach (BaseItem item in items)
		{
			Debug.Log(item.ItemName);
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
			itemStats = new List<string>();
			itemModifiers = new List<string>();

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
					case "Subype":
						itemDictionary.Add("Subtype", content.InnerText);
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
						itemStats.Add(content.InnerText);
						itemDictionary.Add("Stats", string.Join(" ", itemStats.ToArray()));
						break;
					case "Modifier":
						itemModifiers.Add(content.InnerText);
						itemDictionary.Add("Modifier", string.Join(" ", itemModifiers.ToArray()));
						break;			
				}
			}

			itemDictionaries.Add(itemDictionary);
		}
	}

}
