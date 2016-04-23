using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Boss1Controller : Enemy {

	public GameObject[] chuongs;

	protected override void InitHP () {
		Debug.Log ("den day roi");
		HP = 200;
	}

	protected override void InitSpeed() {
//		speed = GameConst.ENEMY_WALK_SPEED;
	}
	
	protected override void Move() {
//		GetComponent<Rigidbody2D>().velocity = new Vector2(- speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	protected override void Start() {
		base.Start();
		UseChuong();
	}

//	void Update() {
//
//	}

	public void UseChuong() {
		GetComponent<Animator>().SetTrigger("Chuong");
		Vector3 offset = new Vector3(2, 2.2f, 0);
		Instantiate(chuongs[Random.Range(0, chuongs.Length)], transform.position + offset, Quaternion.identity);
		Invoke("UseChuong", 2.5f);
	}

	protected override void OnTriggerEnter2D(Collider2D col) {
//		Debug.Log("Chuong trung roi" + col.gameObject.tag);
		string tag = col.gameObject.tag;
		if (tag == "_PlayerBigKunai" || tag == "_PlayerBigSlash"
			|| tag == "_Dragon" || tag == "_Chuong") {
			Debug.Log("da trigger roi");
			return;
		}
		base.OnTriggerEnter2D(col);
	}

}
