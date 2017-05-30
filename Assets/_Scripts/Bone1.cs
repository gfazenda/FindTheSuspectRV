using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoneScript: MonoBehaviour {
	GameObject player;
    BoneInformation _myInfo;
	public bool isCollected = false;
	Vector3 OriginalPosition;
	string description;
	void Start () {
		OriginalPosition = this.transform.position;
	}

	public string getDescription(){
		description = this.GetComponent<Text> ().text;
		return description;
	}

	public void TeleportBack(){
		this.transform.position = OriginalPosition;
	}
}
