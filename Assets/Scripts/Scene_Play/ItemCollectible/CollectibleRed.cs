﻿using UnityEngine;
using System.Collections;

public class CollectibleRed : Collectible {

	#region implemented abstract members of Collectible

	protected override void InitBarAndType ()
	{
		bar = GameObject.Find("RedFire_mid").GetComponent<RedFireMid>();
	}

	#endregion



}
