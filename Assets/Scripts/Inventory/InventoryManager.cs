using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour 
{

	private bool _inventoryIsActive;
	
	public GameObject inventoryPanel;

	// Use this for initialization
	void Start () 
	{
		inventoryPanel.SetActive(false);
		_inventoryIsActive = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			_inventoryIsActive = !_inventoryIsActive;
			inventoryPanel.SetActive(!_inventoryIsActive);
		}
	}
}
