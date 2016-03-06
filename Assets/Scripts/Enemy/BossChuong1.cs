using UnityEngine;
using System.Collections;

public class BossChuong1 : MonoBehaviour {

	private float speed = GameConst.BOSS_CHUONG_SPEED;
	private bool isAttacked;

	// Use this for initialization
	void Start () {
		isAttacked = false;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(- speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			if (!isAttacked) {
				FindObjectOfType<PlayerController>().beAttacked(20);
				isAttacked = true;
			}
		}
	}
}
