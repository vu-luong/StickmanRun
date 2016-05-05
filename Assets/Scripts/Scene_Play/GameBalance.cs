using UnityEngine;
using System.Collections;

public class GameBalance : MonoBehaviour {
	public GameObject flyEnemySpawn;
	public GameObject walkEnemySpawn;
	public GameObject comboObj;
	public GameObject fireSpawn;
	public GameObject hpItemSpawn;

	public float distance;
	private bool notGenBoss = true;
	private float timeSpawnFlyEnemy, timeSpawnWalkEnemy;
	private float timeSpawnFire, periodTimeSpawnFire;
	private int numSpawnFire;

	private Vector3 offsetFlyEnemySpawn;
	private Vector3 offsetWalkEnemySpawn;
	private Vector3 offsetFireSpawn;
	private Vector3 offsetHPSpawn;

	private float timeCountEnemiesDie;
	private float currentTimeEnemiesDie;
	private int comboNum;

	private int minPeriodTimeSpawnFire = 10;
	private int maxPeriodTimeSpawnFire = 15;

	// Use this for initialization
	void Start () {

		notGenBoss = true;
		offsetFlyEnemySpawn = new Vector3(5, 0, 0);
		offsetWalkEnemySpawn = new Vector3(5, -1, 0);
		offsetFireSpawn = new Vector3(15, -0.7f, 0);
		offsetHPSpawn = new Vector3(15, 1, 0);

		timeCountEnemiesDie = 0;
		numSpawnFire = 0;
		comboNum = 0;
	}

	void Update() {
		timeSpawnFlyEnemy = timeSpawnFlyEnemy + Time.deltaTime;
		timeSpawnWalkEnemy = timeSpawnWalkEnemy + Time.deltaTime;

		if (timeSpawnFlyEnemy > 5) {
			Instantiate(flyEnemySpawn, transform.position + offsetFlyEnemySpawn, Quaternion.identity);
			timeSpawnFlyEnemy = 0;
		}

		if (timeSpawnWalkEnemy > 5.5f) {
			Instantiate(walkEnemySpawn, transform.position + offsetWalkEnemySpawn, Quaternion.identity);
			timeSpawnWalkEnemy = 0;
		}
		/*spawn collectible*/
		timeSpawnFire += Time.deltaTime;
		if (timeSpawnFire > periodTimeSpawnFire) {
			periodTimeSpawnFire = Random.Range(minPeriodTimeSpawnFire, maxPeriodTimeSpawnFire);
			timeSpawnFire = 0;
			numSpawnFire++;

			if (numSpawnFire == 5) {
				SpawnHPItem();
				numSpawnFire = 0;
			} else {
				SpawnFire();
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

	void SpawnFire() {
		Instantiate(fireSpawn, new Vector3(transform.position.x + offsetFireSpawn.x,
			offsetFireSpawn.y, 0), Quaternion.identity);
	}

	void SpawnHPItem() {
		Instantiate(hpItemSpawn, new Vector3(transform.position.x + offsetHPSpawn.x,
			offsetHPSpawn.y, 0), Quaternion.identity);
	}

}
