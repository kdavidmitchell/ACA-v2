﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{

	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}

	public void LoadArea1()
	{
		SceneManager.LoadScene(2);
	}
}
