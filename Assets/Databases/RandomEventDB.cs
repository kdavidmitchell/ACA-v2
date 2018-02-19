using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class RandomEventDB : MonoBehaviour 
{

	private List<Dictionary<string, string>> eventDictionaries = new List<Dictionary<string, string>>();
	private Dictionary<string, string> eventDictionary = new Dictionary<string, string>();

	public TextAsset eventDatabase;
	public static List<RandomEvent> events = new List<RandomEvent>();

	void Awake()
	{
		ReadEventsFromDatabase();

		for (int i = 0; i < eventDictionaries.Count; i++)
		{
			events.Add(new RandomEvent(eventDictionaries[i]));
		}

		foreach (RandomEvent randomEvent in events)
		{
			// Debug.Log(randomEvent.EventTitle);
			// Debug.Log(randomEvent.EventDescription);
			// Debug.Log(randomEvent.EventID);
			// Debug.Log(randomEvent.EventOption1);
			// Debug.Log(randomEvent.EventCheck1);
			// Debug.Log(randomEvent.EventOption2);
			// Debug.Log(randomEvent.EventCheck2);
			// Debug.Log(randomEvent.EventResolution1);
			// Debug.Log(randomEvent.EventResolution2);
			// Debug.Log(randomEvent.EventXPReward);
			// Debug.Log(randomEvent.EventMoneyReward);
			// Debug.Log(randomEvent.EventFollowersReward);
			// Debug.Log(randomEvent.EventItemReward);
		}
	}

	public void ReadEventsFromDatabase()
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(eventDatabase.text);
		XmlNodeList eventList = xmlDocument.GetElementsByTagName("Event");

		foreach (XmlNode eventInfo in eventList)
		{
			XmlNodeList eventContent = eventInfo.ChildNodes;
			eventDictionary = new Dictionary<string, string>();

			foreach (XmlNode content in eventContent)
			{
				switch(content.Name)
				{
					case "Title":
						eventDictionary.Add("Title", content.InnerText);
						break;
					case "ID":
						eventDictionary.Add("ID", content.InnerText);
						break;
					case "Type":
						eventDictionary.Add("Type", content.InnerText);
						break;
					case "Description":
						eventDictionary.Add("Description", content.InnerText);
						break;
					case "Option1":
						eventDictionary.Add("Option1", content.InnerText);
						break;
					case "Check1":
						eventDictionary.Add("Check1", content.InnerText);
						break;
					case "Option2":
						eventDictionary.Add("Option2", content.InnerText);
						break;
					case "Check2":
						eventDictionary.Add("Check2", content.InnerText);
						break;
					case "Resolution1":
						eventDictionary.Add("Resolution1", content.InnerText);
						break;
					case "Resolution2":
						eventDictionary.Add("Resolution2", content.InnerText);
						break;
					case "XP":
						eventDictionary.Add("XP", content.InnerText);
						break;
					case "Money":
						eventDictionary.Add("Money", content.InnerText);
						break;
					case "Followers":
						eventDictionary.Add("Followers", content.InnerText);
						break;
					case "Item":
						eventDictionary.Add("Item", content.InnerText);
						break;			
				}
			}
			eventDictionaries.Add(eventDictionary);
		}
	}
}
