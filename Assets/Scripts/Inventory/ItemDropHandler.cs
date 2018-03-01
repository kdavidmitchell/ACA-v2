using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler 
{

	private RectTransform equipmentSlot;

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
        {
            Debug.Log ("Dropped object was: "  + eventData.pointerDrag);
        }

		if (RectTransformUtility.RectangleContainsScreenPoint(equipmentSlot, Input.mousePosition))
		{
			Debug.Log("Tried to equip item");
		}
	}

	// Use this for initialization
	void Start () 
	{
		equipmentSlot = gameObject.GetComponent<RectTransform>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
