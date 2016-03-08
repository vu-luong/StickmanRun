using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {
	
	public bool isDead;
	protected float speed;
	protected bool attackedPlayer = false;
	protected int HP;

	protected abstract void InitSpeed();
	protected abstract void InitHP();

	public void Start () {
		isDead = false;
		attackedPlayer = false;
		InitSpeed();
		InitHP();
	}

	void Update () {
		if (isDead) Destroy(gameObject);
		
		if (isAttackingPlayer() && attackedPlayer == false && GetComponent<Animator>().GetBool("Die") == false) {
			FindObjectOfType<PlayerController>().beAttacked(20);
			attackedPlayer = true;
		}
	}

	
	void FixedUpdate() {
		Move();
	}

	protected abstract void Move();

	protected bool isAttackingPlayer() {
		Bounds enemyBound = GetComponent<Collider2D>().bounds;
		Bounds playerBound = FindObjectOfType<PlayerController>().GetComponent<Collider2D>().bounds;
		return enemyBound.Intersects(playerBound);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (GetComponent<Animator>().GetBool("Die")) return;

		string tag = col.gameObject.tag;

		if (tag == "PlayerSlash" || tag == "Dragon" || tag == "Chuong"
		    || tag == "PlayerBigKunai" || tag == "PlayerBigSlash" || tag == "PlayerSpecial") {
			HP -= GetPlayerPower(tag);
			if (HP <= 0) GetComponent<Animator>().SetBool("Die", true);
		}

		if (tag == "PlayerKunai") {
			Destroy(col.gameObject);
			HP -= GetPlayerPower(tag);
			if (HP <= 0) GetComponent<Animator>().SetBool("Die", true);
		}

	}

	private int GetPlayerPower(string tag) {
		if (tag == "PlayerSlash") return GameConst.PLAYER_SLASH_POWER;
		if (tag == "Dragon") return GameConst.PLAYER_DRAGON_POWER;
		if (tag == "Chuong") return GameConst.PLAYER_CHUONG_POWER;
		if (tag == "PlayerKunai") return GameConst.PLAYER_KUNAI_POWER;
		if (tag == "PlayerBigKunai") return GameConst.PLAYER_BIG_KUNAI_POWER;
		if (tag == "PlayerBigSlash") return GameConst.PLAYER_BIG_KUNAI_POWER;
		if (tag == "PlayerSpecial") return GameConst.PLAYER_SPECIAL_POWER;
		return 10;
	}

}
