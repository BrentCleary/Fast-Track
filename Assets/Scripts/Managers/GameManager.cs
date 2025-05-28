using System.Collections;
using System.Collections.Generic;
using System.Security;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	[SerializeField] PlayerController playerController;
	[SerializeField] TMP_Text timeText;
	[SerializeField] GameObject gameOverText;
	[SerializeField] float startTime = 30f;
	[SerializeField] GameObject pausePanel;
	[SerializeField] Button quitButton;
	[SerializeField] bool isActive = true;

	float timeLeft;
	bool gameOver = false;

	public bool GameOver => gameOver;

	public static GameManager instance;
	public int playerScore;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
			DontDestroyOnLoad(pausePanel);
			
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Start()
  {
		timeLeft = startTime;
		quitButton.onClick.AddListener(QuitGame);
		pausePanel.SetActive(false);
	}

  void Update()
	{
		DecreaseTime();

		if(Input.GetKeyDown(KeyCode.Q))
		{
			PauseGameCtrl();
		}
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

	void QuitGame()
	{
		SceneManager.LoadScene(0);
	}

	void PauseGameCtrl()
	{
		Scene currentScene = SceneManager.GetActiveScene();

		if (currentScene.buildIndex != 0)										// Checks that scene is not MainMenu (index 0)
		{
			isActive = !isActive;

			// Pause conditions
			if (isActive == false)
			{
				playerController.enabled = isActive;
				Time.timeScale = 0f;
				pausePanel.SetActive(true);
			}
			else
			{
				playerController.enabled = isActive;
				Time.timeScale = 1f;
				pausePanel.SetActive(false);
			}
		}

	}

}
