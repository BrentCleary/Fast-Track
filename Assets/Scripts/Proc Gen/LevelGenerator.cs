using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;

    List<GameObject> chunks = new List<GameObject>();

    public void Start()
	{
		SpawnStartingChunks();
	}

    public void Update()
    {
        MoveChunks();
    }

    public void ChangeChunkMoveSpeed(float speedAmount)
    {
        moveSpeed += speedAmount;

        if(moveSpeed < minMoveSpeed)
        {
            moveSpeed = minMoveSpeed;
        }
		Debug.Log("Z Gravity Before: " + Physics.gravity.z);
    
        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z - speedAmount);
	
        Debug.Log("Z Gravity Before: " + Physics.gravity.z);
	}

	void SpawnStartingChunks()
	{
		for (int i = 0; i < startingChunksAmount; i++)
		{
			SpawnChunk();
		}
	}

	private void SpawnChunk()
	{
		float spawnPositionZ = CalculateSpawnPositionZ();

		Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
		GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

		chunks.Add(newChunk);
	}

	float CalculateSpawnPositionZ()
	{
		float spawnPositionZ;
		
        if (chunks.Count == 0)
		{
			spawnPositionZ = transform.position.z;
		}
		else
		{
            spawnPositionZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;
		}

		return spawnPositionZ;
	}

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];

            chunk.transform.Translate(-transform. forward * (moveSpeed * Time.deltaTime));

            if(chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            };

            
        }
    }

}
