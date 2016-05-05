using UnityEngine;
using System.Collections;

public class HomeManController : MonoBehaviour {

	public float speedX;
	public float speedY = -1.3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector3(speedX, speedY, 0);
	}
}
