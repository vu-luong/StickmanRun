using UnityEngine;
using System.Collections;

public class SpawnGroundDetect : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector3(player.GetComponent<Rigidbody2D>().velocity.x, 0, 0);
	}

}
