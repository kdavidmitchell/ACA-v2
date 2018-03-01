using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler 
{

	private Vector3 _pos;

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		transform.localPosition = _pos;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	// Use this for initialization
	void Start () 
	{
		_pos = transform.localPosition;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
