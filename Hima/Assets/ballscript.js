#pragma strict

function Start () {
}

function Update () {
	var winh = Camera.main.orthographicSize;    
	var winw = winh * Screen.width / Screen.height;
	var rb = GetComponent.<Rigidbody>();
	var sr = GetComponent.<SpriteRenderer>();
	var w = sr.bounds.size.x;
	var h = sr.bounds.size.y;

	if((rb.velocity.x < 0 && rb.position.x < -winw - w/2.0)
		|| (rb.velocity.x >= 0 && rb.position.x > winw + w/2.0)
		|| (rb.velocity.y < 0 && rb.position.y < -winh - h/2.0)
		|| (rb.velocity.y >= 0 && rb.position.y > winh + h/2.0)){
		Destroy(gameObject);
	}
}
