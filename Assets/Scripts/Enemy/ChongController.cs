using UnityEngine;
using System.Collections;

public class ChongController : MonoBehaviour {
	private bool attackedPlayer;
	void Start () {
		attackedPlayer = false;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (attackedPlayer) return;
		string tag = col.gameObject.tag;
		
		if (tag == "Player") {
			GameObject.FindGameObjectWithTag("Player")
				.GetComponent<PlayerController>().beAttacked(20);
			attackedPlayer = true;
		}

		if (tag == "SpawnGroundDetect") {
			Invoke("Appear", 2);
		}
	}

	void Appear() {
		if (transform.parent != null && transform.parent.GetComponent<Animator>() != null)
			this.transform.parent.gameObject.GetComponent<Animator>().SetBool("Appear", true);
	}

}
