using UnityEngine;
using System.Collections;

public class TowelTrail : MonoBehaviour {

	public float maxUpAndDown = .135f; 
	public float speed = 1800;
	public float angle = 0;
	public float toDegrees = Mathf.PI/180;
	public float time = 0;

	// Use this for initialization
	void Start () {
//		Time.timeScale = 0.7f;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		angle += speed * Time.deltaTime;
		if (angle > 360) angle -= 360;
		transform.position = new Vector3(transform.position.x, transform.parent.position.y + maxUpAndDown * Mathf.Sin(angle * toDegrees), 
			transform.position.z);


//		this.transform.Rotate (new Vector3 (0f, 0f, speed*Time.deltaTime));
	}
}
