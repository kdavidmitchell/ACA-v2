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
	private Dictionary<string, string> responseDictionary = new Dictionary<string, string>();

	public TextAsset questDatabase;
	public static List<Quest> quests = new List<Quest>();

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
					case "Responses1":
						XmlNodeList responsesContent = content.ChildNodes;
						responseDictionary = new Dictionary<string, string>();

						foreach (XmlNode responseContent in responsesContent)
						{
							switch(responseContent.Name)
							{
								case "Option1":
									responseDictionary.Add("Option1", responseContent.InnerText);
									break;
								case "Option2":
									responseDictionary.Add("Option2", responseContent.InnerText);
									break;
								case "Option3":
									responseDictionary.Add("Option3", responseContent.InnerText);
									break;
								case "Check1":
									responseDictionary.Add("Check1", responseContent.InnerText);
									break;
								case "Check2":
									responseDictionary.Add("Check2", responseContent.InnerText);
									break;
								case "Check3":
									responseDictionary.Add("Check3", responseContent.InnerText);
									break;
							}
						}
						break;
					case "Option1":
						questDictionary.Add("Option1", content.InnerText);
						break;
					case "Check1":
						questDictionary.Add("Check1", content.InnerText);
						break;			
				}
			}
			questDictionaries.Add(questDictionary);
		}
	}
}
