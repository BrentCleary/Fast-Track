using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Apple : Pickup
{

	/* DEV NOTES

	adjustChangeMoveSpeedAmount - Increase the speed of the chunks moving in the level when an apple is picked up


	*/



	[SerializeField] float adjustChangeMoveSpeedAmount = 3f;

	LevelGenerator levelGenerator;

	public void Init(LevelGenerator levelGenerator)
	{
		this.levelGenerator = levelGenerator;
	}

	protected override void OnPickup()
	{
		levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);

	}
}
