using UnityEngine;
using System.Collections;

public class biribiri : MonoBehaviour {

	float time;
	GameObject GO;

	// Use this for initialization
	void Start () {
		time = Time.time;
	}

	// Update is called once per frame
	void Update () {
		Vector3 tempVec = gameObject.transform.position;
		if (tempVec.x >= 0.0f) {
			tempVec.x -= 0.2f;
		} else {
			tempVec.x += 0.2f;
		}
		gameObject.transform.position = tempVec;
		if (time + 3.0f < Time.time) {
			Destroy(gameObject);
		}
	}
}
