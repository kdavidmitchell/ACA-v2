using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class StatusEffectDB : MonoBehaviour 
{

	private List<Dictionary<string, string>> effectDictionaries = new List<Dictionary<string, string>>();
	private Dictionary<string, string> effectDictionary = new Dictionary<string, string>();

	public TextAsset effectDatabase;
	public static List<BaseStatusEffect> effects = new List<BaseStatusEffect>();

	// Use this for initialization
	void Awake()
	{
		ReadEffectsFromDatabase();

		for (int i = 0; i < effectDictionaries.Count; i++)
		{
			effects.Add(new BaseStatusEffect(effectDictionaries[i]));
		}
	}
	
	public void ReadEffectsFromDatabase()
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(effectDatabase.text);
		XmlNodeList effectList = xmlDocument.GetElementsByTagName("Effect");

		foreach (XmlNode effectInfo in effectList)
		{
			XmlNodeList effectContent = effectInfo.ChildNodes;
			effectDictionary = new Dictionary<string, string>();

			foreach (XmlNode content in effectContent)
			{
				switch(content.Name)
				{
					case "Name":
						effectDictionary.Add("Name", content.InnerText);
						break;
					case "Description":
						effectDictionary.Add("Description", content.InnerText);
						break;
					case "ID":
						effectDictionary.Add("ID", content.InnerText);
						break;
					case "Type":
						effectDictionary.Add("Type", content.InnerText);
						break;
					case "Duration":
						effectDictionary.Add("Duration", content.InnerText);
						break;
					case "Damage":
						effectDictionary.Add("Damage", content.InnerText);
						break;			
				}
			}
			effectDictionaries.Add(effectDictionary);
		}
	}
}
