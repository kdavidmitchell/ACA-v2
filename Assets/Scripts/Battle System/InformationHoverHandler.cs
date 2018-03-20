using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InformationHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{

	private GameObject instance;
	private GameObject buttonInstance;
	private List<GameObject> _buttons = new List<GameObject>();
	
	public GameObject hoverPrefab;
	public GameObject useButton;

	public void OnPointerEnter(PointerEventData eventData)
	{
		instance = Instantiate(hoverPrefab, transform.position + new Vector3(240, 0, 0), Quaternion.identity);
		instance.transform.parent = gameObject.transform;

		Text hoverText = instance.GetComponentInChildren<Text>();
		hoverText.text = Parse(name);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Destroy(instance);
		if (_buttons != null)
		{
			
		}
	}

	// Use this for initialization
	void Start () 
	{
		LoadInformation.LoadAllInformation();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private string Parse(string name)
	{
		string result = "";

		if (name == "Attack_Button")
		{
			result = GameInformation.PlayerClass.ClassAbilities[0].AbilityName + ": " + GameInformation.PlayerClass.ClassAbilities[0].AbilityDescription + " Deals " +
			GameInformation.PlayerClass.ClassAbilities[0].AbilityDamage[GameInformation.PlayerClass.ClassAbilities[0].AbilityCurrentRank - 1].ToString() + " damage, plus weapon damage.";
		} else if (name == "Abilities_Button")
		{
			result = GameInformation.PlayerClass.ClassAbilities[1].AbilityName + ": " + GameInformation.PlayerClass.ClassAbilities[1].AbilityDescription + " Deals " +
			GameInformation.PlayerClass.ClassAbilities[1].AbilityDamage[GameInformation.PlayerClass.ClassAbilities[1].AbilityCurrentRank - 1].ToString() + " damage. " + "(" + 
			GameInformation.PlayerClass.ClassAbilities[1].AbilityCost[GameInformation.PlayerClass.ClassAbilities[1].AbilityCurrentRank - 1] + " " + "AP)";
		} else if (name == "Items_Button")
		{
			foreach (BaseItem item in GameInformation.PlayerInventory)
			{
				if (item.ItemType == BaseItem.ItemTypes.CONSUMABLE)
				{
					result += item.ItemName;
					buttonInstance = Instantiate(useButton, transform.position, Quaternion.identity);
					buttonInstance.transform.parent = gameObject.transform;
					_buttons.Add(buttonInstance);
				}
			}
		}

		return result;
	}
}
