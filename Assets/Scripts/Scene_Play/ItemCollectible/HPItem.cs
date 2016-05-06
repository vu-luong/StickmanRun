using UnityEngine;
using System.Collections;

public class HPItem : MonoBehaviour {

	private HPController hpController;

	void Start() {
		hpController = GameObject.Find("HP_mid").GetComponent<HPController>();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		string tag = other.gameObject.tag;
		if (tag == "Player") {
			
			hpController.IncreaseProcess(40);
			Destroy(gameObject);
		}
	}
}
