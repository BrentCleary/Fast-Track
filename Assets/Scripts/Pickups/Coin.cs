using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Pickup
{

	protected override void OnPickup()
	{
		Debug.Log("Add 100 points");
	}

}
