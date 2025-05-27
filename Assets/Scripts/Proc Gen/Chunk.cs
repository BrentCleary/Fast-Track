using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Spawn Prefabs")]
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;

    [Header("Item Spawn Parameters")]
    [SerializeField] float appleSpawnChance = .3f;
    [SerializeField] float coinSpawnChance = .5f;
    [SerializeField] float coinSeperationLength = 2;
	[SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };

	LevelGenerator levelGenerator;
	ScoreManager scoreManager;

	List<int> availableLanes = new List<int> {0, 1, 2};

	List<int> prevFenceList = new List<int>();
	List<List<int>> doubleFences = new List<List<int>>() { new List<int>() { 0, 1 }, new List<int>() { 1, 2 } };

	// Start is called before the first frame update
	void Start()
    {
		SpawnFences();
        SpawnApple();
        SpawnCoins();
    }

    public void Init(LevelGenerator levelGenerator, ScoreManager scoreManager)
    {
		this.levelGenerator = levelGenerator;
		this.scoreManager = scoreManager;
	}


    int SelectLane()
	{
		int randomLaneIndex = Random.Range(0, availableLanes.Count);
		int selectedLane = availableLanes[randomLaneIndex];
		availableLanes.RemoveAt(randomLaneIndex);
		return selectedLane;
	}


    void SpawnFences()
    {
		List<int> fenceLaneList = SelectFenceLanes();

		foreach(int lane in fenceLaneList)
        {
            Vector3 spawnPosition = new Vector3(lanes[lane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
	}


    List<int> SelectFenceLanes()
    {
		List<int> fenceLaneList = new List<int>();
        
        int fencesToSpawn = Random.Range(0, lanes.Length);  // Lanes.Length = 3. Exclusive. fencesToSpawn maxes at 2.
		int selectedLane;

		for (int i = 0; i < fencesToSpawn; i++)
		{
			selectedLane = SelectLane();
			fenceLaneList.Add(selectedLane);
		}

        if(IsDoubleFence(prevFenceList))
        {
			Debug.Log("<<<<< doubleFences Found >>>>>");
			fenceLaneList = SelectFenceLanes();
		}

		prevFenceList = fenceLaneList;

		return fenceLaneList;
	}

    bool IsDoubleFence(List<int> fenceList)
    {
        return doubleFences.Any(df => df.OrderBy(x => x).SequenceEqual(fenceList.OrderBy(x => x)));
    }


	void SpawnApple()
    {
        if(Random.value > appleSpawnChance || availableLanes.Count <= 0 ) return;

        int selectedLane = SelectLane();

        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Apple newApple = Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Apple>();
		newApple.Init(levelGenerator);
	}


	void SpawnCoins()
    {
        if(Random.value > coinSpawnChance || availableLanes.Count <= 0) return;

        int selectedLane = SelectLane();
    
        int maxCoinsToSpawn = 6;
        int coinsToSpawn = Random.Range(1, maxCoinsToSpawn);

        float topOfChunkZPos = transform.position.z + (coinSeperationLength * 2f);

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkZPos - (i * coinSeperationLength);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPositionZ);
            Coin newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Coin>();
			newCoin.Init(scoreManager);
		}
    }


}
