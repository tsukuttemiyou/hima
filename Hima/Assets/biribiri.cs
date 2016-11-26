using UnityEngine;
using System.Collections;

public class biribiri : MonoBehaviour {

	float time;

	// Use this for initialization
	void Start () {
		time = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (time + 3.0f < Time.time) {
			Destroy(gameObject);
		}
	}
}
