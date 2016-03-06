using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject slash;
	public GameObject kunai;
	public GameObject dragonSkill;
	public GameObject chuongSkill;
	public GameObject bigKunai;
	public GameObject bigSlash;
	public GameObject circleEffectPrefab;
	public GameObject specialObj;
	public GameObject gameOverCanvas;

	public Transform groundCheck;
	public LayerMask whatIsGround;

	private float speed = GameConst.PLAYER_SPEED;
	private float jumpHeight = GameConst.PLAYER_JUMP_HEIGHT;
	private float kunaiSpeed = GameConst.KUNAI_SPEED;
	private bool grounded = false;
	private float groundRadius = 0.2f;
	private bool doubleJump = false;

	private Vector3 currentPosition;
	private float positionYBeforeUpDown;

	private bool ButtonHolding;
	private float timeButtonHolding;

	private GameObject circleEffect;
	private bool special;
	private bool upDown = false;
	private int signUpDown = 1;

	public bool finishedChem;
	public bool finishedSuriken;

	public bool isDead;

	bool isGameOver;

	// Use this for initialization
	void Start () {
		timeButtonHolding = 0;
		ButtonHolding = false;
		circleEffect = Instantiate(circleEffectPrefab, transform.position + new Vector3(0, 0, -1), Quaternion.identity) as GameObject;
		circleEffect.transform.parent = this.transform;
		circleEffect.SetActive(false);
//		Debug.Log (GetComponent<Rigidbody2D>().gravityScale);
		special = false;
		upDown = false;

		specialObj.SetActive(false);

		isDead = false;
		isGameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead) return;
		if (ButtonHolding) timeButtonHolding += Time.deltaTime;
		if (timeButtonHolding > 0.1f) {
			circleEffect.SetActive(true);
		}

		if (Input.GetKeyDown(KeyCode.F)) {
			Chem();
			OnButtonDown();
//			Debug.Log("Hold F");
		}

		if (Input.GetKeyUp(KeyCode.F)) {
			OnButtonUp();
//			Debug.Log("release F");
		}

		if (Input.GetKeyDown(KeyCode.A)) {
			LaunchKunai();
		}

		if (Input.GetKeyDown(KeyCode.D)) {
			UseChuongSkill();
		}

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			Jump();
		}

		if (Input.GetKeyDown(KeyCode.S)) {
			UseDragonSkill();
		}

		if (Input.GetKeyDown(KeyCode.C)) {
			UseSpecialSkill();
		}

		if (Input.GetKeyDown(KeyCode.V)) {
			finishSpecialSkill();
		}

		if (Input.GetKeyDown(KeyCode.U)) {
			DataPref.addNumData(GameConst.NUM_COLLECT_KEY, -30);
		}

		if (Input.GetKeyDown(KeyCode.I)) {
			DataPref.addNumData(GameConst.NUM_COLLECT_KEY, 30);
		}
	
		//if (!grounded) Debug.Log(GetComponent<Rigidbody2D>().velocity);

	}

	void FixedUpdate() {
		if (isGameOver) return;
		if (isDead) {
			GetComponent<SpriteRenderer>().enabled = false;
			Reborn();
			return;
		} else {
			GetComponent<Animator>().SetBool("Reborn", false);
		}

		if (upDown) {
			float t = transform.position.y - positionYBeforeUpDown;
//			Debug.Log(t);
			if (Mathf.Abs(t) < 1.5f) {
				transform.position = new Vector3(transform.position.x, transform.position.y + signUpDown*10*Time.deltaTime, transform.position.z);
			} else {
				signUpDown *= -1;
				transform.position = new Vector3(transform.position.x, transform.position.y + signUpDown*10*Time.deltaTime, transform.position.z);
			}
		}

		if (GetComponent<Animator>().GetBool("Die")) Chay (0, 0); else
		Chay(speed, GetComponent<Rigidbody2D>().velocity.y);

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		GetComponent<Animator>().SetBool("Ground", grounded);

		if (grounded) {
			doubleJump = false;
			currentPosition = this.transform.position;
		}
		GetComponent<Animator>().SetBool("DoubleJump", doubleJump);
		float verY = GetComponent<Rigidbody2D>().velocity.y;
		GetComponent<Animator>().SetFloat("verY", verY);

		if (finishedChem) {
			FinishChem();
		}

		if (finishedSuriken) {
			FinishSuriken();
		}
	}

	void Reborn () {
			
		if (ItemData.UpCount > 0) {
			Debug.Log ("rebornnnn");

			CameraController mainCam = FindObjectOfType<CameraController> ();
			transform.position = new Vector3(transform.position.x, mainCam.transform.position.y + 3, transform.position.z);

			GetComponent<SpriteRenderer>().enabled = true;
			GetComponent<Collider2D>().enabled = true;
			GetComponent<Animator>().SetBool("Die", false);
			GetComponent<Animator>().SetBool("Reborn", true);
			HPController hpObject = FindObjectOfType<HPController>();
			hpObject.IncreaseProcess(100);
			isDead = false;
			ItemData.AddUp(-1);
		} else {
			GameOver();
		}
	
	}

	void GameOver () {
		// TODO -- 
		isGameOver = true;
		gameOverCanvas.GetComponent<Animator>().SetBool("gameover", true);
		Invoke("GoToGameOver", 5);
	}

	void GoToGameOver() {
		Application.LoadLevel("GameOver");
	}

	void Chay(float vSpeed, float hSpeed) {
		GetComponent<Rigidbody2D>().velocity = new Vector2(vSpeed, hSpeed);
	}

	public void OnButtonDown() {
		ButtonHolding = true;
	}

	public void OnButtonUp() {

		if (special) {
			timeButtonHolding = 0;
			circleEffect.SetActive(false);
			ButtonHolding = false;
			return;
		}
		ButtonHolding = false;

		if (timeButtonHolding >= GameConst.TIME_HOLD_BIG_SLASH) {
			LaunchBigSlash();
		} else if (timeButtonHolding >= GameConst.TIME_HOLD_BIG_KUNAI) {
			LaunchBigKunai();
		}

		timeButtonHolding = 0;
		circleEffect.SetActive(false);
	}

	public void Chem() {
		if (special) return;

		GetComponent<Animator>().SetBool("SwordAttack", true);

		Vector3 offset = new Vector3(2.5f, 0, 0);
		GameObject sl = Instantiate(slash, transform.position + offset, Quaternion.identity) as GameObject;
		sl.transform.parent = transform;

		//Invoke("FinishChem", 0.9f);
	}

	void FinishChem() {
		GetComponent<Animator>().SetBool("SwordAttack", false);
	}

	void FinishSuriken() {
		GetComponent<Animator>().SetBool("SurikenAttack", false);
	}

	public void LaunchKunai() {

		if (special) return;
		if (ItemData.SurikenCount <= 0) return;

		GetComponent<Animator>().SetBool("SurikenAttack", true);
		ItemData.AddSuriken(-1);

		Vector3 offset = new Vector3(1, 0, 0);
		GameObject phitieu = Instantiate(kunai, transform.position + offset, Quaternion.identity) as GameObject;

		phitieu.GetComponent<Rigidbody2D>().velocity = new Vector3(kunaiSpeed, 0, 0);
	}

	public void UseDragonSkill() {
		if (special) return;
		if (ItemData.DragonCount <= 0) return;

		ItemData.AddDragon(-1);

		Vector3 pos = new Vector3(transform.position.x - 10, 0, transform.position.z);
		Instantiate(dragonSkill, pos, Quaternion.identity);
	}

	public void UseChuongSkill() {
		if (special) return;
		if (ItemData.ChuongCount <= 0) return;
		ItemData.AddChuong(-1);

		Vector3 pos = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
		Instantiate(chuongSkill, pos, Quaternion.identity);
	}

	public void LaunchBigSlash() {
		if (special) return;

		Vector3 offset = new Vector3(2, 0, 0);
		GameObject phitieu = Instantiate(bigSlash, transform.position + offset, Quaternion.identity) as GameObject;
		
		phitieu.GetComponent<Rigidbody2D>().velocity = new Vector3(kunaiSpeed, 0, 0);
	}

	public void LaunchBigKunai() {
		if (special) return;

		Vector3 offset = new Vector3(1, 0, 0);
		GameObject phitieu = Instantiate(bigKunai, transform.position + offset, Quaternion.identity) as GameObject;
		
		phitieu.GetComponent<Rigidbody2D>().velocity = new Vector3(kunaiSpeed, 0, 0);
	}

	public void Jump() {
		if (special) return;

		if (grounded || !doubleJump) {

			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			GetComponent<Animator>().SetBool("Ground", false);

			if (!doubleJump && !grounded) {
				doubleJump = true;
				GetComponent<Animator>().SetBool("DoubleJump", true);
			}
		}
	}

	public Vector3 GetOffsetWithCurrent() {
		return transform.position - currentPosition;
	}

	public void beAttacked(int damage) {
		if (special) return;

		HPController hpObject = FindObjectOfType<HPController>();

		hpObject.DecreaseProcess(damage);

		if (Mathf.Abs(hpObject.GetProgress()) < 0.1f) {
			OutOfHP();
		}
	}

	void OutOfHP() {
		GetComponent<Animator>().SetBool("Die", true);
//		Debug.Log(GetComponent<Animator>().GetBool("Die"));
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground") {
			CameraController mainCam = FindObjectOfType<CameraController> ();
			float groundPositionY = coll.gameObject.transform.position.y;
			mainCam.SetPositionY(groundPositionY + GameConst.DIS_GROUND_CAM);
		}
	}

	public void UseSpecialSkill() {
		special = true;
		GetComponent<Animator>().SetBool("special", true);
		CameraController cam = FindObjectOfType<CameraController>();
		cam.setSpecial(1);
		GetComponent<Rigidbody2D>().isKinematic = true;

		specialObj.SetActive(true);
		speed = speed * 1.5f;
		Invoke("finishSpecialSkill", 4);
	}

	public void finishSpecialSkill() {
		speed = speed / 1.5f;
		upDown = false;
		CameraController cam = FindObjectOfType<CameraController>();
		cam.setSpecial(2);

		specialObj.SetActive(false);
	}

	public void afterFinishSpecialSkill() {
		special = false;
		GetComponent<Animator>().SetBool("special", false);
		GetComponent<Rigidbody2D>().isKinematic = false;
	}

	public void Collect (Collectible item) {
		item.BeCollected();
	}

	public void UpDownSpecial(){
		if (upDown) return;
		upDown = true;
		positionYBeforeUpDown = transform.position.y;
//		Debug.Log("positionYBeforeUpDown: " + positionYBeforeUpDown);
	}
	
}
