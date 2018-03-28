using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopClickHandler : MonoBehaviour, IPointerClickHandler 
{

	public void OnPointerClick(PointerEventData eventData)
	{
		ShopManager.UpdateInformation(ShopManager.Parse(gameObject));
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
