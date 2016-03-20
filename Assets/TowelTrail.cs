using UnityEngine;
using System.Collections;

public class TowelTrail : MonoBehaviour {

	float maxUpAndDown = .3f; 
	float speed = 1000;
	float angle = 0;
	float toDegrees = Mathf.PI/180;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		angle += speed * Time.deltaTime;
		if (angle > 360) angle -= 360;
		transform.position = new Vector3(transform.position.x, maxUpAndDown * Mathf.Sin(angle * toDegrees), 
		                                 transform.position.z);
	}
}
