using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour {
}

public class StartButton : MonoBehaviour {
	static int level = 0;

	public static int getLevel(){
		return level;
	}

	public void ButtonPush() {
		Debug.Log("Start Play!!");
		Application.LoadLevel("hima");
	}
	public void LeftArrowPush() {
		Text levelText = GameObject.Find("Level").GetComponentInChildren<Text>();
		switch (level) {
		case -1:
			break;
		case 0:
			levelText.text = "Easy";
			level--;
			break;
		case 1:
			levelText.text = "Normal";
			level--;
			break;
		}
	}
	public void RightArrowPush() {
		Text levelText = GameObject.Find("Level").GetComponentInChildren<Text>();
		switch (level) {
		case -1:
			levelText.text = "Normal";
			level++;
			break;
		case 0:
			levelText.text = "Hard";
			level++;
			break;
		case 1:
			break;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
