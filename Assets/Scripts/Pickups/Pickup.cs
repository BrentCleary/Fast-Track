using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Pickup : MonoBehaviour
{

	/* DEV NOTES


	*/

    [SerializeField] float rotationSpeed = 100f;

    const string playerString = "Player";

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playerString))
        {
            OnPickup();
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickup();

}
