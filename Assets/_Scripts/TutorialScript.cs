using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialScript : MonoBehaviour {
	public List<GameObject> Messages;
	public GameObject Table;
	int index = 0;
	bool showingLastMessage = false;
	// Use this for initialization
	void Start () {
		this.GetComponent<GameManagerScript> ().PauseTimer = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Table.GetComponent<BodyScript> ().isComplete && !showingLastMessage) {
			showingLastMessage = true;
			index = Messages.Count-1;
			Messages [Messages.Count - 1].gameObject.SetActive (true);
		}
	}

	void ShowNextMessage(){
		Messages [index].gameObject.SetActive (true);
	}

	public void DisableCurrentMessage(){
		Messages [index].gameObject.SetActive (false);
		index += 1;
		if(index <= Messages.Count-2)
			Invoke ("ShowNextMessage", 0.4f);
		else //if (index >= Messages.Count-1)
			this.GetComponent<GameManagerScript> ().PauseTimer = false;

	}
}
