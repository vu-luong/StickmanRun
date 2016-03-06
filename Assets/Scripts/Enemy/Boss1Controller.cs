using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Boss1Controller : Enemy {

	public GameObject[] chuongs;

	protected override void InitHP () {
		HP = 200;
	}

	protected override void InitSpeed() {
//		speed = GameConst.ENEMY_WALK_SPEED;
	}
	
	protected override void Move() {
//		GetComponent<Rigidbody2D>().velocity = new Vector2(- speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	void Start() {
		UseChuong();
	}

	void Update() {

	}

	public void UseChuong() {
		Instantiate(chuongs[Random.Range(0, chuongs.Length)], transform.position, Quaternion.identity);
		Invoke("UseChuong", 1.0f);
	}

}
