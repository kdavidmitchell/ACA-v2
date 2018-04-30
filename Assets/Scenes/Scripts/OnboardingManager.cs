using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardingManager : MonoBehaviour 
{
	private bool isTut = true;

	public GameObject[] obs;
	public GameObject inventory;
	public GameObject character;

	public static OnboardingManager instance = null;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		} else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

		for (int i = 0; i < obs.Length; i++) 
		{
			obs[i].SetActive(false);
		}

		obs[0].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.I) && isTut)
		{
			obs[4].SetActive(false);
			obs[5].SetActive(true);
		}

		if (Input.GetKeyDown(KeyCode.C) && isTut)
		{
			obs[7].SetActive(false);
			obs[8].SetActive(true);
		}	
	}

	public void ContinueOnboarding(int index)
	{
		if (index == 12)
		{
			obs[index].SetActive(false);
			isTut = false;
			return;
		}

		obs[index + 1].SetActive(true);
		obs[index].SetActive(false);
	}

	public void CloseInventory()
	{
		inventory.SetActive(false);
	}

	public void CloseCharacterScreen()
	{
		character.SetActive(false);
	}
}
