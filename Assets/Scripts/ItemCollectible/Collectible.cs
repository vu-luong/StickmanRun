using UnityEngine;
using System.Collections;

public abstract class Collectible : MonoBehaviour {

	protected ProgressBar bar;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		InitBarAndType();
		player = FindObjectOfType<PlayerController>();
	}

	void Update() {
		if (Vector2.Distance(transform.position, player.transform.position) > 10) return;

		if (ItemData.TimeMagnetCount > 0) {
			float step = 20.0f * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
			ItemData.AddTimeMagnet(-Time.deltaTime);
			Debug.Log(ItemData.TimeMagnetCount);
		}
	}

	protected abstract void InitBarAndType();

	void OnTriggerEnter2D(Collider2D other) {
		string tag = other.gameObject.tag;
		if (tag == "Player" || tag == "PlayerSpecial") {
			player.Collect(this);
		}
	}

	public void BeCollected() {
		bar.IncreaseProcess(3);
		DataPref.addNumData(GameConst.NUM_COLLECT_KEY, 1);

		Destroy(gameObject);
	}

}
