using System.Collections;
using System.Collections.Generic;
using System.Security;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] PlayerController playerController;
	[SerializeField] TMP_Text timeText;
	[SerializeField] GameObject gameOverText;
	[SerializeField] float startTime = 60f;

	float timeLeft;
	bool gameOver = false;

	public bool GameOver => gameOver;


	void Start()
    {
		timeLeft = startTime;
	}

    void Update()
	{
		DecreaseTime();
	}

    public void IncreaseTime(float amount)
    {
        timeLeft += amount;
	}

	void DecreaseTime()
	{
		if (gameOver) return;

		timeLeft -= Time.deltaTime;
		timeText.text = timeLeft.ToString("F1");

		if (timeLeft <= 0f)
		{
			PlayerGameOver();
		}
	}

    public bool ReturnGameOver()
    {
		return gameOver;
	}

	void PlayerGameOver()
    {
		gameOver = true;
		playerController.enabled = false;
		gameOverText.SetActive(true);
		Time.timeScale = .1f;

	}

}
