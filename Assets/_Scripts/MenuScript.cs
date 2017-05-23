using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {
	public Button Quit;
	public Button Restart;
	bool MenuActivated = false;
	GameObject Suspects, Victims;
	void Start(){
		Suspects = GameObject.Find ("Suspects");
		Victims = GameObject.Find ("Victims");
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			PauseMenu ();
		}
	
	}

	void PauseMenu(){
		MenuActivated = !MenuActivated;
		Quit.gameObject.SetActive (MenuActivated);
		Suspects.SetActive (!MenuActivated);
		Victims.SetActive (!MenuActivated);
		Restart.gameObject.SetActive (MenuActivated);
		Time.timeScale = MenuActivated ? 0 : 1;
		this.GetComponent<GameManagerScript> ().PauseTimer = MenuActivated;
	}

	public void GameOverMenu(){
		Quit.gameObject.SetActive (true);
		Restart.gameObject.SetActive (true);
	}

	public void QuitGame(){
		Application.Quit ();
	}

	
	public void MainMenu(){
		Application.LoadLevel ("Menu");
		Time.timeScale = 1;
	}


	public void RestartGame(){
		Application.LoadLevel (Application.loadedLevelName);
		Time.timeScale = 1;
	}

}
