using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class EnemyDB : MonoBehaviour 
{

	private List<Dictionary<string, string>> enemyDictionaries = new List<Dictionary<string, string>>();
	private Dictionary<string, string> enemyDictionary = new Dictionary<string, string>();

	public TextAsset enemyDatabase;
	public static List<BaseEnemy> enemies = new List<BaseEnemy>();

	// Use this for initialization
	void Start () 
	{
		ReadEnemiesFromDatabase();
		
		for (int i = 0; i < enemyDictionaries.Count; i++)
		{
			enemies.Add(new BaseEnemy(enemyDictionaries[i]));
		}

		foreach (BaseEnemy enemy in enemies)
		{
			Debug.Log(enemy.EnemyName);
			Debug.Log(enemy.EnemyID.ToString());
			Debug.Log(enemy.EnemyClass.ClassName);
		}	
	}
	
	public void ReadEnemiesFromDatabase()
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(enemyDatabase.text);
		XmlNodeList enemyList = xmlDocument.GetElementsByTagName("Enemy");

		foreach (XmlNode enemyInfo in enemyList)
		{
			XmlNodeList enemyContent = enemyInfo.ChildNodes;
			enemyDictionary = new Dictionary<string, string>();

			foreach (XmlNode content in enemyContent)
			{
				switch(content.Name)
				{
					case "Name":
						enemyDictionary.Add("Name", content.InnerText);
						break;
					case "ID":
						enemyDictionary.Add("ID", content.InnerText);
						break;
					case "Class":
						enemyDictionary.Add("Class", content.InnerText);
						break;
					case "Difficulty":
						enemyDictionary.Add("Difficulty", content.InnerText);
						break;			
				}
			}
			enemyDictionaries.Add(enemyDictionary);
		}
	}
}
