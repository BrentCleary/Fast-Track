using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    const string playerString = "Player";

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playerString))
        {
            Debug.Log(other.gameObject.name);
        }
    }

}
