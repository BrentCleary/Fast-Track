using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
	[SerializeField] float checkpointTimeExtension = 5f;
	[SerializeField] float obstacleDecreaseTimeAmount = .2f;


	GameManager gameManager;
	ObstacleSpawner obstacleSpawner;

	const string playerString = "Player";

	// Start is called before the first frame update
	void Start()
  {
		gameManager = FindFirstObjectByType<GameManager>();
		obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag(playerString))
        {
			gameManager.IncreaseTime(checkpointTimeExtension);
			obstacleSpawner.DecreaseObstacleSpawnTime(obstacleDecreaseTimeAmount);
		}
			//Debug.Log("CheckPoint Reached");

	}
    
}
