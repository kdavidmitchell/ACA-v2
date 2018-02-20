using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class AbilityDB : MonoBehaviour 
{

	private List<Dictionary<string, string>> abilityDictionaries = new List<Dictionary<string, string>>();
	private Dictionary<string, string> abilityDictionary = new Dictionary<string, string>();
	private List<string> abilityDamage = new List<string>();
	private List<string> abilityCost = new List<string>();
	private List<string> abilityXPToLevel = new List<string>();

	public TextAsset abilityDatabase;
	public static List<BaseAbility> abilities = new List<BaseAbility>();

	void Awake()
	{
		ReadAbilitiesFromDatabase();

		for (int i = 0; i < abilityDictionaries.Count; i++)
		{
			abilities.Add(new BaseAbility(abilityDictionaries[i]));
		}
	}

	public void ReadAbilitiesFromDatabase()
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(abilityDatabase.text);
		XmlNodeList abilityList = xmlDocument.GetElementsByTagName("Ability");

		foreach (XmlNode abilityInfo in abilityList)
		{
			XmlNodeList abilityContent = abilityInfo.ChildNodes;
			abilityDictionary = new Dictionary<string, string>();
			abilityDamage = new List<string>();
			abilityCost = new List<string>();
			abilityXPToLevel = new List<string>();

			foreach (XmlNode content in abilityContent)
			{
				switch(content.Name)
				{
					case "Name":
						abilityDictionary.Add("Name", content.InnerText);
						break;
					case "ID":
						abilityDictionary.Add("ID", content.InnerText);
						break;
					case "Type":
						abilityDictionary.Add("Type", content.InnerText);
						break;
					case "Damage":
						abilityDamage.Add(content.InnerText);
						break;
					case "Cost":
						abilityCost.Add(content.InnerText);
						break;
					case "Description":
						abilityDictionary.Add("Description", content.InnerText);
						break;
					case "XPToLevel":
						abilityXPToLevel.Add(content.InnerText);
						break;
					case "CurrentRank":
						abilityDictionary.Add("CurrentRank", content.InnerText);
						break;
					case "MaxRank":
						abilityDictionary.Add("MaxRank", content.InnerText);
						break;
					case "StatusEffect":
						abilityDictionary.Add("StatusEffect", content.InnerText);
						break;			
				}
			}
			abilityDictionary.Add("Damage", string.Join(" ", abilityDamage.ToArray()));
			abilityDictionary.Add("Cost", string.Join(" ", abilityCost.ToArray()));
			abilityDictionary.Add("XPToLevel", string.Join(" ", abilityXPToLevel.ToArray()));
			abilityDictionaries.Add(abilityDictionary);
		}
	}
}
