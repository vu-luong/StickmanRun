using UnityEngine;
using System.Collections;

public class ChuongController : MonoBehaviour {

	public bool isOut;

	void Start () {
		isOut = false;
	}
	
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag("Player") as GameObject;

		Vector3 offset = new Vector3(GameConst.CHUONG_OFFSET_X, GameConst.CHUONG_OFFSET_Y, 0);
		this.transform.position = player.transform.position + offset;

		if (isOut) Destroy(gameObject);
	}

}
