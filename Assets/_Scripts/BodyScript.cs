using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BodyScript : MonoBehaviour {
	public string victimName, Killer;
	public Text boneList;
	public List<string> Missing_Bones;
	public List<string> Collected_Bones;
	public TextMesh v_name1, v_name2;
	GameObject Player, GameManager;
	public bool isComplete = false;

	void Start () {
		Player = GameObject.Find ("Player");
		GameManager = GameObject.Find ("GameManager");
		v_name1.text = victimName;
		v_name2.text = victimName;
		UpdateBoneList ();
	}


	void UpdateBoneList(){
		boneList.text = "";
		boneList.alignment = TextAnchor.MiddleLeft;
		for (int i =0; i< Collected_Bones.Count; i++) {
			boneList.text += "<color=#00ff00ff> - " + Collected_Bones [i] + "</color>" + '\n';			
		}
		for (int i =0; i< Missing_Bones.Count; i++) {
			boneList.text += " - " + Missing_Bones [i] + '\n';			
		}
	}

	public List<string> getBones(){
		return Missing_Bones;
	}
	
	bool CheckBone(GameObject bone){
		bool isRight = false;
		for (int i =0; i< Missing_Bones.Count; i++) {
			if (bone.name == Missing_Bones [i] && !Player.GetComponent<PlayerScript> ().hasObj) {
				Collected_Bones.Add(Missing_Bones[i]);
				Missing_Bones.Remove (Missing_Bones [i]);
				bone.GetComponent<BoneScript> ().isCollected = true;
				Destroy(bone);
				isComplete = (Missing_Bones.Count == 0);
				UpdateBoneList();
				isRight = true;
			}
		}
		return isRight;
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Bone") {
			bool RightTable = CheckBone(other.gameObject);
			if (!RightTable && !Player.GetComponent<PlayerScript> ().hasObj){
				GameManager.GetComponent<GameManagerScript>().FeedbackMessage(RightTable);
				other.GetComponent<BoneScript> ().TeleportBack ();
			}
			else if(RightTable)
				GameManager.GetComponent<GameManagerScript>().FeedbackMessage(RightTable);
		}
	}
}
