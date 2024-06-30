using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HpHandler))]
public class DeathHandler : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<HpHandler>().Death += Death;
    }

    private void Death()
    {
        GetComponent<Collider>().enabled = false;
        StartCoroutine(DeathProcess());
    }

    IEnumerator DeathProcess()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
