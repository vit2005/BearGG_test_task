using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformCollisionHandler : MonoBehaviour
{
    [SerializeField] Collider platform;    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player") return;
        platform.isTrigger = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name != "Player") return;
        platform.isTrigger = true;
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.name != "Player") return;
        platform.isTrigger = false;
    }
}
