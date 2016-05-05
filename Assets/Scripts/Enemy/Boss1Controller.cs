using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Boss1Controller : Enemy {

	public GameObject[] chuongs;
	private int fullHP;

	protected override void InitHP () {
//		Debug.Log ("den day roi");
		HP = 200;
		fullHP = HP;
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

	protected override void Update() {
		if (isDead) {
			BossFormation b = FindObjectOfType<BossFormation>();
			b.BossHPDisappear();
			//TODO- 
			//			if (DistanceController.runDistance > 50000)
			//				b.ToVictory();

			/* trigger su kien xuat hien boss tiep theo */
			// GameBalance -> appearNextBoss();
		}

		base.Update();

		BossHPProgress bossHPProgress = FindObjectOfType<BossHPProgress>();
		if (bossHPProgress != null) bossHPProgress.SetProgress(Mathf.Max((int)((HP*1.0f/fullHP)*100), 0));
	}

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
//			Debug.Log("da trigger roi");
			return;
		}
		base.OnTriggerEnter2D(col);
	}

}
