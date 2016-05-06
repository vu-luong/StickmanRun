using UnityEngine;
using System.Collections;

public class EnemyFlyController : Enemy {
	private bool attack;

	protected override void Start() {
		base.Start();
		attack = false;
	}

	protected override void InitHP () {
		HP = 10;
	}

	protected override void InitSpeed() {
		speed = GameConst.ENEMY_WALK_SPEED;
	}
	
	protected override void Move() {
		rigid2D.velocity = new Vector2(- speed, rigid2D.velocity.y);
	}

	protected override void Update() {
		base.Update();
		if (!attack && Mathf.Abs(player.transform.position.x - this.transform.position.x) <= 5f) {
			float step = 6.0f * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, 
				new Vector3(transform.position.x, player.transform.position.y, transform.position.z), step);	
			Invoke("Attack", 0.3f);
		}
	}

	private void Attack() {
		attack = true;
	}

}
