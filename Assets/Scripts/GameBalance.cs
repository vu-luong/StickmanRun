using UnityEngine;
using System.Collections;

public class GameBalance : MonoBehaviour {
	public float distance;

	private bool notGenBoss = true;

	// Use this for initialization
	void Start () {
		notGenBoss = true;
	}

	public void SetDistance (float distance) {
		this.distance = distance;
		if (distance >= 1000 && notGenBoss == true) {
			GenBoss();
			notGenBoss = false;
		}
	}

	public void GenBoss () {
		FindObjectOfType<BossFormation>().BossAppear();
	}
}
