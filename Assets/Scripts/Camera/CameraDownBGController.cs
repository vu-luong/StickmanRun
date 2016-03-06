using UnityEngine;
using System.Collections;

public class CameraDownBGController : MonoBehaviour {

	Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float offsetY = FindObjectOfType<PlayerController>().GetOffsetWithCurrent().y;
		if (offsetY < 0) offsetY = 0; //Truong hop player bi roi xuong vuc

		transform.position = startPosition + new Vector3(0, offsetY / 15, 0);
	}
}
