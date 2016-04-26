using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 startPosition;
	private float positionY;
	private float oldPositionY;
	private bool canSetPositionY;

	private float DIS_PLAYER_CAM = 3.5f;

	public int followSpecial = 0;

	void Start() {
		startPosition = this.transform.position;
		canSetPositionY = true;
		followSpecial = 0;
	}

	public void SetPositionY(float y) {
		if (!canSetPositionY) return;
		if (Mathf.Abs(y - positionY) < float.Epsilon) return;

		oldPositionY = positionY;
		positionY = y;
		canSetPositionY = false;
		Invoke("EnableCanSetPositionY", 2);
	}

	void EnableCanSetPositionY() {
		canSetPositionY = true;
	}


	void Update () {
		if (followSpecial == 1) FollowSpecialPlayer();
		else if (followSpecial == 2) FinishSpecial();
		else 
			FollowPlayer();

		float distance = this.transform.position.x - startPosition.x;
		updateDistance(distance);
	}

	void FollowPlayer() {
		if (FindObjectOfType<PlayerController>().isDead) return;

		float offsetY = FindObjectOfType<PlayerController>().GetOffsetWithCurrent().y;
//		Debug.Log("offsetY " + offsetY);

		if (offsetY < 0) offsetY = 0; //Truong hop player bi roi xuong vuc
//		Debug.Log(Mathf.Abs(positionY - oldPositionY)); 
		if (Mathf.Abs(positionY - oldPositionY) > 0.1) {
			//1
			if (oldPositionY < positionY) oldPositionY += Time.deltaTime;
			else oldPositionY -= Time.deltaTime;

			transform.position = new Vector3(player.transform.position.x + DIS_PLAYER_CAM, oldPositionY + offsetY / 2, transform.position.z);
		} else {
			//2
//			canSetMovingCam = false;
			transform.position = new Vector3(player.transform.position.x + DIS_PLAYER_CAM, positionY + offsetY / 2, transform.position.z);
		}
	}

	void FollowSpecialPlayer() {
		if (transform.position.x - player.transform.position.x > 0) 
			transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
		else {
			transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
			player.GetComponent<PlayerController>().UpDownSpecial();
		}
			
	}

	void FinishSpecial() {
		if (transform.position.x - player.transform.position.x < DIS_PLAYER_CAM) 
			transform.position = new Vector3(transform.position.x + Time.deltaTime*20, transform.position.y, transform.position.z);
		else 
		{
			transform.position = new Vector3(player.transform.position.x + DIS_PLAYER_CAM, transform.position.y, transform.position.z);
			followSpecial = 0;
			player.GetComponent<PlayerController>().afterFinishSpecialSkill();
		}
	}

	public void setSpecial(int special) {
		followSpecial = special;
	}

	void updateDistance(float dis) {
		dis = dis * 6;
		FindObjectOfType<DistanceController>().updateDistance(dis);
		FindObjectOfType<GameBalance>().SetDistance(dis);
	}

	public void updatePosition(float offset) {
	}

}
