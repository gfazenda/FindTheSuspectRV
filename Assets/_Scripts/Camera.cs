using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public GameObject player;
	Vector3 offset = new Vector3(0,0,-2);
	// Use this for initialization
	void Start () {

	}

	void FixedUpdate () {
//		float mouseHorizontal = 10 * Input.GetAxis ("Mouse X");
//		float mouseVertical = 10 * Input.GetAxis ("Mouse Y");
//
//		//if(moveHorizontal != 0)
//		transform.RotateAround(transform.position,Vector3.up, mouseHorizontal);
		//else 
		//transform.RotateAround(transform.position,Vector3.left, moveVertical);
		//transform.Rotate = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);
		//Debug.Log ("here");
		//Debug.Log (new Vector3 (moveHorizontal, moveVertical, 0));

//		float moveHorizontal = Input.GetAxis ("Horizontal");
//		float moveVertical = Input.GetAxis ("Vertical");
//		
//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
//		
//		GetComponent<Rigidbody>().AddForce(movement * 500 * Time.deltaTime);
	}

	// Update is called once per frame
	void LateUpdate () {
		//transform.position = player.transform.position +offset ;
	}
}
