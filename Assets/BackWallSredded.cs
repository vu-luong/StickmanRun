using UnityEngine;
using System.Collections;

public class BackWallSredded : MonoBehaviour {

	public GameObject player;
	
	void Update () {
		FollowPlayer();
	}
	
	void FollowPlayer() {
		GetComponent<Rigidbody2D>().velocity = new Vector3(player.GetComponent<Rigidbody2D>().velocity.x, 0, 0);
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		string tag = col.gameObject.tag;
		if (tag == "PlayerBigKunai" || tag == "PlayerKunai")
			Destroy(col.gameObject);
	}
}
