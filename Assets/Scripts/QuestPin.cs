using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestPin : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{

	private Quest _quest = new Quest();

	public GameObject _hoverMenu;
	
	// Use this for initialization
	void Start () 
	{
		_hoverMenu.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerEnter(PointerEventData data)
	{
		_hoverMenu.SetActive(true);
	}

	public void OnPointerExit(PointerEventData data)
	{
		_hoverMenu.SetActive(false);
	}

	public Quest PinQuest
	{
		get { return _quest; }
		set { _quest = value; }
	}
}
