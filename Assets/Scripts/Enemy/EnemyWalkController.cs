using UnityEngine;
using System.Collections;

public class EnemyWalkController : Enemy {

	protected override void InitHP() {
		HP = 10;
	}

	protected override void InitSpeed() {
		speed = GameConst.ENEMY_WALK_SPEED;
	}

	protected override void Move() {
		GetComponent<Rigidbody2D>().velocity = new Vector2(- speed, GetComponent<Rigidbody2D>().velocity.y);
	}

}
