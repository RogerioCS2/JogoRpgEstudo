﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour {
	public GameObject theMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire2")) {
			if (theMenu.activeInHierarchy)
			{
				theMenu.SetActive(false);
			}else {
				theMenu.SetActive(true);
			}
		}
	}
}
