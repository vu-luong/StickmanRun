using UnityEngine;
using System.Collections;

public class WalkEnemySpawn : MonoBehaviour {

	public GameObject walkEnemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos() {
		Gizmos.DrawCube(transform.position, new Vector3(1, 1, 0));
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "SpawnEnemyDetect") {
			Instantiate(walkEnemy, transform.position, Quaternion.identity);
		}
	}
	
}
