using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InformationHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{

	private GameObject instance;
	
	public GameObject hoverPrefab;

	public void OnPointerEnter(PointerEventData eventData)
	{
		instance = Instantiate(hoverPrefab, transform.position + new Vector3(250, 0, 0), Quaternion.identity);
		instance.transform.parent = gameObject.transform;

		Text hoverText = instance.GetComponentInChildren<Text>();
		hoverText.text = Parse(name);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Destroy(instance);
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
			GameInformation.PlayerClass.ClassAbilities[1].AbilityDamage[GameInformation.PlayerClass.ClassAbilities[1].AbilityCurrentRank - 1].ToString() + " damage.";
		}

		return result;
	}
}
