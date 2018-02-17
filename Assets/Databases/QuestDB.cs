using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class QuestDB : MonoBehaviour 
{

	private List<Dictionary<string, string>> questDictionaries = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> response1Dictionaries = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> response2Dictionaries = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> response3Dictionaries = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> xpDictionaries = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> followersDictionaries = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> itemDictionaries = new List<Dictionary<string, string>>();
	private Dictionary<string, string> questDictionary = new Dictionary<string, string>();
	private Dictionary<string, string> response1Dictionary = new Dictionary<string, string>();
	private Dictionary<string, string> response2Dictionary = new Dictionary<string, string>();
	private Dictionary<string, string> response3Dictionary = new Dictionary<string, string>();
	private Dictionary<string, string> xpDictionary = new Dictionary<string, string>();
	private Dictionary<string, string> followersDictionary = new Dictionary<string, string>();
	private Dictionary<string, string> itemDictionary = new Dictionary<string, string>();

	public TextAsset questDatabase;
	public static List<Quest> quests = new List<Quest>();

	void Awake()
	{
		ReadQuestsFromDatabase();

		for (int i = 0; i < questDictionaries.Count; i++)
		{
			quests.Add(new Quest(questDictionaries[i], response1Dictionaries[i], response2Dictionaries[i], 
				response3Dictionaries[i], xpDictionaries[i], followersDictionaries[i], itemDictionaries[i]));

		}
	}

	public void ReadQuestsFromDatabase()
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(questDatabase.text);
		XmlNodeList questList = xmlDocument.GetElementsByTagName("Quest");

		foreach (XmlNode questInfo in questList)
		{
			XmlNodeList questContent = questInfo.ChildNodes;
			questDictionary = new Dictionary<string, string>();

			foreach (XmlNode content in questContent)
			{
				switch(content.Name)
				{
					case "Title":
						questDictionary.Add("Title", content.InnerText);
						break;
					case "Description":
						questDictionary.Add("Description", content.InnerText);
						break;
					case "ID":
						questDictionary.Add("ID", content.InnerText);
						break;
					case "Text1":
						questDictionary.Add("Text1", content.InnerText);
						break;
					case "Text2":
						questDictionary.Add("Text2", content.InnerText);
						break;
					case "Text3":
						questDictionary.Add("Text3", content.InnerText);
						break;
					case "Responses1":
						XmlNodeList responses1Content = content.ChildNodes;
						response1Dictionary = new Dictionary<string, string>();

						foreach (XmlNode responseContent in responses1Content)
						{
							switch(responseContent.Name)
							{
								case "Option1":
									response1Dictionary.Add("Option1", responseContent.InnerText);
									break;
								case "Option2":
									response1Dictionary.Add("Option2", responseContent.InnerText);
									break;
								case "Option3":
									response1Dictionary.Add("Option3", responseContent.InnerText);
									break;
								case "Check1":
									response1Dictionary.Add("Check1", responseContent.InnerText);
									break;
								case "Check2":
									response1Dictionary.Add("Check2", responseContent.InnerText);
									break;
								case "Check3":
									response1Dictionary.Add("Check3", responseContent.InnerText);
									break;
							}
						}
						response1Dictionaries.Add(response1Dictionary);
						break;
					case "Responses2":
						XmlNodeList responses2Content = content.ChildNodes;
						response2Dictionary = new Dictionary<string, string>();

						foreach (XmlNode responseContent in responses2Content)
						{
							switch(responseContent.Name)
							{
								case "Option1":
									response2Dictionary.Add("Option1", responseContent.InnerText);
									break;
								case "Option2":
									response2Dictionary.Add("Option2", responseContent.InnerText);
									break;
								case "Option3":
									response2Dictionary.Add("Option3", responseContent.InnerText);
									break;
								case "Check1":
									response2Dictionary.Add("Check1", responseContent.InnerText);
									break;
								case "Check2":
									response2Dictionary.Add("Check2", responseContent.InnerText);
									break;
								case "Check3":
									response2Dictionary.Add("Check3", responseContent.InnerText);
									break;
							}
						}
						response2Dictionaries.Add(response2Dictionary);
						break;
					case "Responses3":
						XmlNodeList responses3Content = content.ChildNodes;
						response3Dictionary = new Dictionary<string, string>();

						foreach (XmlNode responseContent in responses3Content)
						{
							switch(responseContent.Name)
							{
								case "Option1":
									response3Dictionary.Add("Option1", responseContent.InnerText);
									break;
								case "Option2":
									response3Dictionary.Add("Option2", responseContent.InnerText);
									break;
								case "Option3":
									response3Dictionary.Add("Option3", responseContent.InnerText);
									break;
								case "Check1":
									response3Dictionary.Add("Check1", responseContent.InnerText);
									break;
								case "Check2":
									response3Dictionary.Add("Check2", responseContent.InnerText);
									break;
								case "Check3":
									response3Dictionary.Add("Check3", responseContent.InnerText);
									break;
							}
						}
						response3Dictionaries.Add(response3Dictionary);
						break;
					case "Combat":
						questDictionary.Add("Combat", content.InnerText);
						break;
					case "XP":
						XmlNodeList xpContent = content.ChildNodes;
						xpDictionary = new Dictionary<string, string>();
						
						foreach(XmlNode xpTier in xpContent)
						{
							switch(xpTier.Name)
							{
								case "Tier1":
									xpDictionary.Add("Tier1", xpTier.InnerText);
									break;
								case "Tier2":
									xpDictionary.Add("Tier2", xpTier.InnerText);
									break;
								case "Tier3":
									xpDictionary.Add("Tier3", xpTier.InnerText);
									break;
							}
						}
						xpDictionaries.Add(xpDictionary);
						break;
					case "Followers":
						XmlNodeList followersContent = content.ChildNodes;
						followersDictionary = new Dictionary<string, string>();

						foreach(XmlNode followersTier in followersContent)
						{
							switch(followersTier.Name)
							{
								case "Tier1":
									followersDictionary.Add("Tier1", followersTier.InnerText);
									break;
								case "Tier2":
									followersDictionary.Add("Tier2", followersTier.InnerText);
									break;
								case "Tier3":
									followersDictionary.Add("Tier3", followersTier.InnerText);
									break;
							}
						}
						followersDictionaries.Add(followersDictionary);
						break;
					case "Item":
						XmlNodeList itemContent = content.ChildNodes;
						itemDictionary = new Dictionary<string, string>();

						foreach(XmlNode itemTier in itemContent)
						{
							switch(itemTier.Name)
							{
								case "Tier1":
									itemDictionary.Add("Tier1", itemTier.InnerText);
									break;
								case "Tier2":
									itemDictionary.Add("Tier2", itemTier.InnerText);
									break;
								case "Tier3":
									itemDictionary.Add("Tier3", itemTier.InnerText);
									break;
							}
						}
						itemDictionaries.Add(itemDictionary);
						break;
				}
			}
			questDictionaries.Add(questDictionary);
		}
	}
}
