using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconDB : MonoBehaviour 
{

	public Sprite[] icons = new Sprite[11];

	public static IconDB instance = null;
	public static List<Sprite> _icons = new List<Sprite>();

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		} else if (instance != null)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

		for (int i = 0; i < icons.Length; i++) 
		{
			_icons.Add(icons[i]);
			Debug.Log(_icons[i].name);
		}
	}
}
