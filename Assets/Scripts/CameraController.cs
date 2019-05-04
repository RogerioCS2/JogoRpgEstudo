using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour {
	public Transform target;
	public Tilemap theMap;
	private Vector3 bottonLeftLimit;
	private Vector3 topRightLimit;
	private float halfHeigth;
	private float halfWidth;

	// Use this for initialization
	void Start () {
		//target = PlayerController.instance.transform;
		target = FindObjectOfType<PlayerController>().transform;
		halfHeigth = Camera.main.orthographicSize;
		halfWidth = halfHeigth * Camera.main.aspect;
		bottonLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeigth, 0f);
		topRightLimit = theMap.localBounds.max  + new Vector3(-halfWidth, -halfHeigth, 0f);
		PlayerController.instance.SetBounds(theMap.localBounds.min, theMap.localBounds.max);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottonLeftLimit.x, topRightLimit.x), 
		                                 Mathf.Clamp(transform.position.y, bottonLeftLimit.y, topRightLimit.y), 
		                                 transform.position.z);
	}
}
