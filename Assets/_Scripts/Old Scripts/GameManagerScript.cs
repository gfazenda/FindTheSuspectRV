using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	Text Timer, BoneName, B_Description, FeedbackDialog, GameOverText;
	MenuScript menu_script;
	GameObject BonePanel, OKButton;
	public int currentTime = 300;
	bool ShowingWrong = true;
	public bool PauseTimer = false;
	int min = 0, sec = 0;

	void Start () {
		InitializeGameObjects ();
		menu_script = this.GetComponent<MenuScript> ();
		InvokeRepeating ("Countdown", 0f, 1.0f);
	}

	void InitializeGameObjects(){
		Timer = GameObject.Find ("Timer").GetComponent<Text>();
		BoneName = GameObject.Find ("Bone_Name").GetComponent<Text>();
		GameOverText = GameObject.Find ("GameOver").GetComponent<Text>();
		B_Description = GameObject.Find ("BoneDescription").GetComponent<Text>();
		FeedbackDialog = GameObject.Find ("FeedbackMessage").GetComponent<Text>();
		BonePanel = GameObject.Find ("BonePanel");
		OKButton = GameObject.Find ("OkButton");

		BonePanel.gameObject.SetActive (false);
		FeedbackDialog.gameObject.SetActive (false);
		GameOverText.gameObject.SetActive (false);
	}

	public void EndGame(bool won = false){
		if (won) {
			this.GetComponent<ClipboardScript> ().DisablePanels ();
			GameOverText.text = "You Won! Congratulations!";
			GameOverText.color = Color.green;
		}
		GameOverText.gameObject.SetActive (true);
		menu_script.GameOverMenu ();
		Time.timeScale = 0f;
	}

	public void Countdown(){
		if(!PauseTimer)
			currentTime -= 1;

		if (currentTime <= 0) {
			currentTime = 0;
			EndGame ();
		}

		min = currentTime / 60;

		if (min > 12){
			min -= (12 * (min / 12));
		}

		sec = currentTime % 60;
		Timer.text = string.Format("{0:D2}:{1:D2}", min, sec);
	}

	public void BoneDescription(GameObject Bone){
		BonePanel.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (Screen.width/2, Screen.height /6);
		BonePanel.SetActive (true);
		OKButton.SetActive (true);
		BoneName.text = Bone.name;
		B_Description.text = Bone.gameObject.GetComponent<BoneScript> ().getDescription ();
	}

	public void ChangeBonePanelPosition(){
        BonePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width / 8, Screen.height / 5);
		OKButton.SetActive (false);
	}

	public void DisablePanel(){
		OKButton.SetActive (false);
		BonePanel.SetActive (false);
	}

	public void FeedbackMessage(bool BoneCollected){
		if (BoneCollected) {
			FeedbackDialog.color = Color.green;
			FeedbackDialog.text = "Right!";
		}
		else{
			FeedbackDialog.color = Color.red;
			FeedbackDialog.text = "Wrong.";
		}
		FeedbackDialog.gameObject.SetActive (true);
		Invoke ("DisableWrongMessage", 1.0f);
	}

	void DisableWrongMessage(){
		FeedbackDialog.gameObject.SetActive (false);
	}
}
