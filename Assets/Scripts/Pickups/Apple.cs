using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Apple : Pickup
{
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
