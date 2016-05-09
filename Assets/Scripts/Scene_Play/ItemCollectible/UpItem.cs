using UnityEngine;
using System.Collections;

public class UpItem : MonoBehaviour {

	public GameObject effect;

	void OnTriggerEnter2D(Collider2D other) {
		string tag = other.gameObject.tag;
		if (tag == "Player") {
			ItemData.AddUp(1);

			Instantiate(effect, transform.position + new Vector3(0.5f, 1, 0), Quaternion.identity);

			Destroy(gameObject);
		}
	}
}
