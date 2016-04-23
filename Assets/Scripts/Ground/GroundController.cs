using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {

	private int numberOfTiles;
	private float tileWidth;
	public GameObject groundTile;
	public GameObject groundTileStart;
	public GameObject groundTileEnd;
	public GameObject groundChong;
	public GameObject groundFormation;
	public GameObject chong1;

	// Use this for initialization
	void Awake () {
		tileWidth = groundTile.GetComponent<SpriteRenderer>().bounds.size.x;
		numberOfTiles = Random.Range(6, 10);
		SpawnGround();
		SpawnFormation();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnGround() {
		// add begin tiles

		int r = Random.Range(2, numberOfTiles - 1);

		for (int i = 1; i <= numberOfTiles; i++) {
			Vector3 offset = new Vector3((i - 1) * tileWidth, 0, 0);
			GameObject groundTileObject;
			if (i == 1) {
				groundTileObject = Instantiate(groundTileStart, transform.position + offset, Quaternion.identity) as GameObject;
			} else if (i == numberOfTiles) {
				groundTileObject = Instantiate(groundTileEnd, transform.position + offset, Quaternion.identity) as GameObject;
			} else if (i != r) {
				groundTileObject = Instantiate(groundTile, transform.position + offset, Quaternion.identity) as GameObject;
			} else {
				groundTileObject = Instantiate(groundChong, transform.position + offset, Quaternion.identity) as GameObject;
			}

			groundTileObject.transform.parent = transform;

		}

		//add end tiles


	}

	void SpawnFormation() {
		int rand = Random.Range(1, 3);
		float y = 0;
//		if (rand == 1) y = 1;
//		else if (rand == 2) y = -1;

		Vector3 offset = new Vector3((numberOfTiles + 1) * tileWidth, y, 0);
		GameObject groundFormationObject = Instantiate(groundFormation, transform.position + offset, Quaternion.identity) as GameObject;
		groundFormationObject.transform.parent = transform;

		GameObject chongObj = Instantiate(chong1, 
		                                  new Vector3(transform.position.x + (numberOfTiles + 0.5f)  * tileWidth, -2.0f + Mathf.Min(transform.position.y, transform.position.y + y), 0), 
		                                  Quaternion.identity) as GameObject;

//		chongObj.transform.parent = transform;

	}
}
