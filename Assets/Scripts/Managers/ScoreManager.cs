using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] GameManager gameManager;
	[SerializeField] TMP_Text scoreText;

	int score = 0;


    public static ScoreManager instance;
    public int playerScore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



	public void IncreaseScore(int amount)
	{

			if(gameManager.GameOver) return;

	score += amount;
	scoreText.text = score.ToString();
	}

}
