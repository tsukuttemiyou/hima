#pragma strict
var myCube01:Transform;
var myCube02:Transform;
var myCube03:Transform;
var myCube04:Transform;
var myCube05:Transform;
var myCube06:Transform;
var score = 0;
var isMouseDown = false;
var increaseRate = 1.1;
var currentAdd = 100;
var appearTimeArray = new float[600];
var appearedIndex = 0;

function Start () {
	for(var i = 0 ; i < 600; i++){
		appearTimeArray[i] = Random.Range(0.0001, 60.0);
	}
	//appearTimeArray.sort(function(a, b) { return a - b;});
}

function Update () {
	var winh = Camera.main.orthographicSize;    
	var winw = winh * Screen.width / Screen.height;

	if(0.0 < Time.time){
		appearedIndex += 1;
    	var sr = myCube01.GetComponent.<SpriteRenderer>();
		var w = sr.bounds.size.x;
		var h = sr.bounds.size.y;
		var x = 0.0;
		var y = 0.0;
		var xv = 0.0;
		var yv = 0.0;

		if(Random.Range(0, 2) == 0){
			x = w + winw/2.0;
			xv = -2;
		}else{
			x = - w - winw/2.0;
			xv = 2;
		}
		y = Random.Range(-winh + h/2.0, winh - h/2.0);
		yv =  (Random.Range(-winh + h/2.0, winh - h/2.0) - y)/winw/2;
		//Debug.Log(y);
		//Debug.Log(yv);

		var index = Random.Range(0, 6);
		if(index == 0){
		    var cube = Instantiate(myCube01, Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
         	var rb = cube.GetComponent.<Rigidbody>();
		    rb.velocity = new Vector3(xv, yv, 0);
		}else if(index == 1){
		    cube = Instantiate(myCube02, Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
         	rb = cube.GetComponent.<Rigidbody>();
		    rb.velocity = new Vector3(xv, yv, 0);
		}else if(index == 2){
		    cube = Instantiate(myCube03, Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
         	rb = cube.GetComponent.<Rigidbody>();
		    rb.velocity = new Vector3(xv, yv, 0);
		}else if(index == 3){
		    cube = Instantiate(myCube04, Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
         	rb = cube.GetComponent.<Rigidbody>();
		    rb.velocity = new Vector3(xv, yv, 0);
		}else if(index == 4){
		    cube = Instantiate(myCube05, Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
         	rb = cube.GetComponent.<Rigidbody>();
		    rb.velocity = new Vector3(xv, yv, 0);
		}else if(index == 5){
		    cube = Instantiate(myCube06, Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
         	rb = cube.GetComponent.<Rigidbody>();
		    rb.velocity = new Vector3(xv, yv, 0);
		}
  	}

	if(Input.GetMouseButton(0) && !isMouseDown){
		var ray : Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		var hit : RaycastHit;
		if(Physics.Raycast(ray, hit)){
			Destroy(hit.collider.gameObject);

			var name = hit.collider.gameObject.name.Substring(0,2);
			if(name == "01"){
				score += currentAdd;
				currentAdd *= increaseRate;
			}
			if(name == "02"){
				score += currentAdd;
				currentAdd *= increaseRate;
			}
			if(name == "03"){
				score += currentAdd;
				currentAdd *= increaseRate;
			}
			if(name == "04"){
				currentAdd = 100;
			}
			if(name == "05"){
				currentAdd = 100;
			}
			if(name == "06"){
				currentAdd = 100;
			}
		}
	}
	var textObject = GameObject.Find("Score");
	var scoreText = "     " + score;
    textObject.GetComponent(TextMesh).text = scoreText.Substring(scoreText.Length - 5, 5);

    isMouseDown = Input.GetMouseButton(0);
}