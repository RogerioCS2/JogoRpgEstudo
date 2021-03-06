﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour {

	public string areaToLoad;
	public string areaTransitionName;
	public float waitToLoad = 1f;
	private bool shouldLoadAfterFade;

	void Start () {

	}
	
	void Update () {
		if (shouldLoadAfterFade) {
			waitToLoad -= Time.deltaTime;
			if (waitToLoad <= 0) {
				shouldLoadAfterFade = false;
				SceneManager.LoadScene(areaToLoad);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			shouldLoadAfterFade = true;
			UIFade.instance.FadeToBlack();
			PlayerController.instance.areaTransitionName = areaTransitionName;
		}
	}
}
