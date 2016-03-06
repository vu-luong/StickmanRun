using UnityEngine;
using System.Collections;

public class DragonController : MonoBehaviour {

	public float speed = GameConst.DRAGON_SPEED;
	
	void Update () {
			
		GetComponent<Rigidbody2D> ().velocity = new Vector2(speed, GetComponent<Rigidbody2D> ().velocity.y);
	}

}
