using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour {
	private float startX;
	private float length = 325;

	// Use this for initialization
	void Start () {
		Debug.Log(GetComponent<RectTransform>().localPosition);
		startX = GetComponent<RectTransform>().localPosition.x;
	}
	
	// Update is called once per frame
	void Update () {
		float posX = startX + length*DistanceController.runDistance*1.0f / 50000;
//		Debug.Log(length*DistanceController.runDistance*1.0f / 50000);

		GetComponent<RectTransform>().localPosition = new Vector3(posX, 
			GetComponent<RectTransform>().localPosition.y,
			GetComponent<RectTransform>().localPosition.z);

	}
}
