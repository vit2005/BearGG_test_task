using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformCollisionHandler : MonoBehaviour
{
    private const string targetTag = "Platform";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(targetTag)) return;
        other.isTrigger = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag(targetTag)) return;
        other.isTrigger = true;
    }

    private void OnTriggerExit(Collider other) 
    {
        if (!other.gameObject.CompareTag(targetTag)) return;
        other.isTrigger = false;
    }
}
