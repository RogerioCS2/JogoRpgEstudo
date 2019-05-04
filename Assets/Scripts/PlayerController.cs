using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	
	public Rigidbody2D theRB;
	public float moveSpeed;
	public Animator myAnim;
	public static PlayerController instance;
	public string areaTransitionName;
	private Vector3 bottonLeftLimit;
	private Vector3 topRightLimit;
	public bool camMove = true;

	void Start () {
		if (instance == null)
		{
			instance = this;
		}else {
			if (instance != this){
				Destroy(gameObject);
			}
		}
		DontDestroyOnLoad(gameObject);
	}
	
	void Update () {
		if (camMove){
			theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
		}else {
			theRB.velocity = Vector2.zero;
		}
		myAnim.SetFloat("moveX", theRB.velocity.x);
		myAnim.SetFloat("moveY", theRB.velocity.y);

		if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1) {
			if (camMove){
				myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
				myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
			}
		}

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottonLeftLimit.x, topRightLimit.x), 
		                                 Mathf.Clamp(transform.position.y, bottonLeftLimit.y, topRightLimit.y), 
		                                 transform.position.z);
	}

	public void SetBounds(Vector3 botLeft, Vector3 topRigth) {
		bottonLeftLimit = botLeft + new Vector3(1f, 1f, 0f);
		topRightLimit = topRigth + new Vector3(-1f, -1f, 0f);
	}
}
