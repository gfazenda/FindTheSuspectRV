using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoneScript : MonoBehaviour {
	GameObject player;
	public bool isCollected = false;
	Vector3 OriginalPosition;
	string description;
	void Start () {
		player = GameObject.Find ("Player");
		OriginalPosition = this.transform.position;
	}

	void OnMouseDown(){
		if (Vector3.Distance (transform.position, player.transform.position) < 20 && !isCollected){
			player.GetComponent<PlayerScript>().getObject(this.gameObject);
		}
	}

	public string getDescription(){
		description = this.GetComponent<Text> ().text;
		return description;
	}

	public void TeleportBack(){
		this.transform.position = OriginalPosition;
	}
}
