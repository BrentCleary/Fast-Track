using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : Pickup
{
	[SerializeField] int scoreAmount = 100;

	ScoreManager scoreManager;

	public void Init(ScoreManager scoreManager)
	{
		this.scoreManager = scoreManager;
	}

	void Start()
	{
		scoreManager = FindFirstObjectByType<ScoreManager>();
	}

	protected override void OnPickup()
	{
		scoreManager.IncreaseScore(scoreAmount);
		Debug.Log("Add 100 points");
	}

}
