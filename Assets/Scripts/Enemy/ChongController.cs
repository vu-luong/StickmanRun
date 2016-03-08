using UnityEngine;
using System.Collections;

public class ChongController : MonoBehaviour {
	private bool attackedPlayer;

	// Use this for initialization
	void Start () {
		attackedPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (attackedPlayer) return;
		string tag = col.gameObject.tag;
		
		if (tag == "Player") {
			FindObjectOfType<PlayerController>().beAttacked(20);
			attackedPlayer = true;
		}
//		Debug.Log(tag);

		if (tag == "SpawnGroundDetect") {
			Invoke("Appear", 2);
		}
	}

	void Appear() {
//		Debug.Log("Spawn Ground Detect");
		GetComponent<Animator>().SetBool("Appear", true);
	}

}
