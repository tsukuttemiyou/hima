using UnityEngine;
using System.Collections;

public class cutin : MonoBehaviour {
	float time;

	// Use this for initialization
	void Start () {
		time = Time.time;
	}

	// Update is called once per frame
	void Update () {
		float scale = (Time.time - time) * 10.0f + 1.0f;
		float alpha =  - (Time.time - time) * 2.0f + 1.0f;;
		SpriteRenderer spRenderer = gameObject.GetComponent<SpriteRenderer> ();
		var color = spRenderer.color;
		color.a = alpha;
		spRenderer.color = color;
		gameObject.transform.localScale = new Vector3(scale, scale, 1.0f);
		if (time + 0.5f < Time.time) {
			Destroy(gameObject);
		}
	}
}
