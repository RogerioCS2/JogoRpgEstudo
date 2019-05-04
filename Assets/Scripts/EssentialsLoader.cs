using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour {
	public GameObject player;
	public GameObject UIScreem;
	public GameObject gameManager;

	// Use this for initialization
	void Start () {
		if (UIFade.instance == null) {
			UIFade.instance = Instantiate(UIScreem).GetComponent<UIFade>();
		}

		if (PlayerController.instance == null) {
			PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
			PlayerController.instance = clone;
		}

		if (GameManager.instance == null) {
			Instantiate(gameManager);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
