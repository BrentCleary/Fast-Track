using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{
	public void StartLevel1()
	{
		SceneManager.LoadScene(1);
	}

	public void StartLevel2()
	{
		SceneManager.LoadScene(2);
	}

}
