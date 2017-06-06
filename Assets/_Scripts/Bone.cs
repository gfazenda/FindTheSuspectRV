using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bone: MonoBehaviour {
	Canvas canvas;
    BoneInformation _myInfo;
	public bool isCollected = false;
	Vector3 OriginalPosition;
	string description;
    public bool show = false;
	void Start () {
		OriginalPosition = this.transform.position;
        canvas = this.GetComponentInChildren<Canvas>();
        canvas.enabled = false;

    }

	//public string getDescription(){
	//	description = this.GetComponent<Text> ().text;
	//	return description;
	//}

    public void setGrabbed()
    {
        canvas.enabled = true;
    }

    public void setDropped()
    {
        canvas.enabled = false;
    }

    public void TeleportBack(){
		this.transform.position = OriginalPosition;
	}
}
