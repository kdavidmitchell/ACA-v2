using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpManager : MonoBehaviour 
{
	private bool _helpIsActive;

	public GameObject helpPanel;
	public static HelpManager instance = null;

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
	}

	void Start()
	{
		helpPanel.SetActive(false);
		_helpIsActive = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.H))
		{
			_helpIsActive = !_helpIsActive;
			helpPanel.SetActive(_helpIsActive);
		}
	}
}
