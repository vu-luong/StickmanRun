using UnityEngine;
using System.Collections;

public class UpItem : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		string tag = other.gameObject.tag;
		if (tag == "Player") {
			ItemData.AddUp(1);

			Destroy(gameObject);
		}
	}
}
