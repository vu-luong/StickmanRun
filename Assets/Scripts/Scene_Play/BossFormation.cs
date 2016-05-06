﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossFormation : MonoBehaviour {

	public GameObject[] bosses;
	public GameObject bossHPBG;
	public GameObject bossHPProgress;

	public GameObject BossHPProgress {
		get {
			return bossHPProgress;
		}
		set {
			bossHPProgress = value;
		}
	}

	public int pos;

	// Use this for initialization
	void Start () {
		pos = ItemData.Pos;
	}
	
	void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position, 1);
	}

	public void BossAppear() {
		GameObject bossObj = Instantiate(bosses[pos], new Vector3(3.49f, -2.05f, 1), Quaternion.identity) as GameObject;
		bossObj.transform.parent = transform.parent;

		Invoke("BossHPAppear", 1);
	}

	public void BossHPAppear() {
		bossHPBG.SetActive(true);
		bossHPProgress.SetActive(true);
	}

	public void BossHPDisappear() {
		bossHPBG.SetActive(false);
		bossHPProgress.SetActive(false);
	}

	public void ToVictory() {
		Invoke("Victory", 1);
	}

	void Victory() {
		SceneManager.LoadScene("Victory");
	}
}