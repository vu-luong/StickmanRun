using UnityEngine;
using System.Collections;

public class TimeToSpawnEnemyPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position, 1);
		Gizmos.DrawWireSphere(transform.position, 0.5f);
	}

	void OnTriggerEnter2D(Collider2D col) {

//		Debug.Log("mehhhhhhhh");

		// Can bang game o day :'(




	}
}
