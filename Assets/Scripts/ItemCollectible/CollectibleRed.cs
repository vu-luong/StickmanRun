using UnityEngine;
using System.Collections;

public class CollectibleRed : Collectible {

	#region implemented abstract members of Collectible

	protected override void InitBarAndType ()
	{
		bar = FindObjectOfType<RedFireMid>();
	}

	#endregion



}
