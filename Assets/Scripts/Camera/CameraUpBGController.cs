﻿using UnityEngine;
using System.Collections;

public class CameraUpBGController : MonoBehaviour {

	public float scrollSpeed;
	private float tileSizeZ;
	public GameObject bg1;
	public GameObject bg2;
	
	private Vector3 startPosition;
	
	void Start () {
		startPosition = transform.position;
		tileSizeZ = bg2.transform.position.x - bg1.transform.position.x;
	}
	
	void Update (){
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.right * newPosition;

		float offsetY = FindObjectOfType<PlayerController>().GetOffsetWithCurrent().y;
		if (offsetY < 0) offsetY = 0; //Truong hop player bi roi xuong vuc

		transform.position = transform.position + new Vector3(0, offsetY / 10, 0);

	}

}