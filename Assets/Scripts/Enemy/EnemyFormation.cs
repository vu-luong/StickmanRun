using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {

	public GameObject enemy;
	public GameObject enemy2;
	private PlayerController player;

	private float timeGenerate = GameConst.TIME_GEN_ENEMY;

	private float timeCount = 0;
	// Use this for initialization
	void Start () {
		timeCount = 0;
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		FollowPlayer();

		timeCount += Time.deltaTime;
		if (timeCount >= timeGenerate) {
			SpawnEnemy();
			timeCount = 0;
		}
	}

	void SpawnEnemy() {
		int t = Random.Range(1, 3);
		if (t == 1)
			Instantiate(enemy, transform.position, Quaternion.identity);
		else 
			Instantiate(enemy2, transform.position, Quaternion.identity);
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position, 1);
	}

	void FollowPlayer() {
		GetComponent<Rigidbody2D>().velocity = new Vector3(player.GetComponent<Rigidbody2D>().velocity.x, 0, 0);
	}

}
