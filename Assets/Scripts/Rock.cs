using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
	[SerializeField] ParticleSystem collisionParticleSystem;
	[SerializeField] float shakeModifier = 10f;

	CinemachineImpulseSource cinemachineImpulseSource;

    void Awake()
    {
		cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();

	}

    void OnCollisionEnter(Collision other) 
    {
		float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		float shakeIntensity = (1f / distance) * shakeModifier;
		shakeIntensity = Mathf.Min(shakeIntensity, 1f);
		cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
	}


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
