using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public GameObject slash;
	public GameObject superSlash;
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
	public bool isChem1;
	public bool isChem2;
	public bool isChem3;

	bool isGameOver;

	float timeGoToGOV;

	private Animator animator;
	public bool saved;

	// Use this for initialization
	void Start () {
		timeButtonHolding = 0;
		timeGoToGOV = 0;
		ButtonHolding = false;
		circleEffect = Instantiate(circleEffectPrefab, transform.position + new Vector3(-0.5f, 1.2f, -1), Quaternion.identity) as GameObject;
		circleEffect.transform.parent = this.transform;
		circleEffect.SetActive(false);
//		Debug.Log (GetComponent<Rigidbody2D>().gravityScale);
		special = false;
		upDown = false;

		specialObj.SetActive(false);

		isDead = false;
		isGameOver = false;
		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if (isDead) return;
		if (ButtonHolding) timeButtonHolding += Time.deltaTime;
		if (timeButtonHolding > 0.3f) {
			circleEffect.SetActive(true);
			if (timeButtonHolding > GameConst.TIME_HOLD_BIG_SLASH) {
				circleEffect.GetComponent<Animator>().SetTrigger("next");
			}
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
	
		if (ItemData.TimeMagnetCount > 0) {
			ItemData.AddTimeMagnet(-Time.deltaTime);
		}

	}

	void FixedUpdate() {
		
		if (isDead) {
			GetComponent<SpriteRenderer>().enabled = false;
			Reborn();
			return;
		} else {
			animator.SetBool("Reborn", false);
		}

		if (isGameOver) return;

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

		if (animator.GetInteger("Died") != 0) Chay (0, 0); else
		Chay(speed, GetComponent<Rigidbody2D>().velocity.y);

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		animator.SetBool("Ground", grounded);

		if (grounded) {
			doubleJump = false;
			currentPosition = this.transform.position;
		}
		animator.SetBool("DoubleJump", doubleJump);
		float verY = GetComponent<Rigidbody2D>().velocity.y;
		animator.SetFloat("verY", verY);

		if (finishedChem) {
			FinishChem();
		}

		if (finishedSuriken) {
			FinishSuriken();
		}
	}

	void OutOfHP() {
//		Debug.Log("Out of HP");
		if (grounded) animator.SetInteger("Died", 1);
		else {
			animator.SetInteger("Died", 2);
		}

		//		animator.SetBool("Ground", grounded);
		//		Debug.Log(animator.GetBool("Die"));
	}

	void Reborn () {

//		Debug.Log("Reborn");

		if (ItemData.UpCount > 0) {
//			Debug.Log ("rebornnnn");

			CameraController mainCam = FindObjectOfType<CameraController> ();
			if (!grounded)
				transform.position = new Vector3(transform.position.x, mainCam.transform.position.y + 3, transform.position.z);

			GetComponent<SpriteRenderer>().enabled = true;
			GetComponent<Collider2D>().enabled = true;
			animator.SetInteger("Died", 0);
			animator.SetBool("Reborn", true);
			HPController hpObject = FindObjectOfType<HPController>();
			hpObject.IncreaseProcess(100);
			isDead = false;
			ItemData.AddUp(-1);
			saved = false;
		} else 
			GameOver();
	
	}

	void GameOver () {
		// TODO -- 
		FindObjectOfType<CameraUpBGController>().ScrollSpeed = 0;
		FindObjectOfType<CameraFrontBGController>().ScrollSpeed = 0;

		isGameOver = true;
		gameOverCanvas.transform.parent.gameObject.SetActive(true);
		gameOverCanvas.GetComponent<Animator>().SetBool("gameover", true);

		if (!saved) {
//			Debug.Log(timeGoToGOV);
			timeGoToGOV += Time.deltaTime;
			if (timeGoToGOV > 5) {
				SceneManager.LoadScene("GameOver");	
				timeGoToGOV = 0;
			}
		} else {
			timeGoToGOV = 0;
		}
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

		if (!isChem1 && !isChem2) {
			animator.SetTrigger("SwordAttack");
			animator.SetBool("Return1", true);
		} else if (isChem1 && !isChem2) {
			animator.SetTrigger("SwordAttack2");
			animator.SetBool("Return1", false);
			animator.SetBool("Return2", true);
		} else if (isChem2) {
			animator.SetTrigger("SwordAttack3");
			animator.SetBool("Return2", false);
			animator.SetBool("Return1", false);
//			animator.SetBool("Return3", true);
		}

//		Vector3 offset = new Vector3(2.5f, 0, 0);

//		if (ItemData.IsUpgradedSlash) {
//			GameObject sl = Instantiate(superSlash, transform.position + offset, Quaternion.identity) as GameObject;
//			sl.transform.parent = transform;
//		} else {
//			GameObject sl = Instantiate(slash, transform.position + offset, Quaternion.identity) as GameObject;
//			sl.transform.parent = transform;
//		}
		//Invoke("FinishChem", 0.9f);
	}

	void FinishChem() {
//		animator.SetBool("FinishChem", true);
	}

	void FinishSuriken() {
		animator.SetBool("SurikenAttack", false);
	}

	public void LaunchKunai() {

		if (special) return;
		if (ItemData.SurikenCount <= 0) return;

		if (grounded) animator.SetTrigger("SurikenAttack");

		ItemData.AddSuriken(-1);

		Vector3 offset = new Vector3(0.7f, 1f, 0);
		GameObject phitieu = Instantiate(kunai, transform.position + offset, Quaternion.identity) as GameObject;

		phitieu.GetComponent<Rigidbody2D>().velocity = new Vector3(kunaiSpeed, 0, 0);
	}

	public void UseDragonSkill() {
		if (special) return;
//		if (ItemData.DragonCount <= 0) return;

		ItemData.AddDragon(-1);

		Vector3 pos = new Vector3(transform.position.x - 10, 0, transform.position.z);
		Instantiate(dragonSkill, pos, Quaternion.identity);
	}

	public void UseChuongSkill() {
		if (special) return;
//		if (ItemData.ChuongCount <= 0) return;
		ItemData.AddChuong(-1);

		if (grounded) animator.SetTrigger("Chuong");
		Vector3 pos = new Vector3(transform.position.x + GameConst.CHUONG_OFFSET_X, transform.position.y + GameConst.CHUONG_OFFSET_Y, transform.position.z);
		Instantiate(chuongSkill, pos, Quaternion.identity);
	}

	public void LaunchBigSlash() {
		if (special) return;

		Vector3 offset = new Vector3(2, 1.2f, 0);
		GameObject phitieu = Instantiate(bigSlash, transform.position + offset, Quaternion.identity) as GameObject;
		
		phitieu.GetComponent<Rigidbody2D>().velocity = new Vector3(kunaiSpeed, 0, 0);
	}

	public void LaunchBigKunai() {
		if (special) return;

		Vector3 offset = new Vector3(1, 1.2f, 0);
		GameObject phitieu = Instantiate(bigKunai, transform.position + offset, Quaternion.identity) as GameObject;
		
		phitieu.GetComponent<Rigidbody2D>().velocity = new Vector3(kunaiSpeed, 0, 0);
	}

	public void Jump() {
		if (special) return;

		if (grounded || !doubleJump) {

			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			animator.SetBool("Ground", false);

			if (!doubleJump && !grounded) {
				doubleJump = true;
				animator.SetBool("DoubleJump", true);
			}
		}
	}

	public Vector3 GetOffsetWithCurrent() {
//		Debug.Log("OffsetWithCurrent: " + (transform.position - currentPosition));

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

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground") {
			CameraController mainCam = FindObjectOfType<CameraController> ();
			float groundPositionY = coll.gameObject.transform.position.y;
			mainCam.SetPositionY(groundPositionY + GameConst.DIS_GROUND_CAM);
		}
	}

	public void UseSpecialSkill() {
//		transform.position = new Vector3(transform.position.x, 0.7f, transform.position.z);
		special = true;
		animator.SetBool("special", true);
		CameraController cam = FindObjectOfType<CameraController>();
		cam.setSpecial(1);
		GetComponent<Rigidbody2D>().isKinematic = true;

		specialObj.SetActive(true);
		speed = speed * 1.5f;
		Invoke("finishSpecialSkill", 4.3f);
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
		animator.SetBool("special", false);
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

	public void Save() {
		FindObjectOfType<CameraUpBGController>().ScrollSpeed = 5;
		FindObjectOfType<CameraFrontBGController>().ScrollSpeed = 10;
		timeGoToGOV = 0;
		saved = true;
		isGameOver = false;
		Time.timeScale = 1;
		Chay(speed, GetComponent<Rigidbody2D>().velocity.y);
		ItemData.AddUp(1);
		Reborn();
	}
	
}
