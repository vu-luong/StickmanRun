﻿using UnityEngine;
using System.Collections;

public class GameBalance : MonoBehaviour {
	public GameObject flyEnemySpawn;
	public GameObject walkEnemySpawn;
	public GameObject comboObj;
	public GameObject fireSpawn;
	public GameObject hpItemSpawn;
	public GameObject specialItemSpawn;
	public GameObject kunaiItemSpawn;
	public GameObject upItemSpawn;
	public BossFormation bossFormation;

	public float distance;
	private bool notGenBoss = true;
	private float timeSpawnFlyEnemy, timeSpawnWalkEnemy;
	private float timeSpawnFlyEnemyPeriod, timeSpawnWalkEnemyPeriod;
	private float timeSpawnFire, periodTimeSpawnFire;
	private int numSpawnFire;

	private Vector3 offsetFlyEnemySpawn;
	private Vector3 offsetWalkEnemySpawn;
	private Vector3 offsetFireSpawn;
	private Vector3 offsetHPSpawn;
	private Vector3 offsetSpecialSpawn;
	private Vector3 offsetKunaiSpawn;
	private Vector3 offsetUpSpawn;

	private float timeCountEnemiesDie;
	private float currentTimeEnemiesDie;
	private int comboNum;

	private int minPeriodTimeSpawnFire = 8;
	private int maxPeriodTimeSpawnFire = 13;

	// Use this for initialization
	void Start () {

		notGenBoss = true;
		offsetFlyEnemySpawn = new Vector3(5, 0, 0);
		offsetWalkEnemySpawn = new Vector3(5, -1, 0);
		offsetFireSpawn = new Vector3(15, -0.7f, 0);
		offsetHPSpawn = new Vector3(15, 1, 0);
		offsetSpecialSpawn = new Vector3(15, 1, 0);
		offsetKunaiSpawn = new Vector3(15, 1, 0);
		offsetUpSpawn = new Vector3(15, 1, 0);
		timeSpawnFlyEnemyPeriod = 5;
		timeSpawnWalkEnemyPeriod = 5.5f;

		timeCountEnemiesDie = 0;
		numSpawnFire = 0;
		comboNum = 0;
	}

	void Update() {
		timeSpawnFlyEnemy = timeSpawnFlyEnemy + Time.deltaTime;
		timeSpawnWalkEnemy = timeSpawnWalkEnemy + Time.deltaTime;

		if (timeSpawnFlyEnemy > timeSpawnFlyEnemyPeriod) {
			timeSpawnFlyEnemyPeriod -= 0.05f;
			if (timeSpawnFlyEnemyPeriod <= 1) timeSpawnFlyEnemyPeriod = 1;
//			Debug.Log(timeSpawnFlyEnemyPeriod);
			Instantiate(flyEnemySpawn, transform.position + offsetFlyEnemySpawn, Quaternion.identity);
			timeSpawnFlyEnemy = 0;
		}

		if (timeSpawnWalkEnemy > timeSpawnWalkEnemyPeriod) {
			timeSpawnWalkEnemyPeriod -= 0.07f;
			if (timeSpawnWalkEnemyPeriod <= 1) timeSpawnWalkEnemyPeriod = 1;

			Instantiate(walkEnemySpawn, transform.position + offsetWalkEnemySpawn, Quaternion.identity);
			timeSpawnWalkEnemy = 0;
		}
		/*spawn collectible*/
		timeSpawnFire += Time.deltaTime;
		if (timeSpawnFire > periodTimeSpawnFire) {
			periodTimeSpawnFire = Random.Range(minPeriodTimeSpawnFire, maxPeriodTimeSpawnFire);
			timeSpawnFire = 0;
			numSpawnFire++;

			if (numSpawnFire % 3 == 0 && numSpawnFire != 9) {
				int r = Random.Range(1, 4);
				if (r == 1) SpawnHPItem();
					else if (r == 2) SpawnSpecial();
				else if (r == 3) SpawnKunai();

//				numSpawnFire = 0;
			} else 
				if (numSpawnFire == 9) {
					SpawnUp();
					numSpawnFire = 0;
				} else {
//				SpawnFire();
			}

		}


		/*count combo*/	
		timeCountEnemiesDie += Time.deltaTime;

		if (timeCountEnemiesDie - currentTimeEnemiesDie > 1) {
			DisapearCombo();
		}
	}

	public void SetDistance (float distance) {
		this.distance = distance;
		if (distance >= 1000 && notGenBoss == true) {
			GenBoss();
			notGenBoss = false;
		}
	}

	public void GenBoss () {
		bossFormation.BossAppear();
	}

	public void EnemyDieTrigger(string tag) {
//		Debug.Log(timeCountEnemiesDie);
		float e = timeCountEnemiesDie - currentTimeEnemiesDie;
		currentTimeEnemiesDie = timeCountEnemiesDie;

		if (e < 0.5f) {
			comboNum++;

			if (comboNum > 1) {
				ComboCount.ComboNum = comboNum;
				AppearCombo();
			}

		} else {
			comboNum = 1;
			timeCountEnemiesDie = 0;
			currentTimeEnemiesDie = 0;
		}

		if (tag == "Boss1") {
			Invoke("GenBoss", 17.0f);
		}


	}

	void AppearCombo() {
		comboObj.SetActive(true);
		//Invoke("DisapeatCombo", 0.5f);
	}

	void DisapearCombo() {
		comboObj.SetActive(false);
	}

	void SpawnFire() {
		Instantiate(fireSpawn, new Vector3(transform.position.x + offsetFireSpawn.x,
			offsetFireSpawn.y, 0), Quaternion.identity);
	}

	void SpawnHPItem() {
		Instantiate(hpItemSpawn, new Vector3(transform.position.x + offsetHPSpawn.x,
			offsetHPSpawn.y, 0), Quaternion.identity);
	}

	void SpawnSpecial() {
		Instantiate(specialItemSpawn, new Vector3(transform.position.x + offsetSpecialSpawn.x,
			offsetSpecialSpawn.y, 0), Quaternion.identity);
	}

	void SpawnKunai() {
		Instantiate(kunaiItemSpawn, new Vector3(transform.position.x + offsetKunaiSpawn.x,
			offsetKunaiSpawn.y, 0), Quaternion.identity);
	}

	void SpawnUp() {
		Instantiate(upItemSpawn, new Vector3(transform.position.x + offsetUpSpawn.x,
			offsetUpSpawn.y, 0), Quaternion.identity);
	}
}
