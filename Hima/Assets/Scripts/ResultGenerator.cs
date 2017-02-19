using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultGenerator : MonoBehaviour {
	float [] scoreList = new float[5];
	int scoreListNum = 0;

	// Use this for initialization
	void Start () {
		Text scoreText = GameObject.Find("Score").GetComponentInChildren<Text>();
		int score = GeneratorC.getScore ();
		scoreText.text = score.ToString();

		for(int i = 0; i < 5; i++){
			if (PlayerPrefs.HasKey ("scoreList" + i.ToString ())) {
				scoreList[i] = PlayerPrefs.GetFloat("scoreList" + i.ToString ());
				scoreListNum = i + 1;
			} else {
				break;
			}
		}
		for (int i = 0; i < 5; i++) {
			if (score > scoreList [i]) {
				for (int j = 5 - 1; j > i; j--) {
					scoreList [j] = scoreList [j - 1];
				}
				scoreList [i] = score;
				scoreListNum = Mathf.Min (5, scoreListNum + 1);
				break;
			}
		}
		for (int i = 0; i < scoreListNum; i++) {
			PlayerPrefs.SetFloat("scoreList" + i.ToString (), scoreList[i]);
		}

		Text bestScoresText = GameObject.Find("BestScores").GetComponentInChildren<Text>();
		bestScoresText.text = "";
		for (int i = 0; i < scoreListNum; i++) {
			switch (i) {
			case 0:
				bestScoresText.text += "1st.\t" + ((ulong)scoreList[i]).ToString() + "\n";
				break;
			case 1:
				bestScoresText.text += "2nd.\t" + ((ulong)scoreList[i]).ToString() + "\n";
				break;
			case 2:
				bestScoresText.text += "3rd.\t" + ((ulong)scoreList[i]).ToString() + "\n";
				break;
			case 3:
				bestScoresText.text += "4th.\t" + ((ulong)scoreList[i]).ToString() + "\n";
				break;
			case 4:
				bestScoresText.text += "5th.\t" + ((ulong)scoreList[i]).ToString() + "\n";
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
