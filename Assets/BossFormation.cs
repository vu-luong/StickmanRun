using UnityEngine;
using System.Collections;

public class BossFormation : MonoBehaviour {

	public GameObject boss;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position, 1);
	}

	public void BossAppear() {
		GameObject bossObj = Instantiate(boss, new Vector3(3.49f, -2.05f, 1), Quaternion.identity) as GameObject;
		bossObj.transform.parent = transform.parent;
	}
}
