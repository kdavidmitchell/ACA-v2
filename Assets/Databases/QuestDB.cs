using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class QuestDB : MonoBehaviour 
{

	private List<Dictionary<string, string>> questDictionaries = new List<Dictionary<string, string>>();
	private Dictionary<string, string> questDictionary = new Dictionary<string, string>();
	private List<string> responses1 = new List<string>();
	private List<string> checks1 = new List<string>();
	private List<string> responses2 = new List<string>();
	private List<string> checks2 = new List<string>();
	private List<string> responses3 = new List<string>();
	private List<string> checks3 = new List<string>();
	private List<string> xp = new List<string>();
	private List<string> followers = new List<string>();
	private List<string> items = new List<string>();

	public TextAsset questDatabase;
	public static List<Quest> quests = new List<Quest>();

	void Awake()
	{
		ReadQuestsFromDatabase();

		for (int i = 0; i < questDictionaries.Count; i++)
		{
			quests.Add(new Quest(questDictionaries[i]));

			foreach (Quest quest in quests)
			{
				Debug.Log(quest.QuestTitle);
				Debug.Log(quest.QuestDescription);
				Debug.Log(quest.QuestID);
				Debug.Log(quest.QuestText1);

				foreach (string option in quest.QuestResponses1)
				{
					Debug.Log(option);
				}

				foreach (int check in quest.QuestChecks1)
				{
					Debug.Log(check);
				}

				Debug.Log(quest.QuestText2);
				
				foreach (string option in quest.QuestResponses2)
				{
					Debug.Log(option);
				}

				foreach (int check in quest.QuestChecks2)
				{
					Debug.Log(check);
				}

				Debug.Log(quest.QuestText3);
				
				foreach (string option in quest.QuestResponses3)
				{
					Debug.Log(option);
				}

				foreach (int check in quest.QuestChecks3)
				{
					Debug.Log(check);
				}

				foreach (int xp in quest.QuestXPReward)
				{
					Debug.Log(xp);
				}

				foreach (int followers in quest.QuestFollowerReward)
				{
					Debug.Log(followers);
				}

				foreach (int item in quest.QuestItemReward)
				{
					Debug.Log(item);
				}
			}
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
			responses1 = new List<string>();
			checks1 = new List<string>();
			responses2 = new List<string>();
			checks2 = new List<string>();
			responses3 = new List<string>();
			checks3 = new List<string>();
			xp = new List<string>();
			followers = new List<string>();
			items = new List<string>();

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
						responses1.Add(content.InnerText);
						break;
					case "Responses2":
						responses2.Add(content.InnerText);
						break;
					case "Responses3":
						responses3.Add(content.InnerText);
						break;
					case "Checks1":
						checks1.Add(content.InnerText);
						break;
					case "Checks2":
						checks2.Add(content.InnerText);
						break;
					case "Checks3":
						checks3.Add(content.InnerText);
						break;
					case "Combat":
						questDictionary.Add("Combat", content.InnerText);
						break;
					case "XP":
						xp.Add(content.InnerText);
						break;
					case "Followers":
						followers.Add(content.InnerText);
						break;
					case "Item":
						items.Add(content.InnerText);
						break;
				}
			}
			questDictionary.Add("Responses1", string.Join(";", responses1.ToArray()));
			questDictionary.Add("Responses2", string.Join(";", responses2.ToArray()));
			questDictionary.Add("Responses3", string.Join(";", responses3.ToArray()));
			questDictionary.Add("Checks1", string.Join(" ", checks1.ToArray()));
			questDictionary.Add("Checks2", string.Join(" ", checks2.ToArray()));
			questDictionary.Add("Checks3", string.Join(" ", checks3.ToArray()));
			questDictionary.Add("XP", string.Join(" ", xp.ToArray()));
			questDictionary.Add("Followers", string.Join(" ", followers.ToArray()));
			questDictionary.Add("Items", string.Join(" ", items.ToArray()));
			questDictionaries.Add(questDictionary);
		}
	}
}
