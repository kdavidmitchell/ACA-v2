using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitDB : MonoBehaviour 
{

	public Sprite[] portraits = new Sprite[6];

	public static List<Sprite> _portraits = new List<Sprite>();

	void Awake()
	{
		for (int i = 0; i < portraits.Length; i++) 
		{
			_portraits.Add(portraits[i]);
		}
	}
}
