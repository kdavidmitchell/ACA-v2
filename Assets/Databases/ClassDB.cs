using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class ClassDB : MonoBehaviour 
{

	private List<Dictionary<string, string>> classDictionaries = new List<Dictionary<string, string>>();
	private Dictionary<string, string> classDictionary = new Dictionary<string, string>();
	private List<string> classStats = new List<string>();
	private List<string> classAbilities = new List<string>();

	public TextAsset classDatabase;
	public static List<BaseClass> classes = new List<BaseClass>();

	void Awake()
	{
		ReadClassesFromDatabase();
		
		for (int i = 0; i < classDictionaries.Count; i++)
		{
			classes.Add(new BaseClass(classDictionaries[i]));
		}

		foreach (BaseClass baseClass in classes)
		{
			foreach (BaseAbility ability in baseClass.ClassAbilities)
			{
				Debug.Log(ability.AbilityName);
				Debug.Log(ability.AbilityID);
			}
		}
	}

	public void ReadClassesFromDatabase()
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(classDatabase.text);
		XmlNodeList classList = xmlDocument.GetElementsByTagName("Class");

		foreach (XmlNode classInfo in classList)
		{
			XmlNodeList classContent = classInfo.ChildNodes;
			classDictionary = new Dictionary<string, string>();
			classStats = new List<string>();
			classAbilities = new List<string>();

			foreach (XmlNode content in classContent)
			{
				switch(content.Name)
				{
					case "Name":
						classDictionary.Add("Name", content.InnerText);
						break;
					case "ID":
						classDictionary.Add("ID", content.InnerText);
						break;
					case "Description":
						classDictionary.Add("Description", content.InnerText);
						break;
					case "Type":
						classDictionary.Add("Type", content.InnerText);
						break;
					case "Stat":
						classStats.Add(content.InnerText);
						break;
					case "Ability":
						classAbilities.Add(content.InnerText);
						break;			
				}
			}
			classDictionary.Add("Stats", string.Join(" ", classStats.ToArray()));
			classDictionary.Add("Abilities", string.Join(" ", classAbilities.ToArray()));
			classDictionaries.Add(classDictionary);
		}
	}
}
