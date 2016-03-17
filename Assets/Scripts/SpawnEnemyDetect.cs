using UnityEngine;
using System.Collections;

public class SpawnEnemyDetect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos() {
		Gizmos.DrawCube(transform.position, new Vector3(1, 15, 0));
	}

}
