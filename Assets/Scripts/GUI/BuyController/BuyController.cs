using UnityEngine;
using System.Collections;

public abstract class BuyController : MonoBehaviour {
	public GameObject completeCanvas;
	public GameObject buyCanvas;

	protected abstract void BuyCompleted();

	public void Buy() {
		buyCanvas.SetActive(false);
		completeCanvas.SetActive(true);
		BuyCompleted();
	}

	public void Continue() {
		completeCanvas.SetActive(false);
		buyCanvas.SetActive(true);
	}
}
