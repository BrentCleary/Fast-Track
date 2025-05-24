using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
	[SerializeField] float checkpointTimeExtension = 5f;

	GameManager gameManager;

	const string playerString = "Player";

	// Start is called before the first frame update
	void Start()
    {
		gameManager = FindFirstObjectByType<GameManager>();
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag(playerString))
        {
			gameManager.IncreaseTime(checkpointTimeExtension);
			Debug.Log("CheckPoint Reached");
		}
			//Debug.Log("CheckPoint Reached");

	}
    
}
