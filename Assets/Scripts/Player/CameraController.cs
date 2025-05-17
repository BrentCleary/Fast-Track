using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	[SerializeField] float minFOV = 35f;
	[SerializeField] float maxFOV = 85f;
	[SerializeField] float zoomDuration = 1f;
	[SerializeField] float zoomSpeedModfier = 5f;

	CinemachineVirtualCamera cinemachineVirtualCamera;

    void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

	public void ChangeCameraFOV(float speedAmount)
    {
		StopAllCoroutines();

		StartCoroutine(ChangeFOVRoutine(speedAmount));
	}


    IEnumerator ChangeFOVRoutine(float speedAmount)
    {
		Debug.Log("Current FOV: " + cinemachineVirtualCamera.m_Lens.FieldOfView);

        float startFOV = cinemachineVirtualCamera.m_Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmount * zoomSpeedModfier, minFOV, maxFOV);

        float elapsedTime = 0f;

        while (elapsedTime < zoomDuration)
        {
            float t = elapsedTime / zoomDuration;
            elapsedTime += Time.deltaTime;

            cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
            yield return null;
        }

		Debug.Log("Adjusted FOV: " + cinemachineVirtualCamera.m_Lens.FieldOfView);

		cinemachineVirtualCamera.m_Lens.FieldOfView = targetFOV;


	}


}
