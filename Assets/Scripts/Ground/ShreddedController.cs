using UnityEngine;
using System.Collections;

public class ShreddedController : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		FollowPlayer();
	}

	void FollowPlayer() {
		GetComponent<Rigidbody2D>().velocity = new Vector3(player.GetComponent<Rigidbody2D>().velocity.x, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			Application.LoadLevel("Play");
		} else
		if (col.gameObject.tag != "Shredded")
			Destroy(col.gameObject);
	}

}
