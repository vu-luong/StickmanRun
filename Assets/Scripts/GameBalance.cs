using UnityEngine;
using System.Collections;

public class GameBalance : MonoBehaviour {
	public GameObject flyEnemySpawn;
	public GameObject walkEnemySpawn;
	public GameObject comboObj;

	public float distance;
	private bool notGenBoss = true;
	private float timeSpawnFlyEnemy, timeSpawnWalkEnemy;
	private Vector3 offsetFlyEnemySpawn;
	private Vector3 offsetWalkEnemySpawn;

	private float timeCountEnemiesDie;
	private float currentTimeEnemiesDie;
	private int comboNum;

	// Use this for initialization
	void Start () {
		notGenBoss = true;
		offsetFlyEnemySpawn = new Vector3(5, 0, 0);
		offsetWalkEnemySpawn = new Vector3(5, -1, 0);
		timeCountEnemiesDie = 0;
		comboNum = 0;
	}

	void Update() {
		timeSpawnFlyEnemy = timeSpawnFlyEnemy + Time.deltaTime;
		timeSpawnWalkEnemy = timeSpawnWalkEnemy + Time.deltaTime;

		if (timeSpawnFlyEnemy > 5) {
//			Debug.Log("Den day roi");
			Instantiate(flyEnemySpawn, transform.position + offsetFlyEnemySpawn, Quaternion.identity);
			timeSpawnFlyEnemy = 0;
		}

		if (timeSpawnWalkEnemy > 5.5f) {
			Instantiate(walkEnemySpawn, transform.position + offsetWalkEnemySpawn, Quaternion.identity);
			timeSpawnWalkEnemy = 0;
		}

		/*
		 * 
		 */	
		timeCountEnemiesDie += Time.deltaTime;

		if (timeCountEnemiesDie - currentTimeEnemiesDie > 1) {
			DisapearCombo();
		}
	}

	public void SetDistance (float distance) {
		this.distance = distance;
		if (distance >= 100 && notGenBoss == true) {
			GenBoss();
			notGenBoss = false;
		}
	}

	public void GenBoss () {
		FindObjectOfType<BossFormation>().BossAppear();
	}

	public void EnemyDieTrigger() {
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
	}

	void AppearCombo() {
		comboObj.SetActive(true);
		//Invoke("DisapeatCombo", 0.5f);
	}

	void DisapearCombo() {
		comboObj.SetActive(false);
	}
}
