using UnityEngine;
using System.Collections;

public class GeneratorC : MonoBehaviour {
	public GameObject myCube01;
	public GameObject myCube02;
	public GameObject myCube03;
	public GameObject myCube04;
	public GameObject myCube05;
	public GameObject myCube06;
	public GameObject myCube07;
	public GameObject myCube08;
	public GameObject cutinMovie;

	int score = 0;
	bool isMouseDown = false;
	float increaseRate = 1.1f;
	int appearCount = 0;
	int currentAdd = 100;
	float penalty = -1000;

	float appearSum(float time){
		float N0 = 0.5f;
		float NT = 2.0f;
		float NN = 600f;
		float T = 60;

		time = Mathf.Max (Mathf.Min (time, T), 0.0f);
		float timeRand = time + Random.value * 0.2f * (T - time) / T;
		return (float)(N0*timeRand + (NT - N0)*timeRand*timeRand/2.0f/T)/(N0*T+(NT - N0)*T/2.0f)*NN;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float winh = Camera.main.orthographicSize * 2;    
		float winw = winh * Screen.width / Screen.height;

		while((int)(appearSum(Time.time) - appearCount) > 0){
			SpriteRenderer sr = myCube01.GetComponent<SpriteRenderer>();
			float w = sr.bounds.size.x;
			float h = sr.bounds.size.y;
			float x = 0.0f;
			float y = 0.0f;
			float xv = 0.0f;
			float yv = 0.0f;

			if(Random.Range(0, 2) == 0){
				x = w + winw/2.0f;
				xv = -2;
			}else{
				x = - w - winw/2.0f;
				xv = 2;
			}
			y = Random.Range(-winh/2.0f + h/2.0f, winh/2.0f - h/2.0f);
			yv =  (Random.Range(-winh/2.0f + h/2.0f, winh/2.0f - h/2.0f) - y)/winw/2;
			//Debug.Log(y);
			//Debug.Log(yv);

			int index = Random.Range(0, 7);
			GameObject cube;
			Rigidbody rb;
			if(index == 0){
				cube = (GameObject)Instantiate(myCube01, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
				rb = cube.GetComponent<Rigidbody>();
				rb.velocity = new Vector3(xv, yv, 0);
			}else if(index == 1){
				cube = (GameObject)Instantiate(myCube02, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
				rb = cube.GetComponent<Rigidbody>();
				rb.velocity = new Vector3(xv, yv, 0);
			}else if(index == 2){
				cube = (GameObject)Instantiate(myCube03, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
				rb = cube.GetComponent<Rigidbody>();
				rb.velocity = new Vector3(xv, yv, 0);
			}else if(index == 3){
				cube = (GameObject)Instantiate(myCube04, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
				rb = cube.GetComponent<Rigidbody>();
				rb.velocity = new Vector3(xv, yv, 0);
			}else if(index == 4){
				cube = (GameObject)Instantiate(myCube05, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
				rb = cube.GetComponent<Rigidbody>();
				rb.velocity = new Vector3(xv, yv, 0);
			}else if(index == 5){
				cube = (GameObject)Instantiate(myCube06, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
				rb = cube.GetComponent<Rigidbody>();
				rb.velocity = new Vector3(xv, yv, 0);
			}else if(index == 6){
				cube = (GameObject)Instantiate(myCube08, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
				rb = cube.GetComponent<Rigidbody>();
				rb.velocity = new Vector3(xv, yv, 0);
			}
			appearCount++;
		}
		Debug.Log(appearCount);

		if(Input.GetMouseButton(0) && !isMouseDown && penalty < Time.time){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit ;
			if(Physics.Raycast(ray, out hit)){

				string name = hit.collider.gameObject.name.Substring(0,2);
				if(name == "01" || name == "02" || name == "03"){
					Destroy(hit.collider.gameObject);
					score += currentAdd;
					currentAdd = (int)(currentAdd * increaseRate);
				}
				if (name == "04" || name == "05" || name == "06") {
					Destroy(hit.collider.gameObject);
					currentAdd = 100;
					penalty = Time.time + 2.0f;
				}
				if (name == "04"){
					Instantiate(myCube07, new Vector3(0, 0, -1), Quaternion.Euler(0, 0, 0));
				}
				if(name == "08"){
					Destroy(hit.collider.gameObject);
					GameObject []obstacles = GameObject.FindObjectsOfType<GameObject>();
					foreach(GameObject obs in obstacles) {
						name = obs.name.Substring(0,2);
						if(name == "01" || name == "02" || name == "03"|| name == "08"){
							Destroy(obs);
							score += currentAdd;
							currentAdd = (int)(currentAdd * increaseRate);
						}
					}
					Instantiate(cutinMovie, new Vector3(0, 0, -1), Quaternion.Euler(0, 0, 0));

				}
			}
		}
		GameObject textObject = GameObject.Find("Score");
		string scoreText = "     " + score;
		TextMesh mesh = textObject.GetComponent(typeof(TextMesh) ) as TextMesh;
		mesh.text = scoreText.Substring(scoreText.Length - 5, 5);

		GameObject timeObject = GameObject.Find("Time");
		string timeText = " " + (int)(60 - Time.time);
		TextMesh timeMesh = timeObject.GetComponent(typeof(TextMesh) ) as TextMesh;
		timeMesh.text = timeText.Substring(timeText.Length - 2, 2);

		isMouseDown = Input.GetMouseButton(0);

	}
}
