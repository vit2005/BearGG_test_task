using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    private Vector3 spawnPoint;
    private HpHandler hpHandler;

    private void Awake()
    {
        hpHandler = GetComponent<HpHandler>();
        hpHandler.Death += Death;
        spawnPoint = transform.position;
    }

    private void Death()
    {
        transform.position = spawnPoint;
        hpHandler.Revive();
    }
}
